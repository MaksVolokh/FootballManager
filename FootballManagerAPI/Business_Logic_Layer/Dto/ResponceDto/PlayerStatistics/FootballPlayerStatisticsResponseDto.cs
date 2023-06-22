
namespace FootballManagerBLL.Dto.ResponceDto.PlayerStatistics
{
    public class FootballPlayerStatisticsResponseDto
    {
        public int Id { get; set; }
        public int MatchesPlayed { get; set; }
        public int GoalsScored { get; set; }
        public int Assists { get; set; }
        public int YellowCards { get; set; }
        public int RedCards { get; set; }
        public double AverageScoreByVote { get; set; }
    }
}
