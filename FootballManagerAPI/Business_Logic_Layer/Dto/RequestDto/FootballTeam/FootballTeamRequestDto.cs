
using System.ComponentModel.DataAnnotations;

namespace FootballManagerBLL.Dto.RequestDto.FootballTeam
{
    public class FootballTeamRequestDto
    {
        [Required(ErrorMessage = "Team name is required.")]
        [StringLength(50, ErrorMessage = "Team name must not exceed 50 characters")]
        public string TeamName { get; set; }
    }
}
