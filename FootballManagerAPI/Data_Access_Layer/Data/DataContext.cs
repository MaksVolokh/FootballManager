using FootballManagerAPI.Controllers.Entities;
using FootballManagerDAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace FootballManagerAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<FootballPlayer> FootballPlayers{ get; set; }
        public DbSet<Coach> CoachForTeam { get; set; }
        public DbSet<FootballTeam> FootballTeams { get; set; }
        public DbSet<FootballPlayerStatistics> PlayerStatistics { get; set; }
        public DbSet<FootballMatch> FootballMatches { get; set; }
        public DbSet<Media> Medias { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Entity<Coach>()
                .HasOne(c => c.FootballTeam)
                .WithOne(p => p.Coach)
                .HasForeignKey<FootballTeam>(b => b.CoachId);

            modelBuilder.Entity<FootballPlayer>()
                .HasOne(s => s.FootballTeam)
                .WithMany(g => g.Players)
                .HasForeignKey(s => s.TeamId);

            modelBuilder
                .Entity<FootballPlayerStatistics>()
                .HasOne(c => c.FootballPlayer)
                .WithOne()
                .HasForeignKey<FootballPlayerStatistics>(b => b.PlayerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FootballMatch>()
                .HasOne(m => m.Team)
                .WithOne()
                .HasForeignKey<FootballMatch>(s => s.TeamId);

            modelBuilder.Entity<Media>()
                .HasOne(m => m.FootballTeam)
                .WithOne()
                .HasForeignKey<FootballTeam>(s => s.MediaId);

        }
    }
}
