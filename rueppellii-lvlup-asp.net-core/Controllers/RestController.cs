using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rueppellii_lvlup_asp.net_core.DTO;
using rueppellii_lvlup_asp.net_core.Structs;

namespace rueppellii_lvlup_asp.net_core.Controllers
{
    [Route("admin")]
    [ApiController]
    public class AdminController : Controller
    {
        [HttpPost("add")]
        public IActionResult Add()
        {
            if (Request.ContentType != "application/json")
            {
                return StatusCode(415, new ErrorMessage("This server only supports json media type"));
            }           
            return NotFound(new ErrorMessage("Please provide all fields"));
        }
    }
}