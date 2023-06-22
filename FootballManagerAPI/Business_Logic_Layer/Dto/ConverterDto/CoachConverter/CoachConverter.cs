using FootballManagerBLL.Dto.RequestDto.Coach;
using FootballManagerBLL.Dto.ResponceDto.Coach;
using FootballManagerDAL.Entities;

namespace FootballManagerBLL.Dto.ConverterDto.CoachConverter
{
    public static class CoachConverter
    {
        public static Coach ConvertToEntity(CoachRequestDto requestDto)
        {
            return new Coach
            {
                FirstName = requestDto.FirstName,
                LastName = requestDto.LastName
            };
        }

        public static CoachResponseDto ConvertToResponseDto(Coach coach)
        {
            return new CoachResponseDto
            {
                Id = coach.Id,
                FirstName = coach.FirstName,
                LastName = coach.LastName
            };
        }

        public static void UpdateEntityFromRequest(Coach coach, CoachRequestDto requestDto)
        {
            coach.FirstName = requestDto.FirstName;
            coach.LastName = requestDto.LastName;
        }
    }
}
