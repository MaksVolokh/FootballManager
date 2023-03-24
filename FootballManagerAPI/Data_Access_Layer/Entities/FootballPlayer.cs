using FootballManagerDAL.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballManagerAPI.Controllers.Entities
{
    public class FootballPlayer
    {
        public int Id { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public int Number { get; set; }

        // navigation properties
        [ForeignKey("FootballTeam")]
        public int? TeamId { get; set; }
        public FootballTeam FootballTeam { get; set; }

        public FootballPlayer(int id, string firstName, string lastName, int number)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Number = number;
        }
    }
}
