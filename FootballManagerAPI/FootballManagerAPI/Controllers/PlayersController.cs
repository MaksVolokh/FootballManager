using FootballManagerAPI.Controllers.Entities;
using FootballManagerAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FootballManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {

        private readonly DataContext _context;
        public PlayersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<FootballPlayer>> Get()
        {
            return Ok(_context.FootballPlayers);
        }


        [HttpGet("{id:int}")]
        public ActionResult<FootballPlayer> GetPlayerById(int id)
        {
            var player = _context.FootballPlayers.FirstOrDefault(i => i.Id == id);
            if(player == null)
            {
                return BadRequest("Player is not found!");
            }
            return Ok(player);
        }


        [HttpGet("{firstName}/name")]
        public ActionResult<FootballPlayer> GetPlayerByFirstName(string firstName)
        {
            var player = _context.FootballPlayers.FirstOrDefault(f => f.FirstName == firstName);
            if (player == null)
            {
                return BadRequest("Player is not found!");
            }
            return Ok(player);  
        }


        [HttpGet("{lastName}")]
        public ActionResult<FootballPlayer> GetPlayerByLastName(string lastName)
        {
            var player = _context.FootballPlayers.FirstOrDefault(l => l.LastName == lastName);
            if (player == null)
            {
                return BadRequest("Player is not found!");
            }
            return Ok(player);
        }


        [HttpPost]
        public ActionResult<List<FootballPlayer>> AddFootballPlayer(FootballPlayer player)
        {
                _context.FootballPlayers.Add(player);
                return Ok(_context.FootballPlayers);
        }


        [HttpPut]
        public ActionResult<FootballPlayer> UpdatePlayer(FootballPlayer request)
        {
            var player = _context.FootballPlayers.FirstOrDefault(r => r.Id == request.Id);
            if (player == null)
            {
                return BadRequest("Player is not found!");
            }
            player.Id = request.Id;
            player.FirstName = request.FirstName;
            player.LastName = request.LastName;
            player.Number = request.Number;

            return Ok(_context.FootballPlayers);
        }


        [HttpDelete]
        public ActionResult<FootballPlayer> Delete(int id)
        {
            var player = _context.FootballPlayers.FirstOrDefault(i => i.Id == id);
            if (player == null)
            {
                return BadRequest("Player is not found!");
            }
            _context.FootballPlayers.Remove(player);
            return Ok(_context.FootballPlayers);
        }

    }
}
