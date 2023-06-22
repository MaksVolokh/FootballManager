using FootballManagerDAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using FootballManagerDAL.Entities;
using FootballManagerAPI.Data;

namespace FootballManagerDAL.Repositories
{
    public class FootballPlayerStatisticsRepository : IFootballPlayerStatisticsRepository
    {
        private readonly DataContext _dbContext;
        public FootballPlayerStatisticsRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<FootballPlayerStatistics>> GetAsync()
        {
            return await _dbContext.PlayerStatistics.Include(s => s.FootballPlayer).ToListAsync();
        }
        public async Task<FootballPlayerStatistics> GetByIdAsync(int id)
        {
            FootballPlayerStatistics statistics = await _dbContext.PlayerStatistics.Include(s => s.FootballPlayer)
                .AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (statistics == null)
            {
                return null;
            }

            return statistics;
        }
        public async Task<FootballPlayerStatistics> CreateAsync(FootballPlayerStatistics playerStatistics)
        {
            _dbContext.PlayerStatistics.Add(playerStatistics);
            await _dbContext.SaveChangesAsync();

            return playerStatistics;
        }
        public async Task<FootballPlayerStatistics> UpdateAsync(FootballPlayerStatistics playerStatistics)
        {
            _dbContext.PlayerStatistics.Update(playerStatistics);
            await _dbContext.SaveChangesAsync();

            return playerStatistics;
        }
        public async Task DeleteAsync(FootballPlayerStatistics playerStatistics)
        {
            _dbContext.PlayerStatistics.Remove(playerStatistics);
            await _dbContext.SaveChangesAsync();
        }
    }
}
