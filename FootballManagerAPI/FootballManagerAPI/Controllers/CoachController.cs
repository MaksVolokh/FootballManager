using FootballManagerBLL.Interfaces;
using FootballManagerDAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public ActionResult<List<Coach>> Get()
        {
            List<Coach> coaches = _service.Get();

            if (coaches.Count == 0)
            {
                return NotFound("Coach is not found!");
            }

            return coaches;
        }


        [HttpGet("{id:int}")]
        public ActionResult<Coach> GetCoachById(int id)
        {
            if (id < 0)
            {
                return BadRequest("Id should be positive number!");
            }

            Coach coach = _service.GetCoachById(id);

            if (coach == null)
            {
                return NotFound("Coach is not found!");
            }

            return coach;
        }


        [HttpGet("searchByQuery")]
        public ActionResult<Coach> GetCoachByFirstName([FromQuery] string firstName)
        {
            if (firstName is not string)
            {
                return BadRequest("First name should be string!");
            }

            Coach coach = _service.GetCoachByFirstName(firstName);

            if (coach == null)
            {
                return NotFound("Coach is not found!");
            }

            return Ok(coach);
        }


        [HttpGet("searchByQuerylN")]
        public ActionResult<Coach> GetCoachByLastName([FromQuery] string lastName)
        {
            if (lastName is not string)
            {
                return BadRequest("Last name should be string!");
            }

            Coach coach = _service.GetCoachByLastName(lastName);

            if (coach == null)
            {
                return NotFound("Coach is not found!");
            }

            return Ok(coach);
        }


        [HttpPost("AddCoach")]
        public ActionResult<Coach> AddCoach(Coach coach)
        {
            _service.AddCoach(coach);

            return Ok(coach);
        }


        [HttpPut("UpdateCoach")]
        public ActionResult<Coach> UpdateCoach(Coach request)
        {
            if (request.Id < 0)
            {
                return BadRequest("Id should be positive number!");
            }

            Coach coach = _service.UpdateCoach(request);

            if (coach == null)
            {
                return NotFound("Coach is not found!");
            }

            return Ok(request);
        }


        [HttpPatch("PatchUpdateCoach")]
        public ActionResult<Coach> PatchUpdateCoach(Coach requestPatch)
        {
            if (requestPatch.Id < 0)
            {
                return BadRequest("Id should be positive number!");
            }

            Coach coach = _service.PatchUpdateCoach(requestPatch);

            if (coach == null)
            {
                return NotFound("Coach is not found!");
            }

            return Ok(requestPatch);
        }


        [HttpDelete("{id:int}")]
        public void DeleteCoach(int id)
        {
            _service.DeleteCoach(id);
        }
    }
}
