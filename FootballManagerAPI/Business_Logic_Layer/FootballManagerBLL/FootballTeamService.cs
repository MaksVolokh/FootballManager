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

        public async Task<List<FootballTeam>> GetAsync()
        {
            return await footballTeamRepository.GetAsync();
        }

        public async Task<FootballTeam>? GetByIdAsync(int id)
        {
            return await footballTeamRepository.GetByIdAsync(id);
        }

        public async Task<FootballTeam>? GetByTeamNameAsync(string name)
        {
            return await footballTeamRepository.GetByTeamNameAsync(name);
        }

        public async Task<FootballTeam> AddAsync(FootballTeam team)
        {
            return await footballTeamRepository.AddAsync(team);
        }

        public async Task<FootballTeam>? UpdateAsync(FootballTeam request)
        {
            FootballTeam? team = await footballTeamRepository.GetByIdAsync(request.Id);

            if (team == null)
            {
                return null;
            }
            await footballTeamRepository.UpdateAsync(request);

            return request;
        }

        public async Task<FootballTeam>? DeleteAsync(int id)
        {
            FootballTeam? team = await footballTeamRepository.GetByIdAsync(id);

            if (team == null)
            { 
                return null;
            }
            await footballTeamRepository.DeleteAsync(team);

            return team;
        }
    }
}
