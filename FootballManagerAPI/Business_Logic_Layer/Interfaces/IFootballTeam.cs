using FootballManagerDAL.Entities;
using FootballManagerDAL.Interfaces;

namespace FootballManagerBLL.Interfaces
{
    public interface IFootballTeam
    {
        Task<List<FootballTeam>> GetAsync();
        Task<FootballTeam>? GetByIdAsync(int id);
        Task<FootballTeam>? GetByTeamNameAsync(string name);
        Task<FootballTeam>? AddAsync(FootballTeam team);
        Task<FootballTeam>? UpdateAsync(FootballTeam request);
        Task<FootballTeam>? DeleteAsync(int id);
    }
}
