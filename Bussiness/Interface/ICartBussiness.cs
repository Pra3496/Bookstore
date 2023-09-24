using Common.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Interface
{
    public interface ICartBussiness
    {
        public bool AddToCart(CartModel model);

        public IEnumerable<CartModel> GetAllUsers();

        public bool DeleteFromCart(long CartId);
    }
}
