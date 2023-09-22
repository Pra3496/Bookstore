using Common.Model;
using Microsoft.Extensions.Configuration;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Text;

namespace Repository.Service
{
    public class BookRepository : IBookRepository
    {
        private SqlConnection connection;
        private readonly IConfiguration configuration;
        public readonly string connectionString;
        public BookRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = this.configuration.GetConnectionString("BookStoreDB");
        }



        private void Connection()
        {
            try
            {

                connection = new SqlConnection(this.connectionString);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public BookModel AddBook(BookModel model)
        {
            try
            {
                Connection();
                SqlCommand sqlCommand = new SqlCommand("spAddingNewDataBooks", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@BookName", model.BookName);
                sqlCommand.Parameters.AddWithValue("@Author", model.Author);
                sqlCommand.Parameters.AddWithValue("@Details", model.Details);
                sqlCommand.Parameters.AddWithValue("@Price", model.Price);
                sqlCommand.Parameters.AddWithValue("@Quantity", model.Quantity);
                sqlCommand.Parameters.AddWithValue("@Images", model.Images);

                connection.Open();
                int i = sqlCommand.ExecuteNonQuery();
                connection.Close();
                if (i <= 1)
                    return model;
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }


        public IEnumerable<BookModel> GetAllBook()
        {

            
            try
            {
                Connection();
                List<BookModel> BookList = new List<BookModel>();

              
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand("spRetriveBooks", connection);

                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlReader = sqlCommand.ExecuteReader();

                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            BookModel model = new BookModel();

                            model.BookId = sqlReader.GetInt64(0);
                            model.BookName = sqlReader.GetString(1);
                            model.Author = sqlReader.GetString(2);
                            model.Details = sqlReader.GetString(3);
                            model.Price = sqlReader.GetDouble(4);
                            model.Quantity = sqlReader.GetInt32(5);
                            model.Images = sqlReader.GetString(6);



                            BookList.Add(model);
                        }
                        connection.Close();
                        return BookList;


                    }
                    else
                    { return null; }
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }


        public bool UpdateBook(BookModel model)
        {
            

            try
            {
                Connection();
                connection.Open();

                    SqlCommand sqlCommand = new SqlCommand("spUpdateBookDeatils", connection);
                    
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@BookId", model.BookId);
                    sqlCommand.Parameters.AddWithValue("@BookName", model.BookName);
                    sqlCommand.Parameters.AddWithValue("@Author", model.Author);
                    sqlCommand.Parameters.AddWithValue("@Details", model.Details);
                    sqlCommand.Parameters.AddWithValue("@Price", model.Price);
                    sqlCommand.Parameters.AddWithValue("@Quantity", model.Quantity);
                    sqlCommand.Parameters.AddWithValue("@Images", model.Images);

                    int result = sqlCommand.ExecuteNonQuery();

                connection.Close();
                if (result >= 1)
                {
                    return true;
                }
                else { return false; } 

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                connection.Close();
            }


        }

        public bool DeleteBook(long BookId)
        {
            
            try
            {
                Connection();
                connection.Open();
                    SqlCommand sqlCommand = new SqlCommand("spDeleteBook", connection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@BookId", BookId);
                    int result = sqlCommand.ExecuteNonQuery();
                    connection.Close();

                    if (result >= 1)
                    {
                        return true;
                    }
                    else { return false; }
               

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }








    }
}
