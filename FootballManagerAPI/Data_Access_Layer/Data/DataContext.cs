using FootballManagerAPI.Controllers.Entities;
using FootballManagerDAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FootballManagerAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<FootballPlayer> FootballPlayers{ get; set; }
        public DbSet<Coach> CoachForTeam { get; set; }
        public DbSet<FootballTeam> FootballTeams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Coach>()
                .HasOne(c => c.FootballTeam)
                .WithOne(p => p.Coach)
                .HasForeignKey<FootballTeam>(b => b.CoachId);

            modelBuilder.Entity<FootballPlayer>()
                .HasOne<FootballTeam>(s => s.FootballTeam)
                .WithMany(g => g.Players)
                .HasForeignKey(s => s.TeamId);
        }
    }
}
