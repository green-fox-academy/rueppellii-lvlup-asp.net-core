using Microsoft.AspNetCore.Mvc;
using rueppellii_lvlup_asp.net_core.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rueppellii_lvlup_asp.net_core.Controllers
{
    [ApiController]
    public class HeartbeatController : Controller
    {
        [HttpGet("heartbeat")]
        public IActionResult heartbeat()
        {
            if (string.IsNullOrEmpty(Request.Headers["usertokenauth"]))
            {
                return StatusCode(401, new ErrorMessage("Unauthorizied"));
            }

            return StatusCode(200, new ResponseMessage("OK"));
        }
    }
}
