using System.ComponentModel.DataAnnotations;

namespace FootballManagerBLL.Dto.UserDto
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
