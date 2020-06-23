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
                User user1 = new User { Email = "user1@hogent.be", UserName = "jane_doe"};
                _dbContext.AppUsers.Add(user1);
                await CreateUser(user1.Email, "P@ssword1111");
                User user2 = new User { Email = "user2@hogent.be", UserName = "john_doe" };
                _dbContext.AppUsers.Add(user2);
                await CreateUser(user2.Email, "P@ssword1111");
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
