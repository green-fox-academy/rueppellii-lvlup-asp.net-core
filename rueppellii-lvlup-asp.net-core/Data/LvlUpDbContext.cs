using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
