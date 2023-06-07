using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManagerDAL.Entities
{
    public class FootballMatch
    {
        public int Id { get; set; }
        public DateTime MatchDate { get; set; }
        public string Location { get; set; }

        // navigation properties
        public int TeamId { get; set; }
        public FootballTeam Team { get; set; }
    }
}
