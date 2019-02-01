using System.Collections.Generic;

namespace rueppellii_lvlup_asp.net_core.Models
{
    public class Levels
    {
        public int? Level { get; set; }
        public string Description { get; set; }
        public List<string> Holders { get; set; }
    }
}