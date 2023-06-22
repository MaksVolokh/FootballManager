using FootballManagerBLL.Dto.RequestDto.Coach;
using FootballManagerBLL.Dto.ResponceDto.Coach;
using FootballManagerDAL.Entities;

namespace FootballManagerBLL.Interfaces
{
    public interface ICoachService
    {
        Task<List<CoachResponseDto>> GetAsync();
        Task<CoachResponseDto>? GetByIdAsync(int id);
        Task<CoachResponseDto>? GetByFirstNameAsync(string firstName);
        Task<CoachResponseDto>? GetByLastNameAsync(string lastName);
        Task<CoachResponseDto>? AddAsync(CoachRequestDto coach);
        Task<CoachResponseDto>? UpdateAsync(int id, CoachRequestDto request);
        Task<CoachResponseDto>? PatchUpdateAsync(int id, CoachRequestDto requestPatch);
        Task<CoachResponseDto>? DeleteAsync(int id);
    }
}
