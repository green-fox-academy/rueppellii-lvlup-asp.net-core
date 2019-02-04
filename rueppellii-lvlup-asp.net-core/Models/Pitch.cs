using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rueppellii_lvlup_asp.net_core.Models
{
    /// <summary>
    /// DTO field restructure 
    /// </summary>
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

        public List<Review> Reviewers { get; set; }
        public User User { get; set; }
        public Badge Badges { get; set; }

    }
}
