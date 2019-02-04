using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rueppellii_lvlup_asp.net_core.Models
{
    public class Reviews
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Users User { get; set; }

        [MaxLength(500)]
        public string Message { get; set; }

        public bool PitchStatus { get; set; }
    }
}
