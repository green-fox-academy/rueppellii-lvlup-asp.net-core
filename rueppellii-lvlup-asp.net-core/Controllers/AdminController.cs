using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using rueppellii_lvlup_asp.net_core.Dtos;
using rueppellii_lvlup_asp.net_core.Extensions;
using rueppellii_lvlup_asp.net_core.Models;
using rueppellii_lvlup_asp.net_core.Utility;

namespace rueppellii_lvlup_asp.net_core.Controllers
{
    [ApiController]
    [Route("admin")]
    public class AdminController : Controller
    {
        private readonly IMapper mapper;

        public AdminController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        [HttpPost("add")]
        [Consumes("application/json")]
        public IActionResult Add(AddAdminDto addAdminDto)
        {
            var badgeModel = mapper.Map<Badge>(addAdminDto);

            if (string.IsNullOrEmpty(Request.Headers["usertokenauth"]))
            {
                return StatusCode(401, new ErrorMessage("Unauthorized"));
            }
            if (addAdminDto.IsAnyPropertyNull() || addAdminDto.IsAnyStringPropertyEmpty())
            {
                return StatusCode(400, new ErrorMessage("Please provide all fields"));
            }
            return StatusCode(201, new ResponseMessage("Success"));
        }
    }
}