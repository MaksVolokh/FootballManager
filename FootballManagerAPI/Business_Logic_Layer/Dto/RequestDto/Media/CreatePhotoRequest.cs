
using System.ComponentModel.DataAnnotations;

namespace FootballManagerBLL.Dto.RequestDto.Media
{
    public class CreatePhotoRequest
    {
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(50, ErrorMessage = "Title must not exceed 50 characters")]
        public string Title { get; set; }

        [MaxLength(500, ErrorMessage = "Description can contain up to 500 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Photo URL is required.")]
        [Url(ErrorMessage = "Invalid photo URL.")]
        public string PhotoUrl { get; set; }
    }
}
