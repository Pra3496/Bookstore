using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Model
{
    public class CartViewModel
    {
        public long CartId { get; set; }
        public long UserId { get; set; }
        public long BookId { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public string Details { get; set; }
        public double Price { get; set; }
        public string Images { get; set; }
    }

}
