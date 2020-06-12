using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWishingWell.Models
{
    public interface IUserRepository
    {
        User GetByEmail(string email);
        User GetByUsername(string username);
        void Add(User user);
        void Update(User user);
        void SaveChanges();
    }
}
