using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace rueppellii_lvlup_asp.net_core.Services
{
    public interface IAuthService
    {
        SecurityToken GetTokent(IEnumerable<Claim> claims);
    }
}
