using FootballManagerBLL.Dto.RequestDto.Coach;
using FootballManagerBLL.Dto.ResponceDto.Coach;
using FootballManagerBLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachController : ControllerBase
    {
        private readonly ICoachService _service;
        public CoachController(ICoachService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<ActionResult<List<CoachResponseDto>>> GetAsync()
        {
            var coaches = await _service.GetAsync();

            if (coaches.Count == 0)
            {
                return NotFound("Coach is not found!");
            }

            return Ok(coaches);
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<CoachResponseDto>> GetByIdAsync(int id)
        {
            if (id < 0)
            {
                return BadRequest("Id should be positive number!");
            }

            var coach = await _service.GetByIdAsync(id);

            if (coach == null)
            {
                return NotFound("Coach is not found!");
            }

            return Ok(coach);
        }


        [HttpGet("searchByQuery")]
        public async Task<ActionResult<CoachResponseDto>> GetByFirstNameAsync([FromQuery] string firstName)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                return BadRequest("First name should not be empty!");
            }

            var coach = await _service.GetByFirstNameAsync(firstName);

            if (coach == null)
            {
                return NotFound("Coach is not found!");
            }

            return Ok(coach);
        }


        [HttpGet("searchByQuerylN")]
        public async Task<ActionResult<CoachResponseDto>> GetByLastNameAsync([FromQuery] string lastName)
        {
            if (string.IsNullOrEmpty(lastName))
            {
                return BadRequest("Last name should not be empty!");
            }

            var coach = await _service.GetByLastNameAsync(lastName);

            if (coach == null)
            {
                return NotFound("Coach is not found!");
            }

            return Ok(coach);
        }


        [HttpPost("AddCoach")]
        public async Task<ActionResult<CoachResponseDto>> AddAsync([FromBody] CoachRequestDto coachDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var addedCoach = await _service.AddAsync(coachDto);

            if (addedCoach == null)
            {
                return BadRequest("Failed to add coach!");
            }

            return Ok(addedCoach);
        }


        [HttpPut("UpdateCoach")]
        public async Task<ActionResult<CoachResponseDto>> UpdateAsync(int id, [FromBody] CoachRequestDto request)
        {
            if (id < 0)
            {
                return BadRequest("Id should be positive number!");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var coach = await _service.UpdateAsync(id, request);

            if (coach == null)
            {
                return NotFound("Coach is not found!");
            }

            return Ok(coach);
        }


        [HttpPatch("PatchUpdateCoach")]
        public async Task<ActionResult<CoachResponseDto>> PatchUpdateAsync(int id, [FromBody] CoachRequestDto requestPatch)
        {
            if (id < 0)
            {
                return BadRequest("Id should be positive number!");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var coach = await _service.PatchUpdateAsync(id, requestPatch);

            if (coach == null)
            {
                return NotFound("Coach is not found!");
            }

            return Ok(coach);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CoachResponseDto>> DeleteAsync(int id)
        {
            if (id < 0)
            {
                return BadRequest("Id should be positive number!");
            }

            var coach = await _service.DeleteAsync(id);

            if (coach == null)
            {
                return NotFound("Coach is not found!");
            }

            return NoContent();
        }
    }
}
