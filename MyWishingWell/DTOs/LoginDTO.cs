using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWishingWell.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Please provide an emailaddress")]
        [EmailAddress]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Please provide a valid emailaddress")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please provide a password")]
        [RegularExpression(".{10,}", ErrorMessage = "Password is at least 10 characters long")]
        public string Password { get; set; }
    }
}
