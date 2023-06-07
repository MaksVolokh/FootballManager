using FootballManagerAPI.Controllers.Entities;
using FootballManagerDAL.Interfaces;
using FootballManagerAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace FootballManagerDAL.Repositories
{
   public class PlayerRepository : IPlayersRepository
    {
        private readonly DataContext db;
        public PlayerRepository(DataContext context)
        {
            db = context;   
        }
        
        public async Task<List<FootballPlayer>> GetAsync()
        {
            return await db.FootballPlayers.Include(s => s.FootballTeam).ToListAsync();
        }

        public async Task<FootballPlayer> GetByIdAsync(int id)
        {

            FootballPlayer player = await db.FootballPlayers.Include(s => s.FootballTeam)
                .AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (player == null)
            {
                return null;
            }

            return player;
        }

        public async Task<List<FootballPlayer>> GetByFirstNameAsync(string firstName)
        {
            List<FootballPlayer> players = await db.FootballPlayers.Include(s => s.FootballTeam)
                .Where(f => f.FirstName == firstName).ToListAsync();

            return players; 
        }

        public async Task<List<FootballPlayer>> GetByLastNameAsync(string lastName)
        {
            List<FootballPlayer> players = await db.FootballPlayers.Include(s => s.FootballTeam)
                .Where(l => l.LastName == lastName).ToListAsync();

            return players;
        }

        public async Task<FootballPlayer> AddAsync(FootballPlayer player)
        {
            db.FootballPlayers.Add(player);
            await db.SaveChangesAsync();

            return player;
        }

        public async Task<FootballPlayer> UpdateAsync(FootballPlayer request)
        {
            db.FootballPlayers.Update(request);
            await db.SaveChangesAsync();

            return request;
        }

        public async Task<FootballPlayer> PatchUpdateAsync(FootballPlayer requestPatch)
        {
            db.FootballPlayers.Update(requestPatch);
            await db.SaveChangesAsync();

            return requestPatch;
        }

        public async Task DeleteAsync(FootballPlayer player)
        {
            db.FootballPlayers.Remove(player);
            await db.SaveChangesAsync();
        }
    }
}
