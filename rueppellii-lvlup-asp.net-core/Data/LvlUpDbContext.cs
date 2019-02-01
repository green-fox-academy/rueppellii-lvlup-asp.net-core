using Microsoft.EntityFrameworkCore;
using rueppellii_lvlup_asp.net_core.Models;

namespace rueppellii_lvlup_asp.net_core.Data
{
    public class LvlUpDbContext : DbContext
    {
        public DbSet<Badges> Badges { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Archetypes> Archetypes { get; set; }
        public DbSet<Pitches> Pitches { get; set; }

        public LvlUpDbContext(DbContextOptions<LvlUpDbContext> options) : base(options)
        {
        }
    }
}
