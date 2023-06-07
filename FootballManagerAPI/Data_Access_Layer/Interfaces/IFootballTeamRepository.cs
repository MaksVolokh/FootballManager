using FootballManagerAPI.Controllers.Entities;
using FootballManagerDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManagerDAL.Interfaces
{
    public interface IFootballTeamRepository
    {
        Task<List<FootballTeam>> GetAsync();
        Task<FootballTeam> GetByIdAsync(int id);
        Task<FootballTeam> GetByTeamNameAsync(string name);
        Task<FootballTeam> AddAsync(FootballTeam team);
        Task<FootballTeam> UpdateAsync(FootballTeam request);
        Task DeleteAsync(FootballTeam team);

    }
}
