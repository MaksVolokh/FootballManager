using FootballManagerAPI.Controllers.Entities;

namespace FootballManagerBLL.Interfaces
{
    public interface IPlayerService
    {
        List<FootballPlayer> Get();
        FootballPlayer? GetById(int id);
        List<FootballPlayer> GetByFirstName(string firstName);
        List<FootballPlayer> GetByLastName(string lastName);
        FootballPlayer? Add(FootballPlayer player);
        FootballPlayer? Update(FootballPlayer request);
        FootballPlayer? PatchUpdate(FootballPlayer request);
        public FootballPlayer? Delete(int id);
    }
}
