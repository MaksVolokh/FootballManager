using FootballManagerBLL.Dto.ResponceDto.PlayerStatistics;
using FootballManagerDAL.Entities;


namespace FootballManagerBLL.Dto.ConverterDto.FootballPlayerStatisticsConverter
{
    public static class FootballPlayerStatisticsConverter
    {
        public static FootballPlayerStatisticsResponseDto ConvertToResponseDto(FootballPlayerStatistics statistics)
        {
            return new FootballPlayerStatisticsResponseDto
            {
                Id = statistics.Id,
                MatchesPlayed = statistics.MatchesPlayed,
                GoalsScored = statistics.GoalsScored,
                Assists = statistics.Assists,
                YellowCards = statistics.YellowCards,
                RedCards = statistics.RedCards,
                AverageScoreByVote = statistics.AverageScoreByVote
            };
        }

        public static FootballPlayerStatistics ConvertToEntity(FootballPlayerStatisticsRequestDto requestDto)
        {
            return new FootballPlayerStatistics
            {
                MatchesPlayed = requestDto.MatchesPlayed,
                GoalsScored = requestDto.GoalsScored,
                Assists = requestDto.Assists,
                YellowCards = requestDto.YellowCards,
                RedCards = requestDto.RedCards,
                AverageScoreByVote = requestDto.AverageScoreByVote
            };
        }

        public static void UpdateEntityFromRequest(FootballPlayerStatistics entity, FootballPlayerStatisticsRequestDto requestDto)
        {
            entity.MatchesPlayed = requestDto.MatchesPlayed;
            entity.GoalsScored = requestDto.GoalsScored;
            entity.Assists = requestDto.Assists;
            entity.YellowCards = requestDto.YellowCards;
            entity.RedCards = requestDto.RedCards;
            entity.AverageScoreByVote = requestDto.AverageScoreByVote;
        }
    }
}
