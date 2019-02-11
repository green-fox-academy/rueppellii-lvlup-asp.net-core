using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rueppellii_lvlup_asp.net_core.Dtos;
using rueppellii_lvlup_asp.net_core.Extensions;
using rueppellii_lvlup_asp.net_core.Models;
using rueppellii_lvlup_asp.net_core.Repositories;
using rueppellii_lvlup_asp.net_core.Utility;

namespace rueppellii_lvlup_asp.net_core.Controllers
{
    [ApiController]
    [Authorize]
    [Route("admin")]
    public class AdminController : Controller
    {
        private readonly IMapper mapper;
        private readonly BadgeRepository repository;

        public AdminController(IMapper mapper, BadgeRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        [HttpPost("add")]
        [Consumes("application/json")]
        public IActionResult Add(BadgeDto badgeDto)
        {
            var badgeModel = mapper.Map<Badge>(badgeDto);

            if (string.IsNullOrEmpty(Request.Headers["usertokenauth"]))
            {
                return StatusCode(401, new ErrorMessage("Unauthorized"));
            }
            if (badgeDto.IsAnyPropertyNull() || badgeDto.IsAnyStringPropertyEmpty())
            {
                return StatusCode(400, new ErrorMessage("Please provide all fields"));
            }
            repository.Save(badgeModel);
            return StatusCode(201, new ResponseMessage("Success"));
        }
    }
}