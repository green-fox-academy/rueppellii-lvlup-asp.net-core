using Microsoft.EntityFrameworkCore;
using rueppellii_lvlup_asp.net_core.Models;

namespace rueppellii_lvlup_asp.net_core.Data
{
    public class LvlUpDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<Archetype> Archetypes { get; set; }
        public DbSet<Pitch> Pitches { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public LvlUpDbContext(DbContextOptions<LvlUpDbContext> options) : base(options)
        {
        }
    }
}
