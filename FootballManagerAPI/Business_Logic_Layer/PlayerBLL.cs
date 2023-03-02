using FootballManagerAPI.Controllers.Entities;
using FootballManagerDAL.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace FootballManagerBLL
{
   /* public class PlayerBLL : IPlayersRepository

    {
        public IPlayersRepository playerDAL;

        public PlayerBLL()
        {
            playerDAL = new ();   
        }

        public ActionResult<List<FootballPlayer>> Get()
        {
            return playerDAL.Get();
        }

        public ActionResult<FootballPlayer> GetId(int id)
        {
            var player = playerBLL(id);
            if (player == null)
            {
                return BadRequest("Player is not found!");
            }
            return Ok(player);
        }

    }*/
}