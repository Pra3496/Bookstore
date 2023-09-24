using Common.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface IWishlistRepository
    {
        public bool AddToWishlist(WishlistModel model);

        public IEnumerable<WishlistModel> GetAllWishlist();

        public bool RemoveFromWishlist(long WishListId);
    }
}
