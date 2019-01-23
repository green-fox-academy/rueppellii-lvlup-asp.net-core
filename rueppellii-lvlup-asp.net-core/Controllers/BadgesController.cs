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
    public IActionResult Badges()
    {
      var badges = "badges";
      if (Request.ContentType.Equals("application/json") &&
        Request.Headers["usertokenauth"].Equals("<generated UUID>"))
      {
        return Ok(badges);
      }
      return Unauthorized(new ErrorHandler("Unauthorized"));
    }
  }
}
