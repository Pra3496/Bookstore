using Bussiness.Interface;
using Common.Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Bussiness.Service
{
    public class WishlistBussiness : IWishlistBussiness
    {
        private readonly IWishlistRepository wishlistRepository;
        public WishlistBussiness(IWishlistRepository wishlistRepository)
        {
              this.wishlistRepository = wishlistRepository;
        }

        public bool AddToWishlist(WishlistModel model)
        {
            try
            {
                return this.wishlistRepository.AddToWishlist(model);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<WishlistModel> GetAllWishlist()
        {
            try
            {
                return this.wishlistRepository.GetAllWishlist();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool RemoveFromWishlist(long WishListId)
        {
            try
            {
                return this.wishlistRepository.RemoveFromWishlist(WishListId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
