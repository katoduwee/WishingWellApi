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
        /// Deletes a WishListItem from the wishlist
        /// </summary>
        /// <param name="id">the link of the WishListItem to be deleted</param>
        [HttpDelete("{link}")]
        public ActionResult<UserDTO> DeleteWishListItem(string link)
        {
            User user = _userRepository.GetByEmail(User.Identity.Name);
            if (user == null)
            {
                return NotFound();
            }
            var itemToRemove = user.WishList.SingleOrDefault(r => r.WishListItemLink == link);
            user.WishList.Remove(itemToRemove);
            _userRepository.Update(user);
            _userRepository.SaveChanges();
            var userDTO = new UserDTO()
            {
                Email = user.Email,
                UserName = user.UserName,
                WishList = user.WishList.Select(item => new WishListItemDTO()
                {
                    WishListItemLink = item.WishListItemLink,
                    WishListItemName = item.WishListItemName,
                    WishListItemDescription = item.WishListItemDescription
                }).ToList()
            };
            return userDTO;
        }

        /// <summary>
        /// Adds a WishListItem to the wishlist
        /// </summary>
        /// <param name="WishListItem">the WishListItem to be added</param>
        [HttpPost]
        public ActionResult<UserDTO> PostWishListItem(WishListItemDTO WishListItem)
        {
            User user = _userRepository.GetByEmail(User.Identity.Name);
            if (user == null)
            {
                return NotFound();
            }

            var WishListItemToCreate = new WishListItem(WishListItem.WishListItemName, WishListItem.WishListItemLink, WishListItem.WishListItemDescription);
            user.WishList.Add(WishListItemToCreate);
            _userRepository.Update(user);
            _userRepository.SaveChanges();
            var userDTO = new UserDTO()
            {
                Email = user.Email,
                UserName = user.UserName,
                WishList = user.WishList.Select(item => new WishListItemDTO()
                {
                    WishListItemLink = item.WishListItemLink,
                    WishListItemName = item.WishListItemName,
                    WishListItemDescription = item.WishListItemDescription
                }).ToList()
            };
            return userDTO;
        }

        /// <summary>
        /// Give all users you searched for
        /// </summary>
        /// <returns>All users which email contains partOfEmail</returns>
        [HttpGet("AllUsers/{partOfEmail}")]
        public IEnumerable<string> GetAllUsersContainingPartOfEmail(string partOfEmail)
        {
            if (string.IsNullOrWhiteSpace(partOfEmail))
            {
                return new List<string>();
            }
            else
            {
                IList<string> allUsersYouSearchedFor =
                _userRepository.GetAll().Where(u => u.Email.Contains(partOfEmail)).Select(u => u.Email).ToList();
                User user = _userRepository.GetByEmail(User.Identity.Name);
                allUsersYouSearchedFor.Remove(user.Email);
                return allUsersYouSearchedFor;
            }
        }

        /// <summary>
        /// View wishlist from another user
        /// </summary>
        /// <param></param>
        [HttpGet("{email}")]
        public ActionResult<UserDTO> GetWishlistFromOtherUser(string email)
        {
            User user = _userRepository.GetByEmail(email);
            var userDTO = new UserDTO()
            {
                Email = user.Email,
                UserName = user.UserName,
                WishList = user.WishList.Select(item => new WishListItemDTO()
                {
                    WishListItemLink = item.WishListItemLink,
                    WishListItemName = item.WishListItemName,
                    WishListItemDescription = item.WishListItemDescription
                }).ToList()
            };
            return userDTO;
        }
    }
}
