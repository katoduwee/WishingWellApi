using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWishingWell.Models
{
    public class WishListItem
    {
        #region Fields
        private string _wishListItemname;
        private string _wisListItemlink;
        #endregion

        #region Properties
        public int WishListItemId { get; set; }
        public string WishListItemDescription { get; set; }

        public string WishListItemName
        {
            get
            {
                return _wishListItemname;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Please enter a name for the item");
                else
                    _wishListItemname = value;
            }
        }

        public string WishListItemLink
        {
            get
            {
                return _wisListItemlink;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Please enter a link for the item");
                else
                    _wisListItemlink = value;
            }
        }

        #endregion

        #region Methods
        public WishListItem()
        {
        }

        public WishListItem(string name, string link, string description) : this()
        {
            WishListItemName = name;
            WishListItemLink = link;
            WishListItemDescription = description;
        }

        #endregion

    }
}

