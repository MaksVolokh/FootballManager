using FootballManagerAPI.Controllers.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FootballManagerDAL.Entities
{
    public class FootballPlayerStatistics
    {
        [Key]
        public int Id { get; set; }
        public int MatchesPlayed { get; set; } = 0;
        public int GoalsScored { get; set; } = 0;
        public int Assists { get; set; } = 0;
        public int YellowCards { get; set; } = 0;
        public int RedCards { get; set; } = 0;
        public double AverageScoreByVote { get; set; } = 0;


        [ForeignKey("FootballPlayer")]
        public int PlayerId { get; set; }
        public FootballPlayer FootballPlayer { get; set; }

        public FootballPlayerStatistics() { }
        public FootballPlayerStatistics(int id, int matchesPlayed, int goalsScored, int assists, 
            int yellowCards, int redCards, double averageScoreByNote)
        {
            Id = id;
            MatchesPlayed = matchesPlayed;
            GoalsScored = goalsScored;
            Assists = assists;
            YellowCards = yellowCards;
            RedCards = redCards;
            AverageScoreByVote = averageScoreByNote;
        }
        
    }
}
