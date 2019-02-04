using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rueppellii_lvlup_asp.net_core.Controllers
{
    [Route("/auth")]
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult Auth()
        {
        }
    }
}
