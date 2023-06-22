using FootballManagerAPI.Data;
using FootballManagerDAL.Entities;
using FootballManagerDAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FootballManagerDAL.Repositories
{
    public class FootballTeamRepository : IFootballTeamRepository
    {
        private readonly DataContext dataContext;

        public FootballTeamRepository(DataContext context)
        {
            dataContext = context;
        }

        public async Task<List<FootballTeam>> GetAsync()
        {
            return await dataContext.FootballTeams.Include(s => s.Coach).ToListAsync();
        }

        public async Task<FootballTeam> GetByIdAsync(int id)
        {
            FootballTeam team = await dataContext.FootballTeams.Include(s => s.Coach)
                .AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (team == null)
            {
                return null;
            }

            return team;
        }

        public async Task<FootballTeam> GetTeamNameAsync(string teamName)
        {
            FootballTeam team = await dataContext.FootballTeams.Include(s => s.Coach)
                .FirstOrDefaultAsync(f => f.TeamName == teamName);

            return team;
        }

        public async Task<FootballTeam> AddAsync(FootballTeam team)
        {
            dataContext.FootballTeams.Add(team);
            await dataContext.SaveChangesAsync();

            return team;
        }

        public async Task<FootballTeam> UpdateAsync(FootballTeam request)
        {
            dataContext.FootballTeams.Update(request);
            await dataContext.SaveChangesAsync();

            return request;
        }

        public async Task DeleteAsync(FootballTeam team)
        {
            dataContext.FootballTeams.Remove(team);
            await dataContext.SaveChangesAsync();
        }
    }
}
