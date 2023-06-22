using FootballManagerBLL.Dto.RequestDto.Match;
using FootballManagerBLL.Dto.ResponceDto.Match;
using FootballManagerDAL.Entities;


namespace FootballManagerBLL.Dto.ConverterDto.MatchConverter
{
    public static class MatchConverter
    {
        public static FootballMatchResponseDto ConvertToDto(FootballMatch match)
        {
            return new FootballMatchResponseDto
            {
                Id = match.Id,
                MatchDate = match.MatchDate,
                Location = match.Location
            };
        }

        public static FootballMatch ConvertToEntity(FootballMatchRequestDto dto)
        {
            return new FootballMatch
            {
                MatchDate = dto.MatchDate,
                Location = dto.Location
            };
        }

        public static void UpdateEntity(FootballMatch entity, FootballMatchRequestDto dto)
        {
            entity.MatchDate = dto.MatchDate;
            entity.Location = dto.Location;
        }
    }
}
