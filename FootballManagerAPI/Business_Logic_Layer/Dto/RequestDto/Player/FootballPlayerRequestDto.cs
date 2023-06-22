using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FootballManagerBLL.Dto.RequestDto.Player
{
    public class FootballPlayerRequestDto
    {
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name must not exceed 50 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name must not exceed 50 characters")]
        public string LastName { get; set; }

        [Range(1, 99, ErrorMessage = "Number must be between 1 and 99.")]
        [Remote(action: "IsPlayerNumberAvailable", controller: "Players", 
            ErrorMessage = "This player number is already taken. Please choose another number.")]
        public int Number { get; set; }
    }
}
