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
        public IActionResult Add(AddAdminDTO addAdminDTO)
        {
            if (Request.ContentType != "application/json")
            {
                return StatusCode(415, new ErrorMessage("This server only supports json media type"));
            }
            else if (string.IsNullOrEmpty(Request.Headers["usertokenauth"]) ||
                ((int?)addAdminDTO.Version ?? 0) == 0 ||
                String.IsNullOrEmpty(addAdminDTO.Name) ||
                String.IsNullOrEmpty(addAdminDTO.Tag) ||
                addAdminDTO.Levels == null
                )
            {
                return NotFound(new ErrorMessage("Please provide all fields"));
            }
            return StatusCode(201, new ResponseMessage("Success"));
        }

    }
}