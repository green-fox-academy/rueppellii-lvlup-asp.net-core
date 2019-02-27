using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using rueppellii_lvlup_asp.net_core.Services.Interfaces;
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
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public AuthService(IConfiguration configuration, IUserRepository repository, IMapper mapper)
        {
            this._configuration = configuration;
            this._repository = repository;
            this._mapper = mapper;
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
            try
            {
                if (!_repository.DoesEntityExistByProperty("Email", GetUserEmail(user)))
                {
                    _repository.Save(_mapper.Map<User>(user));
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("A required field for User entity is missing or invalid! " + e.Message);
            }
        }

        private string GetUserEmail(ClaimsPrincipal user)
        {
            var userEmail = string.Empty;
            try
            {
                userEmail = user.Claims.First(claim => claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").Value;
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("User claims do not include an email address! " + e.Message);
            }
            return userEmail;
        }
    }
}
