using FootballManagerBLL.Dto.ConverterDto.MatchConverter;
using FootballManagerBLL.Dto.RequestDto.Match;
using FootballManagerBLL.Dto.ResponceDto.Match;
using FootballManagerBLL.Interfaces;
using FootballManagerDAL.Interfaces;

namespace FootballManagerBLL.FootballManagerBLL
{
    public class MatchService : IMatchService
    {
        private readonly IFootballMatchRepository _repository;
        public MatchService(IFootballMatchRepository repository) 
        { 
            _repository = repository;
        }

        public async Task<List<FootballMatchResponseDto>> GetAsync()
        {
            var matches = await _repository.GetAsync();
            return matches.Select(MatchConverter.ConvertToDto).ToList();
        }

        public async Task<FootballMatchResponseDto> GetByIdAsync(int id)
        {
            var match = await _repository.GetByIdAsync(id);

            if (match == null)
            {
                return null;
            }

            return MatchConverter.ConvertToDto(match);
        }

        public async Task<FootballMatchResponseDto> CreateAsync(FootballMatchRequestDto matchDto)
        {
            var match = MatchConverter.ConvertToEntity(matchDto);

            var addedMatch = await _repository.CreateAsync(match);

            return MatchConverter.ConvertToDto(addedMatch);
        }

        public async Task<FootballMatchResponseDto> UpdateAsync(int id, FootballMatchRequestDto matchDto)
        {
            var match = await _repository.GetByIdAsync(id);

            if (match == null)
            {
                return null;
            }

            MatchConverter.UpdateEntity(match, matchDto);

            var updatedMatch = await _repository.UpdateAsync(match);

            return MatchConverter.ConvertToDto(updatedMatch);
        }

        public async Task<FootballMatchResponseDto> DeleteAsync(int id)
        {
            var match = await _repository.GetByIdAsync(id);

            if (match == null)
            {
                return null;
            }

            await _repository.DeleteAsync(match);

            return MatchConverter.ConvertToDto(match);
        }
    }
}
