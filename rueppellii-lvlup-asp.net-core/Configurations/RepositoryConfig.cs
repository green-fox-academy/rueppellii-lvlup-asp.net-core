using Microsoft.Extensions.DependencyInjection;
using rueppellii_lvlup_asp.net_core.Models;
using rueppellii_lvlup_asp.net_core.Repositories;

namespace rueppellii_lvlup_asp.net_core.Configurations
{
    public static class RepositoryConfig
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICrudRepository<Badge>, BadgeRepository>();
            services.AddScoped<ICrudRepository<Pitch>, PitchRepository>();
        }
    }
}
