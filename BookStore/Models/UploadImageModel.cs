using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class UploadImageModel
    {
        [Required]
        [Display(Name = "Image")]
        public IFormFile SpeakerPicture { get; set; }
    }
}
