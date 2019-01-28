using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rueppellii_lvlup_asp.net_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace rueppellii_lvlup_asp.net_core.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class BadgesController : Controller
  {
    [HttpGet]
    public IActionResult ListBadges()
    {
      var badges = "{ \"badges\": [ { \"name\": \"Process improver\", \"level\": \"2\"}, { \"name\": \"English speaker\", \"level\": \"1\"}, { \"name\": \"Feedback giver\", \"level\": \"1\"} ] }";
      if (Request.Headers["usertokenauth"] == "gen")
      {
        return Ok(badges);
      }
      return Unauthorized(new ErrorHandler("Unauthorized"));
    }
  }
}
