using FootballManagerBLL.Dto.RequestDto.Match;
using FootballManagerBLL.Dto.ResponceDto.Match;
using FootballManagerDAL.Entities;

namespace FootballManagerBLL.Interfaces
{
    public interface IMatchService
    {
        Task<List<FootballMatchResponseDto>> GetAsync();
        Task<FootballMatchResponseDto> GetByIdAsync(int id);
        Task<FootballMatchResponseDto> CreateAsync(FootballMatchRequestDto match);
        Task<FootballMatchResponseDto> UpdateAsync(int id, FootballMatchRequestDto match);
        Task<FootballMatchResponseDto> DeleteAsync(int id);
    }
}
