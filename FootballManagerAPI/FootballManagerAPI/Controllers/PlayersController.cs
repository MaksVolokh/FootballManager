using FootballManagerAPI.Controllers.Entities;
using FootballManagerBLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<ActionResult<List<FootballPlayer>>> GetAsync()
        {
            List<FootballPlayer> players = await _service.GetAsync();

            if (players.Count == 0)
            {   
                return NotFound("Players is not found!");
            }

            return players;
        }


        [HttpGet("{id:int}")] 
        public async Task<ActionResult<FootballPlayer>> GetPlayerByIdAsync(int id)
        {
            if(id < 0)
            {
                return BadRequest("Id should be positive number!");
            }

            FootballPlayer player = await _service.GetByIdAsync(id);

            if (player == null)
            {
                return NotFound("Player is not found!");
            }

            return player;
        }
          

        [HttpGet("searchByQuery")]
        public async Task<ActionResult<List<FootballPlayer>>> GetByFirstNameAsync([FromQuery] string firstName)
        {
            if (firstName is not string)
            {
                return BadRequest("First name should be string!");
            }

            List<FootballPlayer> player = await _service.GetByFirstNameAsync(firstName);

            if (player.Count == 0)
            {
                return NotFound("Players is not found!");
            }

            return Ok(player);  
        }


        [HttpGet("searchByQuerylN")]
        public async Task<ActionResult<List<FootballPlayer>>> GetByLastNameAsync([FromQuery] string lastName)
        {
            if (lastName is not string)
            {
                return BadRequest("Last name should be string!");
            }

            List<FootballPlayer> player = await _service.GetByLastNameAsync(lastName);

            if (player.Count == 0)
            {
                return NotFound("Players is not found!");
            }

            return Ok(player);
        }
         

        [HttpPost("Add")]
        public async Task<ActionResult<FootballPlayer>> AddAsync(FootballPlayer player)
        { 
            await _service.AddAsync(player);

            return Ok(player);
        } 


        [HttpPut("Update")] 
        public async Task<ActionResult<FootballPlayer>> UpdateAsync(FootballPlayer request)
          {
            if (request.Id < 0)
            {
                return BadRequest("Id should be positive number!");
            }

            FootballPlayer player = await _service.UpdateAsync(request);

            if (player == null)
            { 
                return NotFound("Player is not found!");
            }

            return Ok(request);
        }


        [HttpPatch("PatchUpdate")]
        public async Task<ActionResult<FootballPlayer>> PatchUpdateAsync(FootballPlayer requestPatch)
        {
            if (requestPatch.Id < 0)
            {
                return BadRequest("Id should be positive number!");
            }

            FootballPlayer player = await _service.PatchUpdateAsync(requestPatch);

            if (player == null)
            {
                return NotFound("Player is not found!");
            }

            return Ok(requestPatch);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult<FootballPlayer>> DeleteAsync(int id)
        {
            if (id < 0)
            {
                return BadRequest("Id should be positive number!");
            }

            FootballPlayer player = await _service.DeleteAsync(id);

            if (player == null)
            {
                return NotFound("Player is not found!");
            }

            return NoContent();
        }         
    }
}
