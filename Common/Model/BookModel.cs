using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Common.Model
{
    public class BookModel
    {
        public long BookId { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public string Details { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Images { get; set; }
        public IFormFile UploadImages { get; set; }
    }
}
