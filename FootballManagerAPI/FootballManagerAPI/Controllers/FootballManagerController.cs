using FootballManagerAPI.Controllers.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballManagerController : ControllerBase
    {
        private static List<FootballPlayer> players = new List<FootballPlayer>()
        {
                new FootballPlayer(1, "Maksym", "Volokh", 18),
                new FootballPlayer(2, "Gena", "Kruglov", 16),
                new FootballPlayer(3, "Denis", "Guja", 22),
        };


        [HttpGet]
        public ActionResult<List<FootballPlayer>> Get()
        {
                return Ok(players);
        }


        [HttpGet("{id:int}")]
        public ActionResult<FootballPlayer> GetId(int id)
        {
            var player = players.Find(p => p.Id == id);
            if(player == null)
            {
                return BadRequest("Player is not found!");
            }
            return Ok(player);
        }


        [HttpGet("{firstName}/name")]
        public ActionResult<FootballPlayer> GetFirstName(string firstName)
        {
            var player = players.Find(f => f.FirstName == firstName);
            if (player == null)
            {
                return BadRequest("Player is not found!");
            }
            return Ok(player);  
        }


        [HttpGet("{lastName}")]
        public ActionResult<FootballPlayer> GetLastName(string lastName)
        {
            var player = players.Find(l => l.LastName == lastName);
            if (player == null)
            {
                return BadRequest("Player is not found!");
            }
            return Ok(player);
        }


        [HttpPost]
        public ActionResult<List<FootballPlayer>> AddFootballPlayer(FootballPlayer player)
        {
                players.Add(player);
                return Ok(players);
        }


        [HttpPut]
        public ActionResult<FootballPlayer> UpdatePlayer(FootballPlayer request)
        {
            var player = players.Find(r => r.Id == request.Id);
            if (player == null)
            {
                return BadRequest("Player is not found!");
            }
            player.Id = request.Id;
            player.FirstName = request.FirstName;
            player.LastName = request.LastName;
            player.Number = request.Number;

            return Ok(players);
        }


        [HttpDelete]
        public ActionResult<FootballPlayer> Delete(int id)
        {
            var player = players.Find(d => d.Id == id);
            if (player == null)
            {
                return BadRequest("Player is not found!");
            }
            players.Remove(player);
            return Ok(players);
        }

    }
}
