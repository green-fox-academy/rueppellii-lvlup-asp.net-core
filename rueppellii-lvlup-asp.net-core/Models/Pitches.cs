using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rueppellii_lvlup_asp.net_core.Models
{
    public class Pitches
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }

        public string Username { get; set; }

        public string BadgeName { get; set; }

        public int OldLevel { get; set; }

        public int PitchedLevel { get; set; }

        [MaxLength(200)]
        public string PitchMessage { get; set; }

        public List<Reviews> Reviewers { get; set; }

        public Users User { get; set; }
        public Badges Badges { get; set; }

    }
}
