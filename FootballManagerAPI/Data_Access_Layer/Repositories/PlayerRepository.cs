using FootballManagerAPI.Controllers.Entities;
using FootballManagerDAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using FootballManagerAPI.Data;

/*
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
            return db.FootballPlayers.ToList();
        }

        public FootballPlayer GetPlayerById(int id)
        {
            return db.FootballPlayers.Find(id);
        }

        public FootballPlayer GetPlayerByFirstName(string firstName)
        {
            return db.FootballPlayers.Find(firstName);
        }

        public FootballPlayer GetPlayerByLastName(string lastName)
        {
            return db.FootballPlayers.Find(lastName);
        }

        public FootballPlayer AddFootballPlayer(FootballPlayer player)
        {
            
        }
    }
}
  */