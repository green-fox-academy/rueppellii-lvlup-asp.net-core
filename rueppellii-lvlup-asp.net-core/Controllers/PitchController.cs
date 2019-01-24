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
        [HttpPost]
        [Route("pitch")]
        [Consumes("application/json")]
        public IActionResult Post()
        {
            if (string.IsNullOrEmpty(Request.Headers["usertokenauth"]))
            {
                return StatusCode(401, new ErrorMessage("Unauthorized"));
            }
            return StatusCode(201, new ResponseMessage("Success"));
        }
    }
}
