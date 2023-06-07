using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManagerDAL.Entities
{
    public class Media
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoUrl { get; set; }
        public string PhotoUrl { get; set; }

        // navigation properties
        public int FootballTeamId { get; set; }
        public FootballTeam FootballTeam { get; set; }
    }
}
