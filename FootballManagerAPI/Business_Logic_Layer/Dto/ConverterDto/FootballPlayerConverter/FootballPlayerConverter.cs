using FootballManagerAPI.Controllers.Entities;
using FootballManagerBLL.Dto.RequestDto.Player;
using FootballManagerBLL.Dto.ResponceDto.Player;


namespace FootballManagerBLL.Dto.ConverterDto.FootballPlayerConverter
{
    public class FootballPlayerConverter
    {
        public static FootballPlayer ConvertToEntity(FootballPlayerRequestDto requestDto)
        {
            return new FootballPlayer
            {
                FirstName = requestDto.FirstName,
                LastName = requestDto.LastName,
                Number = requestDto.Number
            };
        }

        public static FootballPlayerResponseDto ConvertToDto(FootballPlayer player)
        {
            return new FootballPlayerResponseDto
            {
                Id = player.Id,
                FirstName = player.FirstName,
                LastName = player.LastName,
                Number = player.Number
            };
        }

        public static void UpdateEntityFromRequest(FootballPlayer player, FootballPlayerRequestDto requestDto)
        {
            player.FirstName = requestDto.FirstName;
            player.LastName = requestDto.LastName;
            player.Number = requestDto.Number;
        }
    }
}
