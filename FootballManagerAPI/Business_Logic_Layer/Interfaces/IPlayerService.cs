using FootballManagerAPI.Controllers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManagerBLL.Interfaces
{
    public interface IPlayerService
    {
        List<FootballPlayer> Get();
        FootballPlayer? GetPlayerById(int id);
        List<FootballPlayer> GetPlayerByFirstName(string firstName);
        List<FootballPlayer> GetPlayerByLastName(string lastName);
        FootballPlayer? AddFootballPlayer(FootballPlayer player);
        FootballPlayer? UpdatePlayer(FootballPlayer request);
        FootballPlayer? PatchUpdate(FootballPlayer request);
        public void Delete(int id);
    }
}
