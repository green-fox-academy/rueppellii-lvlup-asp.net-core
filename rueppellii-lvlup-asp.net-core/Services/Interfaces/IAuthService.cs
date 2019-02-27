using System.Collections.Generic;
using System.Security.Claims;

namespace rueppellii_lvlup_asp.net_core.Services.Interfaces

{
    public interface IAuthService
    {
        string GetToken(IEnumerable<Claim> claims);
        void SaveUserIfNotExists(ClaimsPrincipal user);
    }
}