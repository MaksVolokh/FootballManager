using FootballManagerAPI.Controllers.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballManagerDAL.Entities
{
    public class FootballTeam
    {
        public int Id { get; set; }
        public string TeamName { get; set; }

        // navigation properties
        [ForeignKey("Coach")]
        public int? CoachId { get; set; }
        public Coach Coach { get; set; }

        public ICollection<FootballPlayer> Players { get; set; }
        public FootballMatch Match { get; set; }
    }
}
