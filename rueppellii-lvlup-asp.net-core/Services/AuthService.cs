using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace rueppellii_lvlup_asp.net_core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration) => this._configuration = configuration;

        public string GetToken(IEnumerable<Claim> claims)
        {
            var token = new JwtSecurityToken(
                signingCredentials: this.GetSigningCredentials(this.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256Signature),
                issuer: "google",
                audience: "greenfox",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(5),
                notBefore: DateTime.UtcNow);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private SymmetricSecurityKey GetSymmetricSecurityKey() => 
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:secretKey"]));

        private SigningCredentials GetSigningCredentials(SecurityKey key, string algorithm) => 
            new SigningCredentials(key, algorithm);
    }
}
