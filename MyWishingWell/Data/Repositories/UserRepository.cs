using Microsoft.EntityFrameworkCore;
using MyWishingWell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWishingWell.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<User> _users;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _users = dbContext.AppUsers;
        }

        public void Add(User user)
        {
            _users.Add(user);
        }

        public void Update(User user)
        {
            _context.Update(user);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public User GetByEmail(string email)
        {
            return _users.Include(c => c.WishList)
                .SingleOrDefault(c => c.Email == email);
        }

        public User GetByUsername(string username)
        {
            return _users.Include(c => c.WishList)
                .SingleOrDefault(c => c.UserName == username);
        }
    }
}
