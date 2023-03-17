using FootballManagerBLL.Interfaces;
using FootballManagerDAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public ActionResult<List<FootballTeam>> Get()
        {
            List<FootballTeam> teams = _service.Get();

            if (teams.Count == 0)
            {
                return NotFound("Team is not found!");
            }

            return teams;
        }


        [HttpGet("{id:int}")]
        public ActionResult<FootballTeam> GetById(int id)
        {
            if (id < 0)
            {
                return BadRequest("Id should be positive number!");
            }

            FootballTeam team = _service.GetById(id);

            if (team == null)
            {
                return NotFound("Team is not found!");
            }

            return team;
        }


        [HttpGet("searchByQuery")]
        public ActionResult<FootballTeam> GetByTeamName([FromQuery] string teamname)
        {
            if (teamname is not string)
            {
                return BadRequest("Team name should be string!");
            }

            FootballTeam team = _service.GetByTeamName(teamname);

            if (team == null)
            {
                return NotFound("Team is not found!");
            }

            return Ok(team);
        }


        [HttpPost("Add")]
        public ActionResult<FootballTeam> Add(FootballTeam team)
        {
            _service.Add(team);

            return Ok(team);
        }


        [HttpPut("Update")]
        public ActionResult<FootballTeam> Update(FootballTeam request)
        {
            if (request.Id < 0)
            {
                return BadRequest("Id should be positive number!");
            }

            FootballTeam team = _service.Update(request);

            if (team == null)
            {
                return NotFound("Team is not found!");
            }

            return request;
        }


        [HttpDelete("{id:int}")]
        public ActionResult<FootballTeam> Delete(int id)
        {
            if (id < 0)
            {
                return BadRequest("Id should be positive number!");
            }

            FootballTeam team = _service.Delete(id);

            if (team == null)
            {
                return NotFound("Team is not found!");
            }

            return NoContent();

        }
    }
}
