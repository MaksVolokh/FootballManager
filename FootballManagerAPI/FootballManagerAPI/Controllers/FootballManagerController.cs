using FootballManagerAPI.Controllers.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballManagerController : ControllerBase
    {
        [HttpGet]

        public async Task<ActionResult<List<FootballPlayer>>> Get()
        {
            var players = new List<FootballPlayer>();
            {
                new FootballPlayer(1, "Maksym", "Volokh", 18)
                {

                };
            }
            return Ok(players);
        }

    }
}
