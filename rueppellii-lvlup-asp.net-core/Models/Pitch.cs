using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rueppellii_lvlup_asp.net_core.Models
{
    public class Pitch
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Timestamp]
        public DateTime Timestamp { get; set; }

        public int OldLevel { get; set; }
        public int PitchedLevel { get; set; }

        [MaxLength(200)]
        public string PitchMessage { get; set; }

        public List<Review> Reviews { get; set; }
        public User User { get; set; }
        public Badge Badge { get; set; }
        public Level Level { get; set; }

    }
}

