using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rueppellii_lvlup_asp.net_core.Dtos
{
    public class PitchDto
    {
        public string BadgeName { get; set; }
        public int? OldLvl { get; set; }
        public int? PitchedLvl { get; set; }
        public string PitchMessage { get; set; }
        public string[] Holders { get; set; }
    }
}
