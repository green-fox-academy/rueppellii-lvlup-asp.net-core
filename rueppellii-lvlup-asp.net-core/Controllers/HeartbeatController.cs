using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rueppellii_lvlup_asp.net_core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rueppellii_lvlup_asp.net_core.Controllers
{
    [ApiController]
    [Authorize]
    public class HeartbeatController : Controller
    {
        [HttpGet("heartbeat")]
        public IActionResult Heartbeat()
        {
            if (string.IsNullOrEmpty(Request.Headers["usertokenauth"]))
            {
                return StatusCode(401, new ErrorMessage("Unauthorizied"));
            }

            return Ok(new ResponseMessage("OK"));
        }
    }
}
