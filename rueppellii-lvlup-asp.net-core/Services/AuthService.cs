using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using rueppellii_lvlup_asp.net_core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace rueppellii_lvlup_asp.net_core.Services
{
    public class AuthService : IAuthService
    {
        private IConfiguration Configuration { get; }

        public AuthService(IConfiguration configuration) => this.Configuration = configuration;

        public string GetToken(IEnumerable<Claim> claims)
        {
            var token = new JwtSecurityToken(
                signingCredentials: this.GetSigningCredentials(this.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256Signature),
                issuer: Configuration["jwt:issuer"],
                audience: Configuration["jwt:audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(5),
                notBefore: DateTime.UtcNow);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private SymmetricSecurityKey GetSymmetricSecurityKey() => 
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["jwt:secretKey"]));

        private SigningCredentials GetSigningCredentials(SecurityKey key, string algorithm) => 
            new SigningCredentials(key, algorithm);
    }
}
