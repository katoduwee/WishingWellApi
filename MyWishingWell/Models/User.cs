using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyWishingWell.Models
{
    public class User
    {
        #region Fields
        private string _email;
        private string _username;
        #endregion

        #region Properties
        public int UserId { get; set; }

        public List<WishListItem> WishList { get; set; }

        public string Email
        {
            get { return _email; }
            set
            {
                if (IsValidMailAddress(value))
                {
                    _email = value;
                }
                else
                {
                    throw new ArgumentException("Please enter a valid emailaddress");
                }
            }
        }

        public bool IsValidMailAddress(string emailaddress)
        {
            return Regex.Match(emailaddress, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success;
        }

        public string UserName
        {
            get
            {
                return _username;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Please enter a username");
                else
                    _username = value;
            }
        }

        #endregion

        #region Methods
        public User()
        {
            WishList = new List<WishListItem>();
        }

        public User(string name, string email) : this()
        {
            UserName = name;
            Email = email;
        }

        #endregion



    }
}
