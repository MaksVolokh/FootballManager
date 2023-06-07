using FootballManagerDAL.Entities;

namespace FootballManagerBLL.Interfaces
{
    public interface ICoachService
    {
        Task<List<Coach>> GetAsync();
        Task<Coach>? GetByIdAsync(int id);
        Task<Coach>? GetByFirstNameAsync(string firstName);
        Task<Coach>? GetByLastNameAsync(string lastName);
        Task<Coach>? AddAsync(Coach coach);
        Task<Coach>? UpdateAsync(Coach request);
        Task<Coach>? PatchUpdateAsync(Coach requestPatch);
        Task<Coach>? DeleteAsync(int id);
    }
}
