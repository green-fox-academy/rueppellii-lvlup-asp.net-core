using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rueppellii_lvlup_asp.net_core.Structs;

namespace rueppellii_lvlup_asp.net_core.Controllers
{
    [Route("admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        [HttpPost("add")]
        public IActionResult Add()
        {
            return NotFound(new ErrorMessage("Please provide all fields"));
        }
    }
}