using FootballManagerDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManagerDAL.Interfaces
{
    public interface IFootballMatchRepository
    {
        Task<List<FootballMatch>> GetAsync();
        Task<FootballMatch> GetByIdAsync(int id);
        Task<FootballMatch> CreateAsync(FootballMatch match);
        Task<FootballMatch> UpdateAsync(FootballMatch match);
        Task DeleteAsync(FootballMatch match);
    }
}
