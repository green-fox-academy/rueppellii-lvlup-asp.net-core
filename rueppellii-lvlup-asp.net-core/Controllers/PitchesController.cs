﻿using Microsoft.AspNetCore.Mvc;
using rueppellii_lvlup_asp.net_core.Dtos;
using rueppellii_lvlup_asp.net_core.Extensions;
using rueppellii_lvlup_asp.net_core.Utility;

namespace rueppellii_lvlup_asp.net_core.Controllers
{
    [ApiController]
    public class PitchesController : Controller
    {
        [HttpPost("pitch")]
        [Consumes("application/json")]
        public IActionResult Post(PitchDto pitchDto)
        {
            if (string.IsNullOrEmpty(Request.Headers["usertokenauth"]))
            {
                return StatusCode(401, new ErrorMessage("Unauthorized"));
            }
            if (pitchDto.IsAnyPropertyNull() || pitchDto.IsAnyStringPropertyEmpty())
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
            return Ok(DummyJsonResponseDTO.getPitches);
        }
    }
}