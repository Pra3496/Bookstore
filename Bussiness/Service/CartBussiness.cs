using Bussiness.Interface;
using Common.Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Bussiness.Service
{
    public class CartBussiness : ICartBussiness
    {
        private readonly ICartRepository cartRepository;
        public CartBussiness(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }


        public bool AddToCart(CartModel model)
        {
            try
            {
                return this.cartRepository.AddToCart(model);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<CartModel> GetAllUsers()
        {
            try
            {
                return this.cartRepository.GetAllUsers();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool DeleteFromCart(long CartId)
        {
            try
            {
                return this.cartRepository.DeleteFromCart(CartId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
