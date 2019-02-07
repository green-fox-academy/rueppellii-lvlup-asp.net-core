using rueppellii_lvlup_asp.net_core.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rueppellii_lvlup_asp.net_core.DTOs
{
    public class BadgeDto
    {
        public string Version { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public List<Level> Levels { get; set; }
    }
}
