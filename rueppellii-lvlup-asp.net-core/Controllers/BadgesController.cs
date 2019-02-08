using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rueppellii_lvlup_asp.net_core.Containers;
using rueppellii_lvlup_asp.net_core.Dtos;
using rueppellii_lvlup_asp.net_core.Utility;

namespace rueppellii_lvlup_asp.net_core.Controllers
{
    [ApiController]
    [Authorize]
    public class BadgesController : Controller
    {
    private readonly ObjectContainer objectContainer;

    public BadgesController()
    {
        objectContainer = new ObjectContainer();
        objectContainer.Badges[0] = new BadgeDto() { Name = "Process Improver", Level = 2 };
        objectContainer.Badges[1] = new BadgeDto() { Name = "English Speaker", Level = 1 };
        objectContainer.Badges[2] = new BadgeDto() { Name = "Feedback Giver", Level = 1 };
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
