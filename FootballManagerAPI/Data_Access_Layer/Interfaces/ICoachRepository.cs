using FootballManagerDAL.Entities;
namespace FootballManagerDAL.Interfaces
{
    public interface ICoachRepository
    {
        Task<List<Coach>> GetAsync();
        Task<Coach> GetByIdAsync(int id);
        Task<Coach> GetByFirstNameAsync(string firstName);
        Task<Coach> GetByLastNameAsync(string lastName);
        Task<Coach> AddAsync(Coach coach);
        Task<Coach> UpdateAsync(Coach request);
        Task<Coach> PatchUpdateAsync(Coach requestPatch);
        Task DeleteAsync(Coach coach);
    }
}
