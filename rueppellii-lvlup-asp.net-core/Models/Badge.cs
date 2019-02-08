using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rueppellii_lvlup_asp.net_core.Models
{
    public class Badge
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string Version { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Tag { get; set; }

        public List<Level> Levels { get; set; }
        [JsonIgnore]
        public List<Pitch> Pitches { get; set; }
    }
}
