using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace rueppellii_lvlup_asp.net_core.Controllers
{
    [Route("admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        [HttpPost("add")]
        public IActionResult Add()
        {
            IDictionary<string, string> message = new Dictionary<string, string>
            {
                { "error", "Please provide all fields" }
            };
            return NotFound(message);
        }
    }
}