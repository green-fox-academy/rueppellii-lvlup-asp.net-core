using Microsoft.AspNetCore.Mvc;
using rueppellii_lvlup_asp.net_core.Dtos;
using Microsoft.AspNetCore.Authorization;
using rueppellii_lvlup_asp.net_core.Extensions;
using rueppellii_lvlup_asp.net_core.Models;
using rueppellii_lvlup_asp.net_core.Utility;
using rueppellii_lvlup_asp.net_core.Services;

namespace rueppellii_lvlup_asp.net_core.Controllers
{
    [ApiController]
    [Authorize]
    public class PitchesController : Controller
    {
        private readonly ICrudService<PitchDto, Pitch> service;

        public PitchesController(ICrudService<PitchDto, Pitch> service)
        {
            this.service = service;
        }

        [HttpPost("pitch")]
        [Consumes("application/json")]
        public IActionResult Post(PostPitchDto postPitchDto)
        {
            if (postPitchDto.IsAnyPropertyNull() || postPitchDto.IsAnyStringPropertyEmpty())
            {
                return StatusCode(400, new ErrorMessage("One or more fields are empty."));
            }
            return StatusCode(201, new ResponseMessage("Success"));
        }

        [HttpGet("pitches")]
        public IActionResult GetPitches()
        {
            return Ok(service.GetAll());
        }

        [HttpPut("pitch")]
        [Consumes("application/json")]
        public IActionResult Put(PutPitchDto putPitchDto)
        {
            if (putPitchDto.IsAnyPropertyNull() || putPitchDto.IsAnyStringPropertyEmpty())
            {
                return StatusCode(400, new ErrorMessage("Please provide all fields"));
            }

            return StatusCode(201, new ResponseMessage("Success"));
        }
    }
}
