using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Model
{
    public class CartModel
    {
        public long CartId { get; set; }
       public long UserId { get; set; }
        public long BookId { get; set; }
        public long Quantity { get; set; }

        public bool IsPurchesed { get; set; }
    }
}
