using FootballManagerAPI.Data;
using FootballManagerAPI.Migrations;
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
        public async Task<List<Coach>> GetAsync()
        {
            return await dbcoach.CoachForTeam.Include(s => s.FootballTeam).ToListAsync();
        }

        public async Task<Coach> GetByIdAsync(int id)
        {

            Coach coach = await dbcoach.CoachForTeam.Include(s => s.FootballTeam)
                .AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (coach == null)
            {
                return null;
            }

            return coach;
        }

        public async Task<Coach> GetByFirstNameAsync(string firstName)
        {
            Coach coach = await dbcoach.CoachForTeam.Include(s => s.FootballTeam)
                .Where(f => f.FirstName == firstName).FirstOrDefaultAsync();

            return coach;
        }

        public async Task<Coach> GetByLastNameAsync(string lastName)
        {
            Coach coach = await dbcoach.CoachForTeam.Include(s => s.FootballTeam)
                .Where(l => l.LastName == lastName).FirstOrDefaultAsync();

            return coach;
        }

        public async Task<Coach> AddAsync(Coach coach)
        {
            dbcoach.CoachForTeam.Add(coach);
            await dbcoach.SaveChangesAsync();

            return coach;
        }

        public async Task<Coach> UpdateAsync(Coach request)
        {
            dbcoach.CoachForTeam.Update(request);
            await dbcoach.SaveChangesAsync();

            return request;
        }

        public async Task<Coach> PatchUpdateAsync(Coach requestPatch)
        {
            dbcoach.CoachForTeam.Update(requestPatch);
            await dbcoach.SaveChangesAsync();

            return requestPatch;
        }

        public async Task DeleteAsync(Coach coach)
        { 
            dbcoach.CoachForTeam.Remove(coach);
            await dbcoach.SaveChangesAsync();
        }
    }
}
