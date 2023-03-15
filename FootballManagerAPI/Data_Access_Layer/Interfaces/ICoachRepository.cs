using FootballManagerDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FootballManagerDAL.Interfaces
{
    public interface ICoachRepository
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
