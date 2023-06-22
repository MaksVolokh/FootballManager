using FootballManagerBLL.Dto.ConverterDto.CoachConverter;
using FootballManagerBLL.Dto.RequestDto.Coach;
using FootballManagerBLL.Dto.ResponceDto.Coach;
using FootballManagerBLL.Interfaces;
using FootballManagerDAL.Interfaces;


namespace FootballManagerBLL.FootballManagerBLL
{
    public class CoachService : ICoachService
    {
        private readonly ICoachRepository _coachRepository;

        public CoachService(ICoachRepository coachRepository)
        {
            _coachRepository = coachRepository;
        }

        public async Task<List<CoachResponseDto>> GetAsync()
        {
            var coaches = await _coachRepository.GetAsync();

            return coaches.Select(CoachConverter.ConvertToResponseDto).ToList();
        }
        public async Task<CoachResponseDto>? GetByIdAsync(int id)
        {
            var coach = await _coachRepository.GetByIdAsync(id);

            return CoachConverter.ConvertToResponseDto(coach);
        }
    
        public async Task<CoachResponseDto>? GetByFirstNameAsync(string firstName)
        {
            var coach = await _coachRepository.GetByFirstNameAsync(firstName);

            return CoachConverter.ConvertToResponseDto(coach);
        }
        public async Task<CoachResponseDto>? GetByLastNameAsync(string lastName)
        {
            var coach = await _coachRepository.GetByFirstNameAsync(lastName);

            return CoachConverter.ConvertToResponseDto(coach);
        }
        public async Task<CoachResponseDto>? AddAsync(CoachRequestDto coach)
        {
            var newcoach = CoachConverter.ConvertToEntity(coach);

            var addedCoach = await _coachRepository.AddAsync(newcoach);

            return CoachConverter.ConvertToResponseDto(addedCoach);
        }
        public async Task<CoachResponseDto>? UpdateAsync(int id, CoachRequestDto request)
        {
            var coach = await _coachRepository.GetByIdAsync(id);

            if (coach == null)
            {
                return null;
            }

            CoachConverter.UpdateEntityFromRequest(coach, request);

            var updatedPlayer = await _coachRepository.UpdateAsync(coach);

            return CoachConverter.ConvertToResponseDto(updatedPlayer);
        }

        public async Task<CoachResponseDto>? PatchUpdateAsync(int id, CoachRequestDto requestPatch)
        {
            var coach = await _coachRepository.GetByIdAsync(id);

            if (coach == null)
            {
                return null;
            }

            CoachConverter.UpdateEntityFromRequest(coach, requestPatch);

            var patchedCoach = await _coachRepository.PatchUpdateAsync(coach);

            return CoachConverter.ConvertToResponseDto(patchedCoach);
        }
        public async Task<CoachResponseDto>? DeleteAsync(int id)
        {
            var coach = await _coachRepository.GetByIdAsync(id);

            if (coach == null)
            {
                return null;
            }
            await _coachRepository.DeleteAsync(coach);

            return CoachConverter.ConvertToResponseDto(coach);
        }
    }
}
