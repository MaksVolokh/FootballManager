using FootballManagerBLL.Dto.RequestDto.Match;
using FootballManagerBLL.Dto.ResponceDto.Match;
using FootballManagerBLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : Controller
    {
        private readonly IMatchService _service;
        private readonly IStringLocalizer<MatchController> _localizer;
        public MatchController(IMatchService service, IStringLocalizer<MatchController> localizer)
        {
            _service = service;
            _localizer = localizer;
        }

        [HttpGet]
        public async Task<ActionResult<List<FootballMatchResponseDto>>> GetAsync()
        {
            var matches = await _service.GetAsync();

            if (matches.Count == 0)
            {
                return NotFound(_localizer["Matches not found!"]);
            }

            return Ok(matches);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<FootballMatchResponseDto>> GetByIdAsync(int id)
        {
            if (id < 0)
            {
                return BadRequest(_localizer["Invalid Id"]);
            }

            var match = await _service.GetByIdAsync(id);

            if (match == null)
            {
                return NotFound(_localizer["Match not found!"]);
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
                return BadRequest(_localizer["Failed to add match!"]);
            }

            return Ok(addedMatch);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<FootballMatchResponseDto>> UpdateAsync(int id, [FromBody] FootballMatchRequestDto matchDto)
        {
            if (id < 0)
            {
                return BadRequest(_localizer["Invalid Id"]);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var match = await _service.UpdateAsync(id, matchDto);

            if (match == null)
            {
                return NotFound(_localizer["Match not found!"]);
            }

            return Ok(match);
        }

        [HttpDelete]
        public async Task<ActionResult<FootballMatchResponseDto>> DeleteAsync(int id)
        {
            if (id < 0)
            {
                return BadRequest(_localizer["Invalid Id"]);
            }
            var match = _service.DeleteAsync(id);

            if (match == null)
            {
                return NotFound(_localizer["Match not found!"]);
            }

            return NoContent();
        }
    }
}
