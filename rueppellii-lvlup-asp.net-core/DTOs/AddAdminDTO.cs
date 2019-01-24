using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rueppellii_lvlup_asp.net_core.DTOs
{
    public class AddAdminDTO
    {
        public double Version { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public string Levels { get; set; }
    }
}
