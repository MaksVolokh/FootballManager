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
        
        public List<FootballPlayer> Get()
        {
            return db.FootballPlayers.Include(s => s.FootballTeam).ToList();
        }

        public FootballPlayer GetById(int id)
        {

            FootballPlayer player = db.FootballPlayers.Include(s => s.FootballTeam)
                .AsNoTracking().FirstOrDefault(x => x.Id == id);

            if (player == null)
            {
                return null;
            }

            return player;
        }

        public List<FootballPlayer> GetByFirstName(string firstName)
        {
            List<FootballPlayer> players = db.FootballPlayers.Include(s => s.FootballTeam)
                .Where(f => f.FirstName == firstName).ToList();

            return players; 
        }

        public List<FootballPlayer> GetByLastName(string lastName)
        {
            List<FootballPlayer> players = db.FootballPlayers.Include(s => s.FootballTeam)
                .Where(l => l.LastName == lastName).ToList();

            return players;
        }

        public FootballPlayer Add(FootballPlayer player)
        {
            db.FootballPlayers.Add(player);
            db.SaveChanges();

            return player;
        }

        public FootballPlayer Update(FootballPlayer request)
        {
            db.FootballPlayers.Update(request);
            db.SaveChanges();

            return request;
        }

        public FootballPlayer PatchUpdate(FootballPlayer requestPatch)
        {
            db.FootballPlayers.Update(requestPatch);
            db.SaveChanges();

            return requestPatch;
        }

        public void Delete(FootballPlayer player)
        {
            db.FootballPlayers.Remove(player);
            db.SaveChanges();
        }
    }
}
