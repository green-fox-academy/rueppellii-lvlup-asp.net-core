using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rueppellii_lvlup_asp.net_core.Controllers
{
    [ApiController]
    public class PitchController : Controller
    {
        [HttpPost]
        [Route("pitch")]
        public IActionResult Post()
        {
            if (string.IsNullOrEmpty(Request.Headers["usertokenauth"]))
            {
                return Unauthorized(new KeyValuePair<string, string>("error", "Unauthorized"));
            }
            return Ok(Tuple.Create("message", "hello world"));
        }

        [HttpGet]
        [Route("")]
        public IActionResult Test()
        {
            return StatusCode(418, "Hello m8y");
        }
    }
}
