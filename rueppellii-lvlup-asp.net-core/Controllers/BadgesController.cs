using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rueppellii_lvlup_asp.net_core.Dtos;
using rueppellii_lvlup_asp.net_core.Models;
using rueppellii_lvlup_asp.net_core.Services.Interfaces;

namespace rueppellii_lvlup_asp.net_core.Controllers
{
    [ApiController]
    [Authorize]
    public class BadgesController : Controller
    {
        private readonly ICrudService<BadgeDto> service;

        public BadgesController(ICrudService<BadgeDto> service)
        {
            this.service = service;
        }

        [HttpGet("badges")]
        public IActionResult ListBadges()
        {
            return Ok(service.GetAll());
        }
    }
}
