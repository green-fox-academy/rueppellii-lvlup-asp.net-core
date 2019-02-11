using Microsoft.Extensions.DependencyInjection;
using rueppellii_lvlup_asp.net_core.Services;

namespace rueppellii_lvlup_asp.net_core.Configurations
{
    public static class ServiceConfig
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}
