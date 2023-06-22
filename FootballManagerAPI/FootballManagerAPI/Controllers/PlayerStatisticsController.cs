using FootballManagerBLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using FootballManagerBLL.Dto.ResponceDto.PlayerStatistics;

namespace FootballManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerStatisticsController : Controller
    {
        private readonly IStatisticsService _service;
        public PlayerStatisticsController(IStatisticsService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<FootballPlayerStatisticsResponseDto>>> GetAsync()
        {
            var playerStats = await _service.GetAsync();

            if (playerStats.Count == 0)
            {
                return NotFound("Stats is not found!");
            }

            return Ok(playerStats);
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<FootballPlayerStatisticsResponseDto>> GetByIdAsync(int id)
        {
            if (id < 0)
            {
                return BadRequest("Id should be positive number!");
            }

            var playerStatistics = await _service.GetByIdAsync(id);

            if (playerStatistics == null)
            {
                return NotFound("Stats is not found!");
            }

            return Ok(playerStatistics);
        }

        [HttpPost("Add")]
        public async Task<ActionResult<FootballPlayerStatisticsResponseDto>> CreateAsync([FromBody] FootballPlayerStatisticsRequestDto playerStatisticsDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var addedStats = await _service.CreateAsync(playerStatisticsDto);

            if (addedStats == null)
            {
                return BadRequest("Failed to add stats!");
            }

            return Ok(addedStats);
        }

        [HttpPut("Update")]
        public async Task<ActionResult> UpdateAsync(int id, [FromBody] FootballPlayerStatisticsRequestDto playerStatisticsDto)
        {
            if (id < 0)
            {
                return BadRequest("Id should be positive number!");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var playerStatistics = await _service.UpdateAsync(id, playerStatisticsDto);

            if (playerStatistics == null)
            {
                return NotFound("Stats is not found!");
            }

            return Ok(playerStatistics);
        }

        [HttpDelete]
        public async Task<ActionResult<FootballPlayerStatisticsResponseDto>> DeleteAsync(int id)
        {
            if (id < 0)
            {
                return BadRequest("Id should be positive number!");
            }
            var stats = _service.DeleteAsync(id);

            if (stats == null)
            {
                return NotFound("Stats is not found!");
            }

            return NoContent();
        }
    }
}

