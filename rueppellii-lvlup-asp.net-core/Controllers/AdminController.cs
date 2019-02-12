using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rueppellii_lvlup_asp.net_core.Dtos;
using rueppellii_lvlup_asp.net_core.Extensions;
using rueppellii_lvlup_asp.net_core.Models;
using rueppellii_lvlup_asp.net_core.Repositories;
using rueppellii_lvlup_asp.net_core.Services;
using rueppellii_lvlup_asp.net_core.Utility;

namespace rueppellii_lvlup_asp.net_core.Controllers
{
    [ApiController]
    [Authorize]
    [Route("admin")]
    public class AdminController : Controller
    {
        private readonly ICrudService<BadgeDto, Badge> service;

        public AdminController(ICrudService<BadgeDto, Badge> service)
        {
            this.service = service;
        }

        [HttpPost("add")]
        [Consumes("application/json")]
        public IActionResult Add(BadgeDto badgeDto)
        {
            if (badgeDto.IsAnyPropertyNull() || badgeDto.IsAnyStringPropertyEmpty())
            {
                return StatusCode(400, new ErrorMessage("Please provide all fields"));
            }
            service.Save(badgeDto);
            //return StatusCode(201, new ResponseMessage("Success"));
            return StatusCode(201, service.GetAll());
        }
    }
}