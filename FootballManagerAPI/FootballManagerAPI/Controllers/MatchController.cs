using FootballManagerBLL.Dto.RequestDto.Match;
using FootballManagerBLL.Dto.ResponceDto.Match;
using FootballManagerBLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : Controller
    {
        private readonly IMatchService _service;
        public MatchController(IMatchService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<FootballMatchResponseDto>>> GetAsync()
        {
            var matches = await _service.GetAsync();

            if (matches.Count == 0)
            {
                return NotFound("Matches is not found!");
            }

            return Ok(matches);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<FootballMatchResponseDto>> GetByIdAsync(int id)
        {
            if (id < 0)
            {
                return BadRequest("Id should be positive number!");
            }

            var match = await _service.GetByIdAsync(id);

            if (match == null)
            {
                return NotFound("Match is not found!");
            }

            return Ok(match);
        }

        [HttpPost("Add")]
        public async Task<ActionResult<FootballMatchResponseDto>> CreateAsync([FromBody] FootballMatchRequestDto matchDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var addedMatch = await _service.CreateAsync(matchDto);

            if (addedMatch == null)
            {
                return BadRequest("Failed to add match!");
            }

            return Ok(addedMatch);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<FootballMatchResponseDto>> UpdateAsync(int id, [FromBody] FootballMatchRequestDto matchDto)
        {
            if (id < 0)
            {
                return BadRequest("Id should be positive number!");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var match = await _service.UpdateAsync(id, matchDto);

            if (match == null)
            {
                return NotFound("Match is not found!");
            }

            return Ok(match);
        }

        [HttpDelete]
        public async Task<ActionResult<FootballMatchResponseDto>> DeleteAsync(int id)
        {
            if (id < 0)
            {
                return BadRequest("Id should be positive number!");
            }
            var match = _service.DeleteAsync(id);

            if (match == null)
            {
                return NotFound("Match is not found!");
            }

            return NoContent();
        }
    }
}
