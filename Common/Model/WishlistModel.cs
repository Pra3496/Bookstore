using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Model
{
    public class WishlistModel
    {
        public long WishListId { get; set; }
        public long UserId { get; set; }
        public long BookId { get; set; }
    }
}
