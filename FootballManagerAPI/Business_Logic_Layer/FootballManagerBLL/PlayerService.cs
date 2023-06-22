using FootballManagerBLL.Dto.ConverterDto.FootballPlayerConverter;
using FootballManagerBLL.Dto.RequestDto.Player;
using FootballManagerBLL.Dto.ResponceDto.Player;
using FootballManagerBLL.Interfaces;
using FootballManagerDAL.Interfaces;

namespace FootballManagerBLL.FootballManagerBLL
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayersRepository _repository;

        public PlayerService(IPlayersRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<FootballPlayerResponseDto>> GetAsync()
        {
            var players = await _repository.GetAsync();

            return players.Select(FootballPlayerConverter.ConvertToDto).ToList();
        }

        public async Task<FootballPlayerResponseDto>? GetByIdAsync(int id)
        {
            var player = await _repository.GetByIdAsync(id);

            return FootballPlayerConverter.ConvertToDto(player);
        }

        public async Task<List<FootballPlayerResponseDto>> GetByFirstNameAsync(string firstName)
        {
            var players = await _repository.GetByFirstNameAsync(firstName);

            return players.Select(FootballPlayerConverter.ConvertToDto).ToList();
        }

        public async Task<List<FootballPlayerResponseDto>> GetByLastNameAsync(string lastName)
        {
            var players = await _repository.GetByLastNameAsync(lastName);

            return players.Select(FootballPlayerConverter.ConvertToDto).ToList();
        }

        public async Task<FootballPlayerResponseDto>? AddAsync(FootballPlayerRequestDto requestDto)
        {
            var player = FootballPlayerConverter.ConvertToEntity(requestDto);

            var addPlayer = await _repository.AddAsync(player);

            return FootballPlayerConverter.ConvertToDto(addPlayer);
        }

        public async Task<FootballPlayerResponseDto>? UpdateAsync(int id, FootballPlayerRequestDto requestDto)
        {
            var player = await _repository.GetByIdAsync(id);

            if (player == null)
            {
                return null;
            }

            FootballPlayerConverter.UpdateEntityFromRequest(player, requestDto);

            var updatedPlayer = await _repository.UpdateAsync(player);

            return FootballPlayerConverter.ConvertToDto(updatedPlayer);
        }

        public async Task<FootballPlayerResponseDto>? PatchUpdateAsync(int id, FootballPlayerRequestDto requestDto)
        {
            var player = await _repository.GetByIdAsync(id);

            if (player == null)
            {
                return null;
            }

            FootballPlayerConverter.UpdateEntityFromRequest(player, requestDto);

            var patchedPlayer = await _repository.PatchUpdateAsync(player);

            return FootballPlayerConverter.ConvertToDto(patchedPlayer);
        }

        public async Task<FootballPlayerResponseDto>? DeleteAsync(int id)
        {
            var player = await _repository.GetByIdAsync(id);

            if (player == null)
            {
                return null;
            }

            await _repository.DeleteAsync(player);

            return FootballPlayerConverter.ConvertToDto(player);
        }

        public async Task<bool> IsPlayerNumberAvailable(int number)
        {
            var playerNumber = await _repository.GetPlayerByNumberAsync(number);

            return playerNumber == null;
        }
    }

}