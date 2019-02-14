using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rueppellii_lvlup_asp.net_core.Utility;

namespace rueppellii_lvlup_asp.net_core.Controllers
{
    [ApiController]
    [Authorize]
    public class HeartbeatController : Controller
    {
        public readonly IMapper mapper;

        public HeartbeatController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        [HttpGet("heartbeat")]
        public IActionResult Heartbeat()
        {
            return Ok(new ResponseMessage("OK"));
        }
    }
}
