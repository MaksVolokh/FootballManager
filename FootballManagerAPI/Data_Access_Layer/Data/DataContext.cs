using FootballManagerAPI.Controllers.Entities;
using Microsoft.EntityFrameworkCore;

namespace FootballManagerAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<FootballPlayer> FootballPlayers{ get; set; }
    }
}
