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

        public List<WishListItemDTO> WishList { get; set; }

    }
}
