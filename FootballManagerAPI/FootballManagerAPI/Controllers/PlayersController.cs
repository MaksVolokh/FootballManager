using FootballManagerBLL.Dto.RequestDto.Player;
using FootballManagerBLL.Dto.ResponceDto.Player;
using FootballManagerBLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _service;
        private readonly IStringLocalizer<PlayersController> _localizer;
        public PlayersController(IPlayerService service, IStringLocalizer<PlayersController> localizer)
        {
            _service = service;
            _localizer = localizer;
        }


        [HttpGet]
        public async Task<ActionResult<List<FootballPlayerResponseDto>>> GetAsync()
        {
            var players = await _service.GetAsync();

            if (players.Count == 0)
            {
                return NotFound(_localizer["Players not found!"]);
            }

            return Ok(players);
        }


        [HttpGet("{id:int}")] 
        public async Task<ActionResult<FootballPlayerResponseDto>> GetPlayerByIdAsync(int id)
        {
            if(id < 0)
            {
                return BadRequest(_localizer["Invalid Id!"]);
            }

            var player = await _service.GetByIdAsync(id);

            if (player == null)
            {
                return NotFound(_localizer["Player not found!"]);
            }

            return Ok(player);
        }
          

        [HttpGet("searchByQuery")]
        public async Task<ActionResult<List<FootballPlayerResponseDto>>> GetByFirstNameAsync([FromQuery] string firstName)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                return BadRequest(_localizer["First name should not be empty!"]);
            }

            var player = await _service.GetByFirstNameAsync(firstName);

            if (player.Count == 0)
            {
                return NotFound(_localizer["Players not found!"]);
            }

            return Ok(player);  
        }


        [HttpGet("searchByQuerylN")]
        public async Task<ActionResult<List<FootballPlayerResponseDto>>> GetByLastNameAsync([FromQuery] string lastName)
        {
            if (string.IsNullOrEmpty(lastName))
            {
                return BadRequest(_localizer["Last name should not be empty!"]);
            }

            var player = await _service.GetByLastNameAsync(lastName);

            if (player.Count == 0)
            {
                return NotFound(_localizer["Players not found!"]);
            }

            return Ok(player);
        }
         

        [HttpPost("Add")]
        public async Task<ActionResult<FootballPlayerResponseDto>> AddAsync([FromBody] FootballPlayerRequestDto player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool isNumberAvailable = await _service.IsPlayerNumberAvailable(player.Number);

            if (!isNumberAvailable)
            {
                ModelState.AddModelError(nameof(FootballPlayerRequestDto.Number), _localizer["This player number is already taken. Please choose another number."]);
                return BadRequest(ModelState);
            }

            var addedPlayer = await _service.AddAsync(player);

            if (addedPlayer == null)
            {
                return BadRequest(_localizer["Failed to add player!"]);
            }

            return Ok(addedPlayer);
        } 


        [HttpPut("Update")] 
        public async Task<ActionResult<FootballPlayerResponseDto>> UpdateAsync(int id, [FromBody] FootballPlayerRequestDto request)
          {
            if (id < 0)
            {
                return BadRequest(_localizer["Invalid Id!"]);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var player = await _service.UpdateAsync(id, request);

            if (player == null)
            { 
                return NotFound(_localizer["Player not found!"]);
            }

            return Ok(player);
        }


        [HttpPatch("PatchUpdate")]
        public async Task<ActionResult<FootballPlayerResponseDto>> PatchUpdateAsync(int id, [FromBody] FootballPlayerRequestDto request)
        {
            if (id < 0)
            {
                return BadRequest(_localizer["Invalid Id!"]);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var player = await _service.PatchUpdateAsync(id, request);

            if (player == null)
            {
                return NotFound(_localizer["Player not found!"]);
            }

            return Ok(player);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult<FootballPlayerResponseDto>> DeleteAsync(int id)
        {
            if (id < 0)
            {
                return BadRequest(_localizer["Invalid Id!"]);
            }

            var player = await _service.DeleteAsync(id);

            if (player == null)
            {
                return NotFound(_localizer["Player not found!"]);
            }

            return NoContent();
        }         
    }
}
