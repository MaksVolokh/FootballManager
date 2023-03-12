using FootballManagerAPI.Controllers.Entities;
using FootballManagerDAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using FootballManagerAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Azure.Core;

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

            FootballPlayer? player = db.FootballPlayers.FirstOrDefault(x => x.Id == id);
            if (player == null)
            {
                return null;
            }
            return player  ;
        }

        
        public List<FootballPlayer> GetPlayerByFirstName(string firstName)
        {
            var players = db.FootballPlayers.Where(f => f.FirstName == firstName).ToList();
            return players; 
        }

        //If we have several players with the same last name.
        public List<FootballPlayer> GetPlayerByLastName(string lastName)
        {
            var players = db.FootballPlayers.Where(l => l.LastName == lastName).ToList();
            return players;
        }

        public FootballPlayer? AddFootballPlayer(FootballPlayer player)
        {
            db.FootballPlayers.Add(player);
            db.SaveChanges();
            return player;
        }

        public FootballPlayer? UpdatePlayer(FootballPlayer request)
        {
            var player = db.FootballPlayers.AsNoTracking().FirstOrDefault(r => r.Id == request.Id);
            db.FootballPlayers.Update(request);
            db.SaveChanges();
            return request;
        }

        public FootballPlayer? PatchUpdate(FootballPlayer requestPatch)
        {
            var player = db.FootballPlayers.AsNoTracking().FirstOrDefault(r => r.Id == requestPatch.Id);
            db.FootballPlayers.Update(requestPatch);
            db.SaveChanges();
            return requestPatch;
        }

        public void Delete(int id)
        {
            FootballPlayer? player = db.FootballPlayers.FirstOrDefault(i => i.Id == id);
            if (player != null)
            {
                db.FootballPlayers.Remove(player);
            }
            db.SaveChanges();
        }
    }
}
