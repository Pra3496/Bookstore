using Common.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface ICartRepository
    {
        public bool AddToCart(CartModel model);

        public IEnumerable<CartModel> GetAllUsers();

        public bool DeleteFromCart(long CartId);
    }
}
