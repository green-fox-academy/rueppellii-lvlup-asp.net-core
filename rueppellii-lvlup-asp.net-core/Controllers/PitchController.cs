﻿using Microsoft.AspNetCore.Mvc;
using rueppellii_lvlup_asp.net_core.Dtos;
using rueppellii_lvlup_asp.net_core.DTOs;
using rueppellii_lvlup_asp.net_core.Structs;

namespace rueppellii_lvlup_asp.net_core.Controllers
{
    [ApiController]
    public class PitchController : Controller
    {
        [HttpPost]
        [Route("pitch")]
        [Consumes("application/json")]
        public IActionResult Post(PitchDto pitchDto)
        {
            if (string.IsNullOrEmpty(Request.Headers["usertokenauth"]))
            {
                return StatusCode(401, new ErrorMessage("Unauthorized"));
            }

            if (string.IsNullOrEmpty(pitchDto.BadgeName) ||
                pitchDto.OldLvl == null ||
                pitchDto.PitchedLvl == null ||
                string.IsNullOrEmpty(pitchDto.PitchMessage) ||
                pitchDto.Holders == null)
            {
                return StatusCode(400, new ErrorMessage("One or more fields are empty."));
            }

            return StatusCode(201, new ResponseMessage("Success"));
        }

        [HttpGet("pitches")]
        public IActionResult GetPitches()
        {
            var response = new DummyJsonResponseDTO();

            if (string.IsNullOrEmpty(Request.Headers["usertokenauth"]))
            {
                return StatusCode(401, new ErrorMessage("Unauthorizied"));
            }

            return Ok(response.json);
        }
    }
}