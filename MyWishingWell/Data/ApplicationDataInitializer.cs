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

                //users
                User jane_doe = new User { Email = "user@hogent.be", UserName = "jane_doe" };
                _dbContext.AppUsers.Add(jane_doe);
                await CreateUser(jane_doe.Email, "passwordaz");

                User john_doe = new User { Email = "user2@hogent.be", UserName = "john_doe" };
                _dbContext.AppUsers.Add(john_doe);
                await CreateUser(john_doe.Email, "passwordaz");

                User jef = new User { Email = "jef@hogent.be", UserName = "jef" };
                _dbContext.AppUsers.Add(jef);
                await CreateUser(jef.Email, "passwordaz");

                User frances = new User { Email = "frances@hogent.be", UserName = "frances" };
                _dbContext.AppUsers.Add(frances);
                await CreateUser(frances.Email, "passwordaz");

                User kamil = new User { Email = "kamil@hogent.be", UserName = "kamil" };
                _dbContext.AppUsers.Add(kamil);
                await CreateUser(kamil.Email, "passwordaz");

                User anais = new User { Email = "anais@hogent.be", UserName = "anais" };
                _dbContext.AppUsers.Add(anais);
                await CreateUser(anais.Email, "passwordaz");

                User lowie = new User { Email = "lowie@hogent.be", UserName = "lowie" };
                _dbContext.AppUsers.Add(lowie);
                await CreateUser(lowie.Email, "passwordaz");

                _dbContext.SaveChanges();

                //wishlists
                //jef
                WishListItem wish1_jef = new WishListItem(
                   "https://www.bol.com/nl/p/star-wars-the-mandalorian-the-child-baby-yoda-plush/9300000000507606/?bltgh=owunjUwDupT7q8Hvn-RMZg.1_4.11.ProductImage",
                   "The child From The Mandolorian",
                   "33euro cute doll");
                jef.WishList.Add(wish1_jef);
                _dbContext.SaveChanges();

                WishListItem wish2_jef = new WishListItem(
                "https://www.bol.com/nl/p/luminarc-diwali-zwart-servies-set-19-delig-opaal/9300000000244441/?bltgh=htPB2Prax3FpYe-k3lxCag.1_4.5.ProductImage", "The child From The Mandolorian",
                  "47 euro zwart servies");
                jef.WishList.Add(wish2_jef);
                _dbContext.SaveChanges();

                WishListItem wish3_jef = new WishListItem(
                   "https://www.bol.com/nl/p/google-chromecast-3-media-streamer/9200000099487091/?promo=main_802_POPE_B3_product_1_&bltgh=jYAIeao-I2qezLot2HJNJA.8_gq0DzlgPFjDM-g7F2r9Ixg_0.2.ProductImage",
                   "chromecast",
                   "39euro");
                jef.WishList.Add(wish3_jef);
                _dbContext.SaveChanges();

                //frances
                WishListItem wish1_frances = new WishListItem(
                  "https://www.bol.com/nl/p/star-wars-the-mandalorian-the-child-baby-yoda-plush/9300000000507606/?bltgh=owunjUwDupT7q8Hvn-RMZg.1_4.11.ProductImage",
                  "The child From The Mandolorian",
                  "33euro cute doll");
                frances.WishList.Add(wish1_frances);
                _dbContext.SaveChanges();

                WishListItem wish2_frances = new WishListItem(
                 "https://www.bol.com/nl/p/korona-21675-retro-vintage-broodrooster-mint-groen/9200000110130123/",
                  "vintage toaster",
                  "munt groene vintage broodrooster voor 71 euro: MUST HAVE");
                frances.WishList.Add(wish2_frances);
                _dbContext.SaveChanges();

                WishListItem wish3_frances = new WishListItem(
                "https://www.bol.com/nl/p/gadgy-retro-popcornmaker/9200000087359351/",
                "retro popcornmaker",
                  "27,90 euro voor rood popcornmachien");
                frances.WishList.Add(wish3_frances);
                _dbContext.SaveChanges();

                //kamil
                WishListItem wish1_kamil = new WishListItem(
                "https://www.bol.com/nl/p/denver-vpl-150bt-platenspeler-retro/9200000083078070/",                  
                "platenspeler",
                  "78 euro op bol");
                kamil.WishList.Add(wish1_kamil);
                _dbContext.SaveChanges();

                WishListItem wish2_kamil = new WishListItem(
                "https://www.bol.com/nl/p/vidaxl-driezitsbank-stof-lichtgrijs/9200000063677996/?bltgh=rhVncmV4SEQJYCKsjCpHog.1_41.47.ProductImage", 
                "zetel", 
                "grijze scandinavische zetel, normaal kopen ouders deze");
                kamil.WishList.Add(wish2_kamil);

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
