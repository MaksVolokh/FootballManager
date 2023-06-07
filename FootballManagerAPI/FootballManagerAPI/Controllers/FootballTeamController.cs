using FootballManagerBLL.Interfaces;
using FootballManagerDAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballTeamController : ControllerBase
    {
        private readonly IFootballTeam _service;
        public FootballTeamController(IFootballTeam service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<ActionResult<List<FootballTeam>>> GetAsync()
        {
            List<FootballTeam> teams = await _service.GetAsync();

            if (teams.Count == 0)
            {
                return NotFound("Team is not found!");
            }

            return teams;
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<FootballTeam>> GetByIdAsync(int id)
        {
            if (id < 0)
            {
                return BadRequest("Id should be positive number!");
            }

            FootballTeam team = await _service.GetByIdAsync(id);

            if (team == null)
            {
                return NotFound("Team is not found!");
            }

            return team;
        }


        [HttpGet("searchByQuery")]
        public async Task<ActionResult<FootballTeam>> GetByTeamNameAsync([FromQuery] string teamname)
        {
            if (teamname is not string)
            {
                return BadRequest("Team name should be string!");
            }

            FootballTeam team = await _service.GetByTeamNameAsync(teamname);

            if (team == null)
            {
                return NotFound("Team is not found!");
            }

            return Ok(team);
        }


        [HttpPost("Add")]
        public async Task<ActionResult<FootballTeam>> AddAsync(FootballTeam team)
        {
            await _service.AddAsync(team);

            return Ok(team);
        }


        [HttpPut("Update")]
        public async Task<ActionResult<FootballTeam>> UpdateAsync(FootballTeam request)
        {
            if (request.Id < 0)
            {
                return BadRequest("Id should be positive number!");
            }

            FootballTeam team = await _service.UpdateAsync(request);

            if (team == null)
            {
                return NotFound("Team is not found!");
            }

            return request;
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult<FootballTeam>> DeleteAsync(int id)
        {
            if (id < 0)
            {
                return BadRequest("Id should be positive number!");
            }

            FootballTeam team = await _service.DeleteAsync(id);

            if (team == null) 
            {
                return NotFound("Team is not found!");
            }

            return NoContent();

        }
    }
}
