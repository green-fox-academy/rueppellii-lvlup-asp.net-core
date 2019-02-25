using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rueppellii_lvlup_asp.net_core.Services;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace rueppellii_lvlup_asp.net_core.Controllers
{
    [Authorize(AuthenticationSchemes = GoogleDefaults.AuthenticationScheme)]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService) => this._authService = authService;

        [HttpGet("/auth")]
        public IActionResult Auth()
        {
            _authService.SaveUserIfNotExists(User);
            return Ok(_authService.GetToken(User.Claims));
        }
    }
}
