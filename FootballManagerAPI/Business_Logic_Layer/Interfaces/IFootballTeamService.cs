using FootballManagerBLL.Dto.RequestDto.FootballTeam;
using FootballManagerBLL.Dto.ResponceDto.FootballTeam;
using FootballManagerDAL.Entities;
using FootballManagerDAL.Interfaces;

namespace FootballManagerBLL.Interfaces
{
    public interface IFootballTeamService
    {
        Task<List<FootballTeamResponseDto>> GetAsync();
        Task<FootballTeamResponseDto>? GetByIdAsync(int id);
        Task<FootballTeamResponseDto>? GetTeamNameAsync(string name);
        Task<FootballTeamResponseDto>? AddAsync(FootballTeamRequestDto teamDto);
        Task<FootballTeamResponseDto>? UpdateAsync(int id, FootballTeamRequestDto request);
        Task<FootballTeamResponseDto>? DeleteAsync(int id);
    }
}
