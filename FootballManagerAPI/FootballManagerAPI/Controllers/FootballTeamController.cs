using FootballManagerBLL.Dto.RequestDto.FootballTeam;
using FootballManagerBLL.Dto.ResponceDto.FootballTeam;
using FootballManagerBLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballTeamController : ControllerBase
    {
        private readonly IFootballTeamService _service;
        public FootballTeamController(IFootballTeamService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<ActionResult<List<FootballTeamResponseDto>>> GetAsync()
        {
            var teams = await _service.GetAsync();

            if (teams.Count == 0)
            {
                return NotFound("Team is not found!");
            }

            return Ok(teams);
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<FootballTeamResponseDto>> GetByIdAsync(int id)
        {
            if (id < 0)
            {
                return BadRequest("Id should be positive number!");
            }

            var team = await _service.GetByIdAsync(id);

            if (team == null)
            {
                return NotFound("Team is not found!");
            }

            return Ok(team);
        }


        [HttpGet("searchByQuery")]
        public async Task<ActionResult<FootballTeamResponseDto>> GetTeamNameAsync([FromQuery] string teamName)
        {
            if (string.IsNullOrEmpty(teamName))
            {
                return BadRequest("Team name should not be empty!");
            }

            var team = await _service.GetTeamNameAsync(teamName);

            if (team == null)
            {
                return NotFound("Team is not found!");
            }

            return Ok(team);
        }


        [HttpPost("Add")]
        public async Task<ActionResult<FootballTeamResponseDto>> AddAsync([FromBody] FootballTeamRequestDto team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var addedTeam = await _service.AddAsync(team);

            if (addedTeam == null)
            {
                return BadRequest("Failed to add team!");
            }

            return Ok(addedTeam);
        }


        [HttpPut("Update")]
        public async Task<ActionResult<FootballTeamRequestDto>> UpdateAsync(int id, [FromBody] FootballTeamRequestDto request)
        {
            if (id < 0)
            {
                return BadRequest("Id should be positive number!");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var team = await _service.UpdateAsync(id, request);

            if (team == null)
            {
                return NotFound("Team is not found!");
            }

            return Ok(team);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult<FootballTeamResponseDto>> DeleteAsync(int id)
        {
            if (id < 0)
            {
                return BadRequest("Id should be positive number!");
            }

            var team = await _service.DeleteAsync(id);

            if (team == null) 
            {
                return NotFound("Team is not found!");
            }

            return NoContent();

        }
    }
}
