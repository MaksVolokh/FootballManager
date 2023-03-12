using FootballManagerAPI.Controllers.Entities;
using FootballManagerAPI.Data;
using FootballManagerBLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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
            return _service.Get();
        }


        [HttpGet("{id:int}")] 
        public ActionResult<FootballPlayer> GetPlayerById(int id)
        {
            if (id < 0)
            {
                return BadRequest("Id should be positive number!");
            }
            var player = _service.GetPlayerById(id);
            if(player == null)
            {
                return NotFound("Player is not found!");
            }
            return player;
        }
          

        [HttpGet("searchByQuery")]
        public ActionResult<List<FootballPlayer>> GetPlayerByFirstName([FromQuery] string firstName)
        {
            if (firstName is not string type)
            {
                return BadRequest("First name should be string!");
            }
            var player = _service.GetPlayerByFirstName(firstName);
            if (player == null)
            {
                return NotFound("Player is not found!");
            }
            return Ok(player);  
        }


        [HttpGet("searchByQuerylN")]
        public ActionResult<List<FootballPlayer>> GetPlayerByLastName([FromQuery] string lastName)
        {
            if(lastName is not string type)
            {
                return BadRequest("Last name should be string!");
            }
            var player = _service.GetPlayerByLastName(lastName);
            if (player == null)
            {
                return NotFound("Player is not found!");
            }
            return Ok(player);
        }
         

        [HttpPost("Add")]
        public ActionResult<FootballPlayer> AddFootballPlayer(FootballPlayer player)
        { 
                _service.AddFootballPlayer(player);
                return Ok(player);
        } 


        [HttpPut("Update")] 
        public ActionResult<FootballPlayer> UpdatePlayer(FootballPlayer request)
          {
            if (request.Id < 0)
            {
                return BadRequest("Id should be positive number!");
            }
            var player = _service.UpdatePlayer(request);

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
            var player = _service.PatchUpdate(requestPatch);

            if (player == null)
            {
                return NotFound("Player is not found!");
            }
            return Ok(requestPatch);
        }


        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }         
    }
}
