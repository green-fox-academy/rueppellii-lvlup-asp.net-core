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
        public DbSet<ArchetypeLevel> ArchetypeLevels { get; set; }
        public DbSet<UserLevel> UserLevels { get; set; }

        public LvlUpDbContext(DbContextOptions<LvlUpDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserLevel>()
                .HasKey(k => new { k.UserId, k.LevelId });
            modelBuilder.Entity<UserLevel>()
                .HasOne(ul => ul.User)
                .WithMany(u => u.UserLevels)
                .HasForeignKey(ul => ul.UserId);
            modelBuilder.Entity<UserLevel>()
                .HasOne(ul => ul.Level)
                .WithMany(l => l.UserLevels)
                .HasForeignKey(ul => ul.LevelId);

            modelBuilder.Entity<ArchetypeLevel>()
                .HasKey(k => new { k.ArchetypeId, k.LevelId });
            modelBuilder.Entity<ArchetypeLevel>()
                .HasOne(al => al.Archetype)
                .WithMany(a => a.ArchetypeLevels)
                .HasForeignKey(al => al.ArchetypeId);
            modelBuilder.Entity<ArchetypeLevel>()
                .HasOne(al => al.Level)
                .WithMany(l => l.ArchetypeLevels)
                .HasForeignKey(al => al.LevelId);
        }
    }
}
