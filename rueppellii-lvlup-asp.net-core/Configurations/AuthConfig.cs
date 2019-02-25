using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace rueppellii_lvlup_asp.net_core.Configurations
{
    public static class AuthConfig
    {
        public static void AddAuth(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddIdentity<IdentityUser, IdentityRole>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(JwtBearerOptions =>
            {
                JwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["jwt:secretKey"])),
                    ValidateIssuer = true,
                    ValidIssuer = Configuration["jwt:issuer"],
                    ValidateAudience = true,
                    ValidAudience = Configuration["jwt:audience"],
                    ValidateLifetime = true
                };
            })
            .AddGoogle(options =>
            {
                options.ClientId = Configuration["google:clientID"];
                options.ClientSecret = Configuration["google:clientSecret"];
                options.Events.OnCreatingTicket = context =>
                {
                    var profilePic = context.User.SelectToken("image.url").ToString();
                    context.Identity.AddClaim(new Claim("profilePic", profilePic));
                    return Task.CompletedTask;
                };
            });
        }
    }
}
