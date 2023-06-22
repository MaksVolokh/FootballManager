using FootballManagerAPI.Controllers.Entities;
using FootballManagerDAL.Entities;

namespace FootballManagerDAL.Interfaces
{
    public interface IFootballPlayerStatisticsRepository
    {
        Task<List<FootballPlayerStatistics>> GetAsync();
        Task<FootballPlayerStatistics> GetByIdAsync(int id);
        Task<FootballPlayerStatistics> CreateAsync(FootballPlayerStatistics playerStatistics);
        Task<FootballPlayerStatistics> UpdateAsync(FootballPlayerStatistics playerStatistics);
        Task DeleteAsync(FootballPlayerStatistics playerStatistics);
    }
}
