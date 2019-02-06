using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using rueppellii_lvlup_asp.net_core.Dtos;
using rueppellii_lvlup_asp.net_core.Extensions;
using rueppellii_lvlup_asp.net_core.Models;
using rueppellii_lvlup_asp.net_core.Utility;

namespace rueppellii_lvlup_asp.net_core.Controllers
{
    [ApiController]
    public class PitchesController : Controller
    {
        private readonly IMapper mapper;

        public PitchesController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        [HttpPost("pitch")]
        [Consumes("application/json")]
        public IActionResult Post(PitchDto pitchDto)
        {
            var pitchModel = mapper.Map<Pitch>(pitchDto);

            if (string.IsNullOrEmpty(Request.Headers["usertokenauth"]))
            {
                return StatusCode(401, new ErrorMessage("Unauthorized"));
            }
            if (pitchDto.IsAnyPropertyNull() || pitchDto.IsAnyStringPropertyEmpty())
            {
                return StatusCode(400, new ErrorMessage("One or more fields are empty."));
            }
            return StatusCode(201, pitchModel);
            //new ResponseMessage("Success")
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

        [HttpPut("pitch")]
        [Consumes("application/json")]
        public IActionResult Put(PutPitchDto putPitchDto)
        {
            if (string.IsNullOrEmpty(Request.Headers["usertokenauth"]))
            {
                return StatusCode(401, new ErrorMessage("Unauthorized"));
            }

            if (putPitchDto.IsAnyPropertyNull() || putPitchDto.IsAnyStringPropertyEmpty())
            {
                return StatusCode(400, new ErrorMessage("Please provide all fields"));
            }

            return StatusCode(201, new ResponseMessage("Success"));
        }
    }
}
