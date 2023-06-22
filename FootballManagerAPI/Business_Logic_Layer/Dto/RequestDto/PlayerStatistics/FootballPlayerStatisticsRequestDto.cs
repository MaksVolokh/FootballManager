using System.ComponentModel.DataAnnotations;

namespace FootballManagerBLL.Dto.ResponceDto.PlayerStatistics
{
    public class FootballPlayerStatisticsRequestDto
    {
        [Range(0, int.MaxValue, ErrorMessage = "Matches played must be a positive number.")]
        public int MatchesPlayed { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Goals scored must be a positive number.")]
        public int GoalsScored { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Assists must be a positive number.")]
        public int Assists { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Yellow cards must be a positive number.")]
        public int YellowCards { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Red cards must be a positive number.")]
        public int RedCards { get; set; }

        [Range(0, 10, ErrorMessage = "Average score by vote must be a number between 0 and 10.")]
        public double AverageScoreByVote { get; set; }
    }
}
