using Microsoft.AspNetCore.Identity;
using MyWishingWell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWishingWell.Data
{
    public class ApplicationDataInitializer
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public ApplicationDataInitializer(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                User user1 = new User { Email = "user@hogent.be", UserName = "jane_doe"};
                _dbContext.AppUsers.Add(user1);
                await CreateUser(user1.Email, "passwordaz");
                User user2 = new User { Email = "user2@hogent.be", UserName = "john_doe" };
                _dbContext.AppUsers.Add(user2);
                await CreateUser(user2.Email, "someotherpassword");
                _dbContext.SaveChanges();

                WishListItem wishListItemUser1 = new WishListItem(
                    "chromecast",
                    "https://www.bol.com/nl/p/google-chromecast-3-media-streamer/9200000099487091/?promo=main_802_POPE_B3_product_1_&bltgh=jYAIeao-I2qezLot2HJNJA.8_gq0DzlgPFjDM-g7F2r9Ixg_0.2.ProductImage",
                    "39euro");
                user1.WishList.Add(wishListItemUser1);
                _dbContext.SaveChanges();

                WishListItem wishListItemUser2 = new WishListItem(
                   "The child From The Mandolorian",
                   "https://www.bol.com/nl/p/star-wars-the-mandalorian-the-child-baby-yoda-plush/9300000000507606/?bltgh=owunjUwDupT7q8Hvn-RMZg.1_4.11.ProductImage",
                   "33euro cute doll");
                user2.WishList.Add(wishListItemUser2);
                _dbContext.SaveChanges();

            }
        }

        private async Task CreateUser(string email, string password)
        {
            var user = new IdentityUser { UserName = email, Email = email };
            await _userManager.CreateAsync(user, password);
        }
    }
}
