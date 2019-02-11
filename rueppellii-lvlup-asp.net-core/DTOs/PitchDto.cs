using System;
using System.Collections.Generic;

namespace rueppellii_lvlup_asp.net_core.Dtos
{
    public class PitchDto
    {
        public DateTime Timestamp { get; set; }
        public string Username { get; set; }
        public string BadgeName { get; set; }
        public int OldLevel { get; set; }
        public int PitchedLevel { get; set; }
        public string PitchMessage { get; set; }
        public List<ReviewDto> Holders { get; set; }
    }
}
