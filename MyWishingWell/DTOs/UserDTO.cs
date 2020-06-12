using MyWishingWell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWishingWell.DTOs
{
    public class UserDTO
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public ICollection<WishListItem> WishList { get; set; }

        public UserDTO() { }

        public UserDTO(User user) : this()
        {
            UserName = user.UserName;
            Email = user.Email;
            WishList = user.WishList;
        }
    }
}
