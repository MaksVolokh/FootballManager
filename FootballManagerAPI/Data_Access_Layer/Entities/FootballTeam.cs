using FootballManagerAPI.Controllers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManagerDAL.Entities
{
    public class FootballTeam
    {
        public List<FootballPlayer> footballPlayers = new List<FootballPlayer>();
        public List<FootballPlayer> benchPlayers = new List<FootballPlayer>();
        public string TeamName { get; set; } = String.Empty;
        public int Id { get; set; }
    }
}
