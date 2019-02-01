using Microsoft.EntityFrameworkCore;
using rueppellii_lvlup_asp.net_core.Models;

namespace rueppellii_lvlup_asp.net_core.Data
{
    public class LvlUpDbContext : DbContext
    {
        public DbSet<BadgesDataModel> Badges { get; set; }
        public DbSet<UsersDataModel> Users { get; set; }
        public DbSet<ArchetypesDataModel> Archetypes { get; set; }
        public DbSet<PitchesDataModel> Pitches { get; set; }

        public LvlUpDbContext(DbContextOptions<LvlUpDbContext> options) : base(options)
        {
        }
    }
}
