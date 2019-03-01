using System;
using System.Collections.Generic;

namespace rueppellii_lvlup_asp.net_core.Dtos
{
    public class GetPitchDto
    {
        public long Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string UserName { get; set; }
        public string BadgeName { get; set; }
        public int BadgeLevel{ get; set; }
        public int PitchedLevel { get; set; }
        public string PitchMessage { get; set; }
        public List<ReviewDto> Reviews { get; set; }
    }
}
