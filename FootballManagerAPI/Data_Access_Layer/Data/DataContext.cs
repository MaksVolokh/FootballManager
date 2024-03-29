﻿using FootballManagerAPI.Controllers.Entities;
using FootballManagerBLL.Dto;
using FootballManagerDAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;



namespace FootballManagerAPI.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext(){ }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<FootballPlayer> FootballPlayers{ get; set; }
        public DbSet<Coach> CoachForTeam { get; set; }
        public DbSet<FootballTeam> FootballTeams { get; set; }
        public DbSet<FootballPlayerStatistics> PlayerStatistics { get; set; }
        public DbSet<FootballMatch> FootballMatches { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ChatUser> ChatUsers { get; set; }

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

            modelBuilder.Entity<ChatUser>()
                .HasKey(x => new { x.ChatId, x.UserId });

        }
    }
}
