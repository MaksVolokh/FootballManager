using FootballManagerDAL.Entities;
namespace FootballManagerDAL.Interfaces
{
    public interface ICoachRepository
    {
        List<Coach> Get();
        Coach GetById(int id);
        Coach GetByFirstName(string firstName);
        Coach GetByLastName(string lastName);
        Coach Add(Coach coach);
        Coach Update(Coach request);
        Coach PatchUpdate(Coach requestPatch);
        public void Delete(Coach coach);
    }
}
