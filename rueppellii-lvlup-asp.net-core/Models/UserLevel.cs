using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rueppellii_lvlup_asp.net_core.Models
{
    public class UserLevel
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("User")]
        public long UserId { get; set; }
        public User User { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Level")]
        public long LevelId { get; set; }
        public Level Level { get; set; }
    }
}