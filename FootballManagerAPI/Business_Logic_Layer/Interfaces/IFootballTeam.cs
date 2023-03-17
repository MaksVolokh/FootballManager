using FootballManagerDAL.Entities;
using FootballManagerDAL.Interfaces;

namespace FootballManagerBLL.Interfaces
{
    public interface IFootballTeam
    {
        List<FootballTeam> Get();
        FootballTeam? GetById(int id);
        FootballTeam? GetByTeamName(string name);
        FootballTeam? Add(FootballTeam team);
        FootballTeam? Update(FootballTeam request);
        FootballTeam? Delete(int id);
    }
}
