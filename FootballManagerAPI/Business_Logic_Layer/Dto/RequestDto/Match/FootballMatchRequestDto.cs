using System.ComponentModel.DataAnnotations;

namespace FootballManagerBLL.Dto.RequestDto.Match
{
    public class FootballMatchRequestDto
    {
        [Required(ErrorMessage = "MatchDate is required")]
        public DateTime MatchDate { get; set; }

        [Required(ErrorMessage = "Location is required")]
        [StringLength(100, ErrorMessage = "Location must not exceed 100 characters")]
        public string Location { get; set; }
    }
}
