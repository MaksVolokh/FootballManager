using FootballManagerDAL.Entities;

namespace FootballManagerBLL.Interfaces
{
    public interface ICoachService
    {
        List<Coach> Get();
        Coach? GetById(int id);
        Coach? GetByFirstName(string firstName);
        Coach? GetByLastName(string lastName);
        Coach? Add(Coach coach);
        Coach? Update(Coach request);
        Coach? PatchUpdate(Coach requestPatch);
        public Coach? Delete(int id);
    }
}
