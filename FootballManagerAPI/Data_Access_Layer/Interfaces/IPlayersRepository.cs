using FootballManagerAPI.Controllers.Entities;

namespace FootballManagerDAL.Interfaces
{
    public interface IPlayersRepository
    {
        List<FootballPlayer> Get();
        FootballPlayer GetById(int id);
        List<FootballPlayer> GetByFirstName(string firstName);
        List<FootballPlayer> GetByLastName(string lastName);
        FootballPlayer Add(FootballPlayer player);
        FootballPlayer Update(FootballPlayer request);
        FootballPlayer PatchUpdate(FootballPlayer request); 
        public void Delete(FootballPlayer player);
    }
}
