using AutoMapper;
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
        private readonly IMapper mapper;
        private readonly PitchService pitchService;

        public PitchesController(IMapper mapper, PitchService pitchService)
        {
            this.pitchService = pitchService;
            this.mapper = mapper;
        }

        [HttpPost("pitch")]
        [Consumes("application/json")]
        public IActionResult Post(PostPitchDto postPitchDto)
        {
            var pitchModel = mapper.Map<Pitch>(postPitchDto);

            if (string.IsNullOrEmpty(Request.Headers["usertokenauth"]))
            {
                return StatusCode(401, new ErrorMessage("Unauthorized"));
            }
            if (postPitchDto.IsAnyPropertyNull() || postPitchDto.IsAnyStringPropertyEmpty())
            {
                return StatusCode(400, new ErrorMessage("One or more fields are empty."));
            }
            return StatusCode(201, new ResponseMessage("Success"));
        }

        [HttpGet("pitches")]
        public IActionResult GetPitches()
        {
            if (string.IsNullOrEmpty(Request.Headers["usertokenauth"]))
            {
                return StatusCode(401, new ErrorMessage("Unauthorized"));
            }
            return Ok(DummyJsonResponseDto.getPitches);
        }

        [HttpPut("pitch/{id}")]
        [Consumes("application/json")]
        public IActionResult Put([FromBody]PutPitchDto putPitchDto, long id)
        {
            pitchService.Update(putPitchDto, id);
            if (putPitchDto.IsAnyPropertyNull() || putPitchDto.IsAnyStringPropertyEmpty())
            {
                return StatusCode(400, new ErrorMessage("Please provide all fields"));
            }

            return StatusCode(201, new ResponseMessage("Success"));
        }
    }
}
