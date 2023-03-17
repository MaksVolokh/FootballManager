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
        List<FootballTeam> Get();
        FootballTeam? GetById(int id);
        FootballTeam? GetByTeamName(string name);
        FootballTeam Add(FootballTeam team);
        FootballTeam Update(FootballTeam request);
        void Delete(FootballTeam team);

    }
}
