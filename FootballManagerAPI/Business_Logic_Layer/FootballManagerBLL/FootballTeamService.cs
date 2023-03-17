using FootballManagerBLL.Interfaces;
using FootballManagerDAL.Entities;
using FootballManagerDAL.Interfaces;

namespace FootballManagerBLL.FootballManagerBLL
{
    public class FootballTeamService : IFootballTeam
    {
        private readonly IFootballTeamRepository footballTeamRepository;

        public FootballTeamService(IFootballTeamRepository repository)
        {
            footballTeamRepository = repository;
        }

        public List<FootballTeam> Get()
        {
            return footballTeamRepository.Get();
        }

        public FootballTeam? GetById(int id)
        {
            return footballTeamRepository.GetById(id);
        }

        public FootballTeam? GetByTeamName(string name)
        {
            return footballTeamRepository.GetByTeamName(name);
        }

        public FootballTeam Add(FootballTeam team)
        {
            return footballTeamRepository.Add(team);
        }

        public FootballTeam? Update(FootballTeam request)
        {
            FootballTeam? team = footballTeamRepository.GetById(request.Id);

            if (team == null)
            {
                return null;
            }
            footballTeamRepository.Update(request);

            return request;
        }

        public FootballTeam? Delete(int id)
        {
            FootballTeam? team = footballTeamRepository.GetById(id);

            if (team == null)
            { 
                return null;
            }
            footballTeamRepository.Delete(team);

            return team;
        }
    }
}
