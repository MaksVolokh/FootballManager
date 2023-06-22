using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManagerBLL.Dto.RequestDto.Media
{
    public class CreateVideoRequest
    {
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [MaxLength(500, ErrorMessage = "Description can contain up to 500 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Video URL is required.")]
        [Url(ErrorMessage = "Invalid video URL.")]
        public string VideoUrl { get; set; }
    }
}
