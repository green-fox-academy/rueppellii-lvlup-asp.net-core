using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Add(AddAdminDTO addAdminDTO)
        {
            if (string.IsNullOrEmpty(Request.Headers["usertokenauth"]))
            {
                return Unauthorized(new ErrorMessage("usertokenauth missing"));
            }
            else if (((int?)addAdminDTO.Version ?? 0) == 0 ||
                string.IsNullOrEmpty(addAdminDTO.Name) ||
                string.IsNullOrEmpty(addAdminDTO.Tag) ||
                string.IsNullOrEmpty(addAdminDTO.Levels))
            {
                return BadRequest(new ErrorMessage("Please provide all fields"));
            }
            return StatusCode(201, new ResponseMessage("Success"));
        }

    }
}