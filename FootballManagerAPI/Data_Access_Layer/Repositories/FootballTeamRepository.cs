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

        public List<FootballTeam> Get()
        {
            return dataContext.FootballTeams.ToList();
        }

        public FootballTeam? GetById(int id)
        {
            FootballTeam? team = dataContext.FootballTeams.AsNoTracking().FirstOrDefault(x => x.Id == id);

            if (team == null)
            {
                return null;
            }

            return team;
        }

        public FootballTeam? GetByTeamName(string teamName)
        {
            FootballTeam? team = dataContext.FootballTeams.FirstOrDefault(f => f.TeamName == teamName);

            return team;
        }

        public FootballTeam Add(FootballTeam team)
        {
            dataContext.FootballTeams.Add(team);
            dataContext.SaveChanges();

            return team;
        }

        public FootballTeam Update(FootballTeam request)
        {
            dataContext.FootballTeams.Update(request);
            dataContext.SaveChanges();

            return request;
        }

        public void Delete(FootballTeam team)
        {
            dataContext.FootballTeams.Remove(team);
            dataContext.SaveChanges();
        }
    }
}
