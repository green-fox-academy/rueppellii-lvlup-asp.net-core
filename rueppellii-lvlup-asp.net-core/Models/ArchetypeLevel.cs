using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace rueppellii_lvlup_asp.net_core.Models
{
    public class ArchetypeLevel
    {

        public long ArchetypeId { get; set; }
        public Archetype Archetype { get; set; }

        public long LevelId { get; set; }
        public Level Level { get; set; }
    }
}

