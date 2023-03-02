using FootballManagerAPI.Controllers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManagerDAL.Interfaces
{
    public interface IPlayersRepository
    {
        List<FootballPlayer> Get();
        FootballPlayer GetPlayerById(int id);
        FootballPlayer GetPlayerByFirstName(string firstName);
        FootballPlayer GetPlayerByLastName(string lastName);
        FootballPlayer AddFootballPlayer(FootballPlayer player);
        FootballPlayer Update(FootballPlayer request);
        void Delete(int id);
    }
}
