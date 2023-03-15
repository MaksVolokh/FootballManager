using FootballManagerDAL.Entities;

namespace FootballManagerBLL.Interfaces
{
    public interface ICoachService
    {
        List<Coach> Get();
        Coach? GetCoachById(int id);
        Coach? GetCoachByFirstName(string firstName);
        Coach? GetCoachByLastName(string lastName);
        Coach? AddCoach(Coach coach);
        Coach? UpdateCoach(Coach request);
        Coach? PatchUpdateCoach(Coach requestPatch);
        public void DeleteCoach(int id);
    }
}
