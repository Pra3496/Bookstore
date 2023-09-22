using Bussiness.Interface;
using Common.Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Bussiness.Service
{
    public class BookBussiness : IBookBussiness
    {
        private readonly IBookRepository bookRepository;

        public BookBussiness(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public BookModel AddBook(BookModel model)
        {
            try
            {
                return this.bookRepository.AddBook(model);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public IEnumerable<BookModel> GetAllBook()
        {
            try
            {
                return this.bookRepository.GetAllBook();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public bool UpdateBook(BookModel model)
        {
            try
            {
                return this.bookRepository.UpdateBook(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool DeleteBook(long BookId)
        {
            try
            {
                return this.bookRepository.DeleteBook(BookId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
