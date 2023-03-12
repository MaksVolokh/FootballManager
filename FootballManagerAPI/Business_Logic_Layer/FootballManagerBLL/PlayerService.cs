using FootballManagerAPI.Controllers.Entities;
using FootballManagerBLL.Interfaces;
using FootballManagerDAL.Interfaces;
using Microsoft.AspNetCore.Mvc;


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

        public FootballPlayer? GetPlayerById(int id)
        {
            return _repository.GetPlayerById(id);
        }

        public List<FootballPlayer> GetPlayerByFirstName(string firstName)
        {
            return _repository.GetPlayerByFirstName(firstName);
        }

        public List<FootballPlayer> GetPlayerByLastName(string lastName)
        {
            return _repository.GetPlayerByLastName(lastName);
        }

        public FootballPlayer? AddFootballPlayer(FootballPlayer player)
        {
            return _repository.AddFootballPlayer(player);
        }

        public FootballPlayer? UpdatePlayer(FootballPlayer request)
        {
            return _repository.UpdatePlayer(request);
        }

        public FootballPlayer? PatchUpdate(FootballPlayer requestPatch)
        {
            return _repository.PatchUpdate(requestPatch);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }

}