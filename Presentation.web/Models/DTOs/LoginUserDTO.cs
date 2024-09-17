using System.ComponentModel.DataAnnotations;

namespace Presentation.web.Models.DTOs
{
    public class LoginUserDTO
    {
        [Required]
        [Display(Name = "Nombre")]
        public string Nickname { get; set; }
        
        [Required]
        [Display(Name = "Correo")]
        public string Email { get; set; }
        
        [Required]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

    }
}
