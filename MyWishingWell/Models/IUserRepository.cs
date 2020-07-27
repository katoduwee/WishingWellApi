using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWishingWell.Models
{
    public interface IUserRepository
    {
        User GetByEmail(string email);
        IEnumerable<User> GetAll();
        void Add(User user);
        void Remove(string email);
        void Update(User user);
        void SaveChanges();
    }
}
