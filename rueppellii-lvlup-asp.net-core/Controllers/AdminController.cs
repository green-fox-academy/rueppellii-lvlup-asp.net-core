using Microsoft.AspNetCore.Mvc;
using rueppellii_lvlup_asp.net_core.Dtos;
using rueppellii_lvlup_asp.net_core.Extensions;
using rueppellii_lvlup_asp.net_core.Utility;

namespace rueppellii_lvlup_asp.net_core.Controllers
{
    [ApiController]
    [Route("admin")]
    public class AdminController : Controller
    {
        [HttpPost("add")]
        [Consumes("application/json")]
        public IActionResult Add(AddAdminDto addAdminDto)
        {
            if (string.IsNullOrEmpty(Request.Headers["usertokenauth"]))
            {
                return StatusCode(401, new ErrorMessage("usertokenauth missing"));
            }
            if(addAdminDto.IsAnyPropertyNull() || addAdminDto.IsAnyStringPropertyEmpty())
            {
                return StatusCode(400, new ErrorMessage("Please provide all fields"));
            }
            return StatusCode(201, new ResponseMessage("Success"));
        }
    }
}