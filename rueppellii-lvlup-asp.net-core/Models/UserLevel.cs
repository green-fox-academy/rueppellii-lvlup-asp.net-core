using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rueppellii_lvlup_asp.net_core.Models
{
    public class UserLevel
    {
        public long UserId { get; set; }
        public User User { get; set; }

        public long LevelId { get; set; }
        public Level Level { get; set; }
    }
}
