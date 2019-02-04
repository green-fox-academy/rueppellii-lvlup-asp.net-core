using Microsoft.AspNetCore.Hosting;

namespace rueppellii_lvlup_asp.net_core.Configurations
{
    public static class Environments
    {
        public const string Testing = "Testing";

        public static bool IsTesting(this IHostingEnvironment hosting)
        {
            return hosting.IsEnvironment(Testing);
        }
    }
}
