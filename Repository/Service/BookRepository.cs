using Common.Model;
using Microsoft.Extensions.Configuration;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
                SqlCommand cmd = new SqlCommand("spAddingNewDataBooks", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookName", model.BookName);
                cmd.Parameters.AddWithValue("@Author", model.Author);
                cmd.Parameters.AddWithValue("@Details", model.Details);
                cmd.Parameters.AddWithValue("@Price", model.Price);
                cmd.Parameters.AddWithValue("@Quantity", model.Quantity);
                cmd.Parameters.AddWithValue("@Images", model.Images);

                connection.Open();
                int i = cmd.ExecuteNonQuery();
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

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                List<BookModel> BookList = new List<BookModel>();

                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("spRetriveBooks", sqlConnection);

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

                        return BookList;


                    }
                    else
                    { return null; }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }









    }
}
