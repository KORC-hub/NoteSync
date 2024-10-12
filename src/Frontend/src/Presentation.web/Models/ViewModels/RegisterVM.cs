using System.ComponentModel.DataAnnotations;

namespace Presentation.web.Models.ViewModels
{
    public class RegisterVM
    {
        [Required]
        public string Nickname { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }
    }
}
