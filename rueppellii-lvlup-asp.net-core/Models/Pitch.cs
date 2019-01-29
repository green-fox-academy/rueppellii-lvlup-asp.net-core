using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rueppellii_lvlup_asp.net_core.Models
{
    public class Pitch
    {
        public string timeStamp { get; set; }
        public string userName { get; set; }
        public string badgeName { get; set; }
        public int? oldLvl { get; set; }
        public int? pitchedLvl { get; set; }
        public string pitchMessage { get; set; }
        public string[] holders { get; set; }
    }
}
