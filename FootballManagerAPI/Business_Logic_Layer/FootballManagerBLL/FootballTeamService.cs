using FootballManagerBLL.Dto.ConverterDto.FootballTeamConverter;
using FootballManagerBLL.Dto.RequestDto.FootballTeam;
using FootballManagerBLL.Dto.ResponceDto.FootballTeam;
using FootballManagerBLL.Interfaces;
using FootballManagerDAL.Interfaces;

namespace FootballManagerBLL.FootballManagerBLL
{
    public class FootballTeamService : IFootballTeamService
    {
        private readonly IFootballTeamRepository _repository;

        public FootballTeamService(IFootballTeamRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<FootballTeamResponseDto>> GetAsync()
        {
            var teams = await _repository.GetAsync();

            return teams.Select(FootballTeamConverter.ConvertToDto).ToList();
        }

        public async Task<FootballTeamResponseDto>? GetByIdAsync(int id)
        {
            var team = await _repository.GetByIdAsync(id);

            return FootballTeamConverter.ConvertToDto(team);
        }

        public async Task<FootballTeamResponseDto>? GetTeamNameAsync(string name)
        {
            var team = await _repository.GetTeamNameAsync(name);

            return FootballTeamConverter.ConvertToDto(team);
        }

        public async Task<FootballTeamResponseDto> AddAsync(FootballTeamRequestDto teamDto)
        {
            var team = FootballTeamConverter.ConvertToEntity(teamDto);

            var addedTeam = await _repository.AddAsync(team);

            return FootballTeamConverter.ConvertToDto(addedTeam);
        }

        public async Task<FootballTeamResponseDto>? UpdateAsync(int id, FootballTeamRequestDto request)
        {
            var team = await _repository.GetByIdAsync(id);

            if (team == null)
            {
                return null;
            }

            FootballTeamConverter.UpdateEntity(team, request);

            var updatedTeam = await _repository.UpdateAsync(team);

            return FootballTeamConverter.ConvertToDto(updatedTeam);
        }

        public async Task<FootballTeamResponseDto>? DeleteAsync(int id)
        {
            var team = await _repository.GetByIdAsync(id);

            if (team == null)
            {
                return null;
            }

            await _repository.DeleteAsync(team);

            return FootballTeamConverter.ConvertToDto(team);
        }
    }
}
