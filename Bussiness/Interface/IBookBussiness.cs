using Common.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Interface
{
    public interface IBookBussiness
    {
        public BookModel AddBook(BookModel model);

        public IEnumerable<BookModel> GetAllBook();

        public bool UpdateBook(BookModel model);

        public bool DeleteBook(long BookId);
    }
}
