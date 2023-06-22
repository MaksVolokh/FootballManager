using System.ComponentModel.DataAnnotations;

namespace FootballManagerBLL.Dto.RequestDto.Coach
{
    public class CoachRequestDto
    {
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name must not exceed 50 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name must not exceed 50 characters")]
        public string LastName { get; set; }
    }
}
