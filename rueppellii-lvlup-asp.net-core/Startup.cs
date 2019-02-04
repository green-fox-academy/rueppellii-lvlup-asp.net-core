using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using rueppellii_lvlup_asp.net_core.Data;
using rueppellii_lvlup_asp.net_core.Environments;

namespace rueppellii_lvlup_asp.net_core
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
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
            services.AddDbContext<LvlUpDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

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

            app.UseMvc();
        }
    }
}
