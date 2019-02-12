using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using rueppellii_lvlup_asp.net_core.Configurations;
using rueppellii_lvlup_asp.net_core.Data;
using rueppellii_lvlup_asp.net_core.Dtos;
using rueppellii_lvlup_asp.net_core.Models;
using rueppellii_lvlup_asp.net_core.Repositories;
using rueppellii_lvlup_asp.net_core.Services;
using rueppellii_lvlup_asp.net_core.Utility;

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
            services.AddMvc();
            services.AddRepositories();
            services.AddServices();
            services.AddDbContext<LvlUpDbContext>(options =>
                options.UseInMemoryDatabase("development"));
            services.AddAuth(Configuration);

            var configuredMapper = new AutoMapper.MapperConfiguration(c => c.AddProfile(new ApplicationProfile())).CreateMapper();
            services.AddSingleton(configuredMapper);
        }

        public void ConfigureTestingServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddRepositories();
            services.AddServices();
            services.AddDbContext<LvlUpDbContext>(options =>
                options.UseInMemoryDatabase("testing"));
            services.AddAuth(Configuration);

            var configuredMapper = new AutoMapper.MapperConfiguration(c => c.AddProfile(new ApplicationProfile())).CreateMapper();
            services.AddSingleton(configuredMapper);
        }

        public void ConfigureProductionServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddRepositories();
            services.AddServices();
            services.AddDbContext<LvlUpDbContext>(options =>
                options.UseSqlServer(Configuration["LvlUpConnection"]));
            services.AddAuth(Configuration);

            var configuredMapper = new AutoMapper.MapperConfiguration(c => c.AddProfile(new ApplicationProfile())).CreateMapper();
            services.AddSingleton(configuredMapper);
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