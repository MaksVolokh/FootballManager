using FootballManagerAPI.Controllers.Entities;

namespace FootballManagerBLL.Interfaces
{
    public interface IPlayerService
    {
        Task<List<FootballPlayer>> GetAsync();
        Task<FootballPlayer>? GetByIdAsync(int id);
        Task<List<FootballPlayer>> GetByFirstNameAsync(string firstName);
        Task<List<FootballPlayer>> GetByLastNameAsync(string lastName);
        Task<FootballPlayer>? AddAsync(FootballPlayer player);
        Task<FootballPlayer>? UpdateAsync(FootballPlayer request);
        Task<FootballPlayer>? PatchUpdateAsync(FootballPlayer request);
        Task<FootballPlayer>? DeleteAsync(int id);
    }
}
