using FootballManagerAPI.Controllers.Entities;
using FootballManagerBLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FootballManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _service;
        public PlayersController(IPlayerService service)
        {
            _service = service;
        }


        [HttpGet]
        public ActionResult<List<FootballPlayer>> Get()
        {
            List<FootballPlayer> players = _service.Get();

            if (players.Count == 0)
            {   
                return NotFound("Players is not found!");
            }

            return players;
        }


        [HttpGet("{id:int}")] 
        public ActionResult<FootballPlayer> GetPlayerById(int id)
        {
            if(id < 0)
            {
                return BadRequest("Id should be positive number!");
            }

            FootballPlayer player = _service.GetById(id);

            if (player == null)
            {
                return NotFound("Player is not found!");
            }

            return player;
        }
          

        [HttpGet("searchByQuery")]
        public ActionResult<List<FootballPlayer>> GetByFirstName([FromQuery] string firstName)
        {
            if (firstName is not string)
            {
                return BadRequest("First name should be string!");
            }

            List<FootballPlayer> player = _service.GetByFirstName(firstName);

            if (player.Count == 0)
            {
                return NotFound("Players is not found!");
            }

            return Ok(player);  
        }


        [HttpGet("searchByQuerylN")]
        public ActionResult<List<FootballPlayer>> GetByLastName([FromQuery] string lastName)
        {
            if (lastName is not string)
            {
                return BadRequest("Last name should be string!");
            }

            List<FootballPlayer> player = _service.GetByLastName(lastName);

            if (player.Count == 0)
            {
                return NotFound("Players is not found!");
            }

            return Ok(player);
        }
         

        [HttpPost("Add")]
        public ActionResult<FootballPlayer> Add(FootballPlayer player)
        { 
            _service.Add(player);

            return Ok(player);
        } 


        [HttpPut("Update")] 
        public ActionResult<FootballPlayer> Update(FootballPlayer request)
          {
            if (request.Id < 0)
            {
                return BadRequest("Id should be positive number!");
            }

            FootballPlayer player = _service.Update(request);

            if (player == null)
            { 
                return NotFound("Player is not found!");
            }

            return Ok(request);
        }


        [HttpPatch("PatchUpdate")]
        public ActionResult<FootballPlayer> PatchUpdate(FootballPlayer requestPatch)
        {
            if (requestPatch.Id < 0)
            {
                return BadRequest("Id should be positive number!");
            }

            FootballPlayer player = _service.PatchUpdate(requestPatch);

            if (player == null)
            {
                return NotFound("Player is not found!");
            }

            return Ok(requestPatch);
        }


        [HttpDelete("{id:int}")]
        public ActionResult<FootballPlayer> Delete(int id)
        {
            if (id < 0)
            {
                return BadRequest("Id should be positive number!");
            }

            FootballPlayer player = _service.Delete(id);

            if (player == null)
            {
                return NotFound("Player is not found!");
            }

            return NoContent();
        }         
    }
}
