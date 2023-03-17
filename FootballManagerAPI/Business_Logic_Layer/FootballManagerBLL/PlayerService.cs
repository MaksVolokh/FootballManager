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

        public List<FootballPlayer> Get()
        {
            return _repository.Get();
        }

        public FootballPlayer? GetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<FootballPlayer> GetByFirstName(string firstName)
        {
            return _repository.GetByFirstName(firstName);
        }

        public List<FootballPlayer> GetByLastName(string lastName)
        {
            return _repository.GetByLastName(lastName);
        }

        public FootballPlayer? Add(FootballPlayer player)
        {
            return _repository.Add(player);
        }

        public FootballPlayer? Update(FootballPlayer request)
        {
            FootballPlayer? player = _repository.GetById(request.Id);

            if (player == null)
            {
                return null;
            }

            return _repository.Update(request);
        }

        public FootballPlayer? PatchUpdate(FootballPlayer requestPatch)
        {
            FootballPlayer? player = _repository.GetById(requestPatch.Id);

            if (player == null)
            {
                return null;
            }

            return _repository.PatchUpdate(requestPatch);
        }

        public FootballPlayer? Delete(int id)
        {
            FootballPlayer? player = _repository.GetById(id);

            if (player == null)
            {
                return null;
            }
            _repository.Delete(player);

            return player;
        }
    }

}