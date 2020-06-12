using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWishingWell.DTOs;
using MyWishingWell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWishingWell.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class WishListController: ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public WishListController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Get wishlist
        /// </summary>
        /// <param></param>
        [HttpGet]
        public ActionResult<List<WishListItem>> GetWishlist()
        {
            User user = _userRepository.GetBy(User.Identity.Name);
            return user.WishList;
        }

        /// <summary>
        /// Deletes a WishListItem from the wishlist
        /// </summary>
        /// <param name="id">the id of the WishListItem to be deleted</param>
        [HttpDelete("{id}")]
        public ActionResult<List<WishListItem>> DeleteWishListItem(int id)
        {
            User user = _userRepository.GetBy(User.Identity.Name);
            if (user == null)
            {
                return NotFound();
            }
            var itemToRemove = user.WishList.SingleOrDefault(r => r.WishListItemId == id);
            user.WishList.Remove(itemToRemove);
            _userRepository.Update(user);
            _userRepository.SaveChanges();
            return user.WishList;
        }

        /// <summary>
        /// Adds a WishListItem to the wishlist
        /// </summary>
        /// <param name="WishListItem">the WishListItem to be added</param>
        [HttpPost]
        public ActionResult<List<WishListItem>> PostWishListItem(WishListItemDTO WishListItem)
        {
            User user = _userRepository.GetBy(User.Identity.Name);
            if (user == null)
            {
                return NotFound();
            }
            var WishListItemToCreate = new WishListItem(WishListItem.WishListItemName, WishListItem.Link);
            user.WishList.Add(WishListItemToCreate);
            _userRepository.Update(user);
            _userRepository.SaveChanges();
            return user.WishList;
        }
    }
}
