using FootballManagerAPI.Data;
using FootballManagerDAL.Entities;
using FootballManagerDAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FootballManagerDAL.Repositories
{
    public class CoachRepository : ICoachRepository
    {
        private readonly DataContext dbcoach;
        public CoachRepository(DataContext context)
        {
            dbcoach = context;
        }
        public List<Coach> Get()
        {
            return dbcoach.CoachForTeam.ToList();
        }

        public Coach? GetCoachById(int id)
        {

            Coach? coach = dbcoach.CoachForTeam.FirstOrDefault(x => x.Id == id);

            if (coach == null)
            {
                return null;
            }

            return coach;
        }

        public Coach? GetCoachByFirstName(string firstName)
        {
            Coach? coach = dbcoach.CoachForTeam.Where(f => f.FirstName == firstName).FirstOrDefault();

            return coach;
        }

        public Coach? GetCoachByLastName(string lastName)
        {
            Coach? coach = dbcoach.CoachForTeam.Where(l => l.LastName == lastName).FirstOrDefault();

            return coach;
        }

        public Coach? AddCoach(Coach coach)
        {
            dbcoach.CoachForTeam.Add(coach);
            dbcoach.SaveChanges();

            return coach;
        }

        public Coach? UpdateCoach(Coach request)
        {
            Coach? coach = dbcoach.CoachForTeam.AsNoTracking().FirstOrDefault(r => r.Id == request.Id);

            dbcoach.CoachForTeam.Update(request);
            dbcoach.SaveChanges();

            return request;
        }

        public Coach? PatchUpdateCoach(Coach requestPatch)
        {
            Coach? coach = dbcoach.CoachForTeam.AsNoTracking().FirstOrDefault(r => r.Id == requestPatch.Id);

            dbcoach.CoachForTeam.Update(requestPatch);
            dbcoach.SaveChanges();

            return requestPatch;
        }

        public void DeleteCoach(int id)
        {
            Coach? coach = dbcoach.CoachForTeam.FirstOrDefault(i => i.Id == id);

            if (coach != null)
            {
                dbcoach.CoachForTeam.Remove(coach);
            }

            dbcoach.SaveChanges();
        }
    }
}
