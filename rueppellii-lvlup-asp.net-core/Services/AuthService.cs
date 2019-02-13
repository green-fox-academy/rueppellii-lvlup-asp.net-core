using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using rueppellii_lvlup_asp.net_core.Models;
using rueppellii_lvlup_asp.net_core.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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

        private SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:secretKey"]));
        }

        private SigningCredentials GetSigningCredentials(SecurityKey key, string algorithm)
        {
            return new SigningCredentials(key, algorithm);
        }

        public void SaveUserIfNotExists(ClaimsPrincipal user)
        {
            var emailAddress = string.Empty;
            try
            {
                var emailAddressClaim = from claim in user.Claims
                               where claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"
                               select claim;
                emailAddress = emailAddressClaim.First<Claim>().Value;
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("User claims do not include an email address! " + e.Message);
            }
            if (!_repository.DoesEntityExistByProperty("Email", emailAddress))
            {
                _repository.Save();
            }

        }
    }
}
