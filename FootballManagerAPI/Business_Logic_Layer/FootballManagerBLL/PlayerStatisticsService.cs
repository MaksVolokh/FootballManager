using FootballManagerBLL.Dto.ConverterDto.FootballPlayerStatisticsConverter;
using FootballManagerBLL.Dto.ResponceDto.PlayerStatistics;
using FootballManagerBLL.Interfaces;
using FootballManagerDAL.Interfaces;

namespace FootballManagerBLL.FootballManagerBLL
{
    public class PlayerStatisticsService : IStatisticsService
    {
        private readonly IFootballPlayerStatisticsRepository _repository;
        public PlayerStatisticsService(IFootballPlayerStatisticsRepository repository)
        {
            _repository = repository;       
        }

        public async Task<List<FootballPlayerStatisticsResponseDto>> GetAsync()
        {
            var players = await _repository.GetAsync();

            return players.Select(FootballPlayerStatisticsConverter.ConvertToResponseDto).ToList();
        }
        public async Task<FootballPlayerStatisticsResponseDto>? GetByIdAsync(int id)
        {
            var statistics = await _repository.GetByIdAsync(id);

            if (statistics == null)
            {
                return null;
            }

            return FootballPlayerStatisticsConverter.ConvertToResponseDto(statistics);
        }

        public async Task<FootballPlayerStatisticsResponseDto>? CreateAsync(FootballPlayerStatisticsRequestDto requestDto)
        {
            var playerStatistics = FootballPlayerStatisticsConverter.ConvertToEntity(requestDto);

            var addedPlayerStatistics = await _repository.CreateAsync(playerStatistics);

            return FootballPlayerStatisticsConverter.ConvertToResponseDto(addedPlayerStatistics);
        }

        public async Task<FootballPlayerStatisticsResponseDto>? UpdateAsync(int id, FootballPlayerStatisticsRequestDto requestDto)
        {
            var playerStatistics = await _repository.GetByIdAsync(id);

            if (playerStatistics == null)
            {
                return null;
            }

            FootballPlayerStatisticsConverter.UpdateEntityFromRequest(playerStatistics, requestDto);

            var updatedPlayerStatistics = await _repository.UpdateAsync(playerStatistics);

            return FootballPlayerStatisticsConverter.ConvertToResponseDto(updatedPlayerStatistics);
        }

        public async Task<FootballPlayerStatisticsResponseDto>? DeleteAsync(int id)
        {
            var playerStatistics = await _repository.GetByIdAsync(id);

            if (playerStatistics == null)
            {
                return null;
            }

            await _repository.DeleteAsync(playerStatistics);

            return FootballPlayerStatisticsConverter.ConvertToResponseDto(playerStatistics);
        }
    }
}
