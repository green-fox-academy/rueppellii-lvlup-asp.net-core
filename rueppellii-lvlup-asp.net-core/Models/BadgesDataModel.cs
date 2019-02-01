using System.Collections.Generic;

namespace rueppellii_lvlup_asp.net_core.Models
{
    public class BadgesDataModel
    {
        public string Version { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public List<Levels> Levels { get; set; }
    }
}
