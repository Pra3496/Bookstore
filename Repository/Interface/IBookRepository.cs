﻿using Common.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface IBookRepository
    {
        public BookModel AddBook(BookModel model);

        public IEnumerable<BookModel> GetAllBook();
    }
}
