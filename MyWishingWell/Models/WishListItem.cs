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
        private string _link;
        //private string _photo;
        #endregion


        #region Properties
        public int WishListItemId { get; set; }
        public string Description { get; set; }

        public string WishListItemName
        {
            get
            {
                return _wishListItemname;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Please enter a WishListItemname");
                else
                    _wishListItemname = value;
            }
        }

        public string Link
        {
            get
            {
                return _link;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Please enter a link");
                else
                    _link = value;
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
            Link = link;
            Description = description;
        }

        #endregion

    }
}

