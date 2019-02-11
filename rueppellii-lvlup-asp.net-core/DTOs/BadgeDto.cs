using rueppellii_lvlup_asp.net_core.Models;
using System.Collections.Generic;

namespace rueppellii_lvlup_asp.net_core.Dtos
{
    public class BadgeDto
    {
        public string Version { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public List<Level> Levels { get; set; }
    }
}
