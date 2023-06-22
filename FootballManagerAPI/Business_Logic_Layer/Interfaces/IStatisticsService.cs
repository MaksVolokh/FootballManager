using FootballManagerBLL.Dto;
using FootballManagerBLL.Dto.ResponceDto.PlayerStatistics;
using FootballManagerDAL.Entities;

namespace FootballManagerBLL.Interfaces
{
    public interface IStatisticsService
    {
        Task<List<FootballPlayerStatisticsResponseDto>> GetAsync();
        Task<FootballPlayerStatisticsResponseDto>? GetByIdAsync(int id);
        Task<FootballPlayerStatisticsResponseDto>? CreateAsync(FootballPlayerStatisticsRequestDto playerStatistics);
        Task<FootballPlayerStatisticsResponseDto>? UpdateAsync(int id, FootballPlayerStatisticsRequestDto playerStatistics);
        Task<FootballPlayerStatisticsResponseDto>? DeleteAsync(int id);
    }
}
