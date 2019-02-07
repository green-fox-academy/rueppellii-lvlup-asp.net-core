using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using rueppellii_lvlup_asp.net_core.Data;
using rueppellii_lvlup_asp.net_core.Services;
using System.Security.Claims;
using System.Text;

namespace rueppellii_lvlup_asp.net_core
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<LvlUpDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IAuthService, AuthService>();
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
                    ValidIssuer = "auth",
                    ValidateAudience = true,
                    ValidAudience = "resource",
                    ValidateLifetime = true
                };
            })
            .AddGoogle(options =>
            {
                options.ClientId = Configuration["google:clientID"];
                options.ClientSecret = Configuration["google:clientSecret"];

                //Uncommenting these lines allows retrival of google user info without using the soon to be disabled google+API.
                //options.AuthorizationEndpoint = "https://accounts.google.com/o/oauth2/v2/auth";
                //options.TokenEndpoint = "https://oauth2.googleapis.com/token";
                //options.UserInformationEndpoint = "https://www.googleapis.com/oauth2/v2/userinfo";
                //options.ClaimActions.Clear();
                //options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "sub");
                //options.ClaimActions.MapJsonKey(ClaimTypes.Name, "name");
                //options.ClaimActions.MapJsonKey(ClaimTypes.GivenName, "given_name");
                //options.ClaimActions.MapJsonKey(ClaimTypes.Surname, "family_name");
                //options.ClaimActions.MapJsonKey("urn:google:profile", "profile");
                //options.ClaimActions.MapJsonKey(ClaimTypes.Email, "email");
                //options.ClaimActions.MapJsonKey("urn:google:image", "picture");
            });
            services.AddMvc();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
