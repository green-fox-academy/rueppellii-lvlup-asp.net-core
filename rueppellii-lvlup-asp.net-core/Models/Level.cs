using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rueppellii_lvlup_asp.net_core.Models
{
    public class Level
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public int BadgeLevel { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        public Badge Badge { get; set; }
        [JsonIgnore]
        public List<Pitch> Pitches { get; set; }
        public List<UserLevel> UserLevels { get; set; }
        [JsonIgnore]
        public List<ArchetypeLevel> ArchetypeLevels { get; set; }
    }
}