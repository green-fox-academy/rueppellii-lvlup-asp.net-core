using AutoMapper;
using rueppellii_lvlup_asp.net_core.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rueppellii_lvlup_asp.net_core.Extensions;
using rueppellii_lvlup_asp.net_core.Models;
using rueppellii_lvlup_asp.net_core.Utility;

namespace rueppellii_lvlup_asp.net_core.Controllers
{
    [ApiController]
    [Authorize]
    public class PitchesController : Controller
    {
        private readonly IMapper mapper;

        public PitchesController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        [HttpPost("pitch")]
        [Consumes("application/json")]
        public IActionResult Post(PostPitchDto postPitchDto)
        {
            var pitchModel = mapper.Map<Pitch>(postPitchDto);

            if (postPitchDto.IsAnyPropertyNull() || postPitchDto.IsAnyStringPropertyEmpty())
            {
                return StatusCode(400, new ErrorMessage("One or more fields are empty."));
            }
            return StatusCode(201, new ResponseMessage("Success"));
        }

        [HttpGet("pitches")]
        public IActionResult GetPitches()
        {
            return Ok(DummyJsonResponseDto.getPitches);
        }

        [HttpPut("pitch")]
        [Consumes("application/json")]
        public IActionResult Put(PutPitchDto putPitchDto)
        {
            var pitchModel = mapper.Map<Pitch>(putPitchDto);

            if (putPitchDto.IsAnyPropertyNull() || putPitchDto.IsAnyStringPropertyEmpty())
            {
                return StatusCode(400, new ErrorMessage("Please provide all fields"));
            }

            return StatusCode(201, new ResponseMessage("Success"));
        }
    }
}
