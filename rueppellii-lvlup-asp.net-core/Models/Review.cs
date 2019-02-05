using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rueppellii_lvlup_asp.net_core.Models
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }


        [MaxLength(500)]
        public string Message { get; set; }

        public bool PitchStatus { get; set; }

        public User User { get; set; }
        public Pitch Pitch { get; set; }
    }
}