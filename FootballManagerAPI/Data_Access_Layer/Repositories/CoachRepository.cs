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

        public Coach? GetById(int id)
        {

            Coach? coach = dbcoach.CoachForTeam.AsNoTracking().FirstOrDefault(x => x.Id == id);

            if (coach == null)
            {
                return null;
            }

            return coach;
        }

        public Coach? GetByFirstName(string firstName)
        {
            Coach? coach = dbcoach.CoachForTeam.Where(f => f.FirstName == firstName).FirstOrDefault();

            return coach;
        }

        public Coach? GetByLastName(string lastName)
        {
            Coach? coach = dbcoach.CoachForTeam.Where(l => l.LastName == lastName).FirstOrDefault();

            return coach;
        }

        public Coach? Add(Coach coach)
        {
            dbcoach.CoachForTeam.Add(coach);
            dbcoach.SaveChanges();

            return coach;
        }

        public Coach Update(Coach request)
        {
            dbcoach.CoachForTeam.Update(request);
            dbcoach.SaveChanges();

            return request;
        }

        public Coach PatchUpdate(Coach requestPatch)
        {
            dbcoach.CoachForTeam.Update(requestPatch);
            dbcoach.SaveChanges();

            return requestPatch;
        }

        public void Delete(Coach coach)
        {
            dbcoach.CoachForTeam.Remove(coach);
            dbcoach.SaveChanges();
        }
    }
}
