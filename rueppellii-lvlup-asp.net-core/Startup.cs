using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using rueppellii_lvlup_asp.net_core.Configurations;
using rueppellii_lvlup_asp.net_core.Data;
using rueppellii_lvlup_asp.net_core.Configurations;

namespace rueppellii_lvlup_asp.net_core
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            services.AddDbContext<LvlUpDbContext>(options =>
            options.UseInMemoryDatabase("development"));

            services.AddMvc();
        }

        public void ConfigureTestingServices(IServiceCollection services)
        {
            services.AddDbContext<LvlUpDbContext>(options =>
            options.UseInMemoryDatabase("testing"));

            services.AddMvc();
        }

        public void ConfigureProductionServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddAuth(Configuration);
            services.AddServices();
            services.AddDbContext<LvlUpDbContext>(options =>
            options.UseSqlServer(Configuration["LvlUpConnection"]));
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, LvlUpDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            if (env.IsDevelopment() || env.IsTesting())
            {
                context.AddSeededData();
            }

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}