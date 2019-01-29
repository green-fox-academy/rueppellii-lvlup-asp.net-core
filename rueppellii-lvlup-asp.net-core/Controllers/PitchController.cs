using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using rueppellii_lvlup_asp.net_core.Dtos;
using rueppellii_lvlup_asp.net_core.Models;
using rueppellii_lvlup_asp.net_core.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpGet]
        [Route("pitches")]
        [Consumes("application/json")]
        public IActionResult GetPitches()
        {
            string json = JsonConvert.SerializeObject(new
            {
                myPitches = new List<Pitch>()
                { new Pitch {timeStamp = "2018-11-29 17:10:47", userName = "balazs.barna", badgeName = "Programming", oldLvl = 2, pitchedLvl = 3, pitchMessage = "I improved in React, Redux, basic JS, NodeJS, Express and in LowDB, pls give me more money", holders = null} },
                pitchesToReview = new List<Pitch>()
                { new Pitch {timeStamp = "2018-11-29 17:10:47", userName = "berei.daniel", badgeName = "English speaker", oldLvl = 2, pitchedLvl = 3, pitchMessage = "I was working abroad for six years, so I can speak english very well. Pls improve my badge level to 3.", holders = null} }
            });

            if (string.IsNullOrEmpty(Request.Headers["usertokenauth"]))
            {
                return StatusCode(401, new ErrorMessage("Unauthorizied"));
            }

            return Ok(json);
        }
    }
}
