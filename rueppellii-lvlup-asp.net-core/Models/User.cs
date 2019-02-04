using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rueppellii_lvlup_asp.net_core.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [NotMapped]
        public string TokenAuth { get; set; }

        public string Pic { get; set; }

        public List<Badge> Badges { get; set; }
        public List<Pitch> Pitches { get; set; }
    }
}
