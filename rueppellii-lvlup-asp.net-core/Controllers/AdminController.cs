using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using rueppellii_lvlup_asp.net_core.DTOs;
using rueppellii_lvlup_asp.net_core.Utility;

namespace rueppellii_lvlup_asp.net_core.Controllers
{
    [Route("admin")]
    [ApiController]
    public class AdminController : Controller
    {
        [HttpPost("add")]
        [Consumes("application/json")]
        public IActionResult Add(AddAdminDto addAdminDto)
        {
            if (string.IsNullOrEmpty(Request.Headers["usertokenauth"]))
            {
                return Unauthorized(new ErrorMessage("usertokenauth missing"));
            }
            if (((int?)addAdminDto.Version ?? 0) == 0 ||
                string.IsNullOrEmpty(addAdminDto.Name) ||
                string.IsNullOrEmpty(addAdminDto.Tag) ||
                addAdminDto.Levels == null)
            {
                return BadRequest(new ErrorMessage("Please provide all fields"));
            }
            return StatusCode(201, new ResponseMessage("Success"));
        }
    }
}