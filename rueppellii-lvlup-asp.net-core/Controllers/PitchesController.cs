﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rueppellii_lvlup_asp.net_core.Dtos;
using rueppellii_lvlup_asp.net_core.Extensions;
using rueppellii_lvlup_asp.net_core.Services.Interfaces;
using rueppellii_lvlup_asp.net_core.Utility;

namespace rueppellii_lvlup_asp.net_core.Controllers
{
    [ApiController]
    [Authorize]
    public class PitchesController : Controller
    {
        private readonly ICrudService<BasePitchDto> service;

        public PitchesController(ICrudService<BasePitchDto> service)
        {
            this.service = service;
        }

        [HttpPost("pitches")]
        [Consumes("application/json")]
        public IActionResult Post(PostPitchDto postPitchDto)
        {
            if (postPitchDto.IsAnyPropertyNull() || postPitchDto.IsAnyStringPropertyEmpty())
            {
                return StatusCode(400, new ErrorMessage("One or more fields are empty."));
            }

            service.Save(postPitchDto);

            return StatusCode(201, new ResponseMessage("Success"));
        }

        [HttpGet("pitches")]
        public IActionResult GetPitches()
        {
            return Ok(DummyJsonResponseDto.getPitches);
        }

        [HttpPut("pitches/{id}")]
        [Consumes("application/json")]
        public IActionResult Put([FromBody] PutPitchDto putPitchDto, long id)
        {
            if (putPitchDto.IsAnyPropertyNull() || putPitchDto.IsAnyStringPropertyEmpty())
            {
                return StatusCode(400, new ErrorMessage("Please provide all fields"));
            }
            service.Update(putPitchDto, id);
            return StatusCode(201, new ResponseMessage("Success"));
        }
    }
}
