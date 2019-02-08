using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rueppellii_lvlup_asp.net_core.Containers;
using rueppellii_lvlup_asp.net_core.DTOs;
using rueppellii_lvlup_asp.net_core.Utility;

namespace rueppellii_lvlup_asp.net_core.Controllers
{
    [ApiController]
    [Authorize]
    public class BadgesController : Controller
    {
    private readonly ObjectContainer objectContainer;
    private readonly IMapper mapper;

    public BadgesController(IMapper mapper)
    {

      objectContainer = new ObjectContainer();
      objectContainer.Badges[0] = new LevelDto() { Name = "Process Improver", Level = 2 };
      objectContainer.Badges[1] = new LevelDto() { Name = "English Speaker", Level = 1 };
      objectContainer.Badges[2] = new LevelDto() { Name = "Feedback Giver", Level = 1 };
      this.mapper = mapper;
    }

    [HttpGet("badges")]
    public IActionResult ListBadges()
    {
        if (Request.Headers["usertokenauth"] == "gen")
        {
        return Ok(objectContainer);
        }
        return Unauthorized(new ErrorMessage("Unauthorized"));
        }
    }
}
