using FootballManagerAPI.Controllers.Entities;
using FootballManagerBLL.Dto.RequestDto.Player;
using FootballManagerBLL.Dto.ResponceDto.Player;

namespace FootballManagerBLL.Interfaces
{
    public interface IPlayerService
    {
        Task<List<FootballPlayerResponseDto>> GetAsync();
        Task<FootballPlayerResponseDto>? GetByIdAsync(int id);
        Task<List<FootballPlayerResponseDto>> GetByFirstNameAsync(string firstName);
        Task<List<FootballPlayerResponseDto>> GetByLastNameAsync(string lastName);
        Task<FootballPlayerResponseDto>? AddAsync(FootballPlayerRequestDto player);
        Task<FootballPlayerResponseDto>? UpdateAsync(int id, FootballPlayerRequestDto request);
        Task<FootballPlayerResponseDto>? PatchUpdateAsync(int id, FootballPlayerRequestDto request);
        Task<FootballPlayerResponseDto>? DeleteAsync(int id);
        Task<bool> IsPlayerNumberAvailable(int number);
    }
}
