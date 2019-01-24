using Microsoft.AspNetCore.Mvc;
using rueppellii_lvlup_asp.net_core.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rueppellii_lvlup_asp.net_core.Controllers
{
    [ApiController]
    public class PitchController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Test()
        {
            return StatusCode(418, "Test");
        }

        [HttpPost]
        [Route("pitch")]
        public IActionResult Post()
        {
            if (string.IsNullOrEmpty(Request.Headers["usertokenauth"]))
            {
                return Unauthorized(new ErrorMessage("Unauthorized"));
            }
            return Ok(new ResponseMessage("Success"));
        }
    }
}
