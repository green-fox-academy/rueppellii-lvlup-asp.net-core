using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rueppellii_lvlup_asp.net_core.Dtos
{
    public class PutPitchDto
    {
        public string PitcherName { get; set; }
        public string BadgeName { get; set; }
        public string NewStatus { get; set; }
        public string NewMessage { get; set; }
    }
}
