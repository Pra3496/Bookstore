using Common.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Interface
{
    public interface IWishlistBussiness
    {
        public bool AddToWishlist(WishlistModel model);

        public IEnumerable<WishlistModel> GetAllWishlist();

        public bool RemoveFromWishlist(long WishListId);
    }
}
