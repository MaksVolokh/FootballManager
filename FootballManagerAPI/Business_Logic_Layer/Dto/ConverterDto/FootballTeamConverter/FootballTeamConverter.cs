using FootballManagerBLL.Dto.RequestDto.FootballTeam;
using FootballManagerBLL.Dto.ResponceDto.FootballTeam;
using FootballManagerDAL.Entities;

namespace FootballManagerBLL.Dto.ConverterDto.FootballTeamConverter
{
    public static class FootballTeamConverter
    {
        public static FootballTeamResponseDto ConvertToDto(FootballTeam team)
        {
            return new FootballTeamResponseDto
            {
                Id = team.Id,
                TeamName = team.TeamName
            };
        }

        public static FootballTeam ConvertToEntity(FootballTeamRequestDto dto)
        {
            return new FootballTeam
            {
                TeamName = dto.TeamName
            };
        }

        public static void UpdateEntity(FootballTeam team, FootballTeamRequestDto dto)
        {
            team.TeamName = dto.TeamName;
        }
    }
}
