using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rueppellii_lvlup_asp.net_core.DTOs
{
    public class PutPitchDto
    {
        public string PitcherName { get; set; }
        public string BadgeName { get; set; }
        public int? NewStatus { get; set; }
        public string NewMessage { get; set; }
    }
}
