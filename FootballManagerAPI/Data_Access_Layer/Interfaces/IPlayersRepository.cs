using FootballManagerAPI.Controllers.Entities;

namespace FootballManagerDAL.Interfaces
{
    public interface IPlayersRepository
    {
        List<FootballPlayer> Get();
        FootballPlayer? GetPlayerById(int id);
        List<FootballPlayer> GetPlayersByFirstName(string firstName);
        List<FootballPlayer> GetPlayersByLastName(string lastName);
        FootballPlayer? AddFootballPlayer(FootballPlayer player);
        FootballPlayer? UpdatePlayer(FootballPlayer request);
        FootballPlayer? PatchUpdate(FootballPlayer request); 
        public void Delete(int id);
    }
}
