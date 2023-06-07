using FootballManagerBLL.Interfaces;
using FootballManagerDAL.Entities;
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
        public async Task<ActionResult<List<Coach>>> GetAsync()
        {
            List<Coach> coaches = await _service.GetAsync();

            if (coaches.Count == 0)
            {
                return NotFound("Coach is not found!");
            }

            return coaches;
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Coach>> GetByIdAsync(int id)
        {
            if (id < 0)
            {
                return BadRequest("Id should be positive number!");
            }

            Coach coach = await _service.GetByIdAsync(id);

            if (coach == null)
            {
                return NotFound("Coach is not found!");
            }

            return coach;
        }


        [HttpGet("searchByQuery")]
        public async Task<ActionResult<Coach>> GetByFirstNameAsync([FromQuery] string firstName)
        {
            if (firstName is not string)
            {
                return BadRequest("First name should be string!");
            }

            Coach coach = await _service.GetByFirstNameAsync(firstName);

            if (coach == null)
            {
                return NotFound("Coach is not found!");
            }

            return Ok(coach);
        }


        [HttpGet("searchByQuerylN")]
        public async Task<ActionResult<Coach>> GetByLastNameAsync([FromQuery] string lastName)
        {
            if (lastName is not string)
            {
                return BadRequest("Last name should be string!");
            }

            Coach coach = await _service.GetByLastNameAsync(lastName);

            if (coach == null)
            {
                return NotFound("Coach is not found!");
            }

            return Ok(coach);
        }


        [HttpPost("AddCoach")]
        public async Task<ActionResult<Coach>> AddAsync(Coach coach)
        {
            await _service.AddAsync(coach);

            return Ok(coach);
        }


        [HttpPut("UpdateCoach")]
        public async Task<ActionResult<Coach>> UpdateAsync(Coach request)
        {
            if (request.Id < 0)
            {
                return BadRequest("Id should be positive number!");
            }

            Coach coach = await _service.UpdateAsync(request);

            if (coach == null)
            {
                return NotFound("Coach is not found!");
            }

            return Ok(request);
        }


        [HttpPatch("PatchUpdateCoach")]
        public async Task<ActionResult<Coach>> PatchUpdateAsync(Coach requestPatch)
        {
            if (requestPatch.Id < 0)
            {
                return BadRequest("Id should be positive number!");
            }

            Coach coach = await _service.PatchUpdateAsync(requestPatch);

            if (coach == null)
            {
                return NotFound("Coach is not found!");
            }

            return Ok(requestPatch);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Coach>> DeleteAsync(int id)
        {
            if (id < 0)
            {
                return BadRequest("Id should be positive number!");
            }

            Coach coach = await _service.DeleteAsync(id);

            if (coach == null)
            {
                return NotFound("Coach is not found!");
            }

            return NoContent();
        }
    }
}
