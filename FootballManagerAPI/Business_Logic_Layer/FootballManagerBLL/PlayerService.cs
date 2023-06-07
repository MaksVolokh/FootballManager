using FootballManagerAPI.Controllers.Entities;
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

        public async Task<List<FootballPlayer>> GetAsync()
        {
            return await _repository.GetAsync();
        }

        public async Task<FootballPlayer>? GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<FootballPlayer>> GetByFirstNameAsync(string firstName)
        {
            return await _repository.GetByFirstNameAsync(firstName);
        }

        public async Task<List<FootballPlayer>> GetByLastNameAsync(string lastName)
        {
            return await _repository.GetByLastNameAsync(lastName);
        }

        public async Task<FootballPlayer>? AddAsync(FootballPlayer player)
        {
            return await _repository.AddAsync(player);
        }

        public async Task<FootballPlayer>? UpdateAsync(FootballPlayer request)
        {
            FootballPlayer? player = await _repository.GetByIdAsync(request.Id);

            if (player == null)
            {
                return null;
            }

            return await _repository.UpdateAsync(request);
        }

        public async Task<FootballPlayer>? PatchUpdateAsync(FootballPlayer requestPatch)
        {
            FootballPlayer? player = await _repository.GetByIdAsync(requestPatch.Id);

            if (player == null)
            {
                return null;
            }

            return await _repository.PatchUpdateAsync(requestPatch);
        }

        public async Task<FootballPlayer>? DeleteAsync(int id)
        {
            FootballPlayer? player = await _repository.GetByIdAsync(id);

            if (player == null)
            {
                return null;
            }
            await _repository.DeleteAsync(player);

            return player;
        }
    }

}