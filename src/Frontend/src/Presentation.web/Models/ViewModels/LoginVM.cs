﻿using System.ComponentModel.DataAnnotations;

namespace Presentation.web.Models.ViewModels
{
    public class LoginVM
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
