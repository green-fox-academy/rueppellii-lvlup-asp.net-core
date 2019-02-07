using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using rueppellii_lvlup_asp.net_core.Utility;

namespace rueppellii_lvlup_asp.net_core.Controllers
{
    [ApiController]
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
            if (string.IsNullOrEmpty(Request.Headers["usertokenauth"]))
            {
                return StatusCode(401, new ErrorMessage("Unauthorizied"));
            }

            return Ok(new ResponseMessage("OK"));
        }
    }
}
