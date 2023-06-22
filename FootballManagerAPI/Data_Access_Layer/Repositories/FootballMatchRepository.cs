using FootballManagerAPI.Data;
using FootballManagerDAL.Entities;
using FootballManagerDAL.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace FootballManagerDAL.Repositories
{
    public class FootballMatchRepository : IFootballMatchRepository
    {
        private readonly DataContext _context;
        public FootballMatchRepository(DataContext context)
        {
            _context = context;
        }


        public async Task<List<FootballMatch>> GetAsync()
        {
            return await _context.FootballMatches.Include(s => s.Team).ToListAsync();
        }
        public async Task<FootballMatch> GetByIdAsync(int id)
        {
            var matches = await _context.FootballMatches.Include(s => s.Team)
                .AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (matches == null)
            {
                return null;
            }

            return matches;
        }
        public async Task<FootballMatch> CreateAsync(FootballMatch match)
        {
            _context.FootballMatches.Add(match);
            await _context.SaveChangesAsync();

            return match;
        }
        public async Task<FootballMatch> UpdateAsync(FootballMatch match)
        {
            _context.FootballMatches.Update(match);
            await _context.SaveChangesAsync();

            return match;
        }
        public async Task DeleteAsync(FootballMatch match)
        {
            _context.FootballMatches.Remove(match);
            await _context.SaveChangesAsync();
        }

    }
}
