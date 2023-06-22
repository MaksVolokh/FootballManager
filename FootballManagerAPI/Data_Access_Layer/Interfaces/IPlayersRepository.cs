using FootballManagerAPI.Controllers.Entities;

namespace FootballManagerDAL.Interfaces
{
    public interface IPlayersRepository
    {
        Task<List<FootballPlayer>> GetAsync();
        Task<FootballPlayer> GetByIdAsync(int id);
        Task<List<FootballPlayer>> GetByFirstNameAsync(string firstName);
        Task<List<FootballPlayer>> GetByLastNameAsync(string lastName);
        Task<FootballPlayer> AddAsync(FootballPlayer player);
        Task<FootballPlayer> UpdateAsync(FootballPlayer request);
        Task<FootballPlayer> PatchUpdateAsync(FootballPlayer request); 
        Task DeleteAsync(FootballPlayer player);
        Task<FootballPlayer> GetPlayerByNumberAsync(int number);
    }
}
