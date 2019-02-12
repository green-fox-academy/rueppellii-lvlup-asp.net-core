using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using rueppellii_lvlup_asp.net_core.Models;
using rueppellii_lvlup_asp.net_core.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace rueppellii_lvlup_asp.net_core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly ICrudRepository<User> _repository;

        public AuthService(IConfiguration configuration, ICrudRepository<User> repository)
        {
            this._configuration = configuration;
            this._repository = repository;
        }

        public string GetToken(IEnumerable<Claim> claims)
        {
            var token = new JwtSecurityToken(
                signingCredentials: this.GetSigningCredentials(this.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256Signature),
                issuer: _configuration["jwt:issuer"],
                audience: _configuration["jwt:audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(5),
                notBefore: DateTime.UtcNow);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private SymmetricSecurityKey GetSymmetricSecurityKey() => 
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:secretKey"]));

        private SigningCredentials GetSigningCredentials(SecurityKey key, string algorithm) => 
            new SigningCredentials(key, algorithm);

        public void SaveUserIfNotExists(ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }
    }
}
