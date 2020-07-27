using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWishingWell.DTOs
{
    public class RegisterDTO : LoginDTO
    {
        [Required(ErrorMessage = "Please provide a username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter your password again")]
        [Compare("Password", ErrorMessage = "Password and passwordconfirmation must be the same")]
        public string PasswordConfirmation { get; set; }
    }
}
