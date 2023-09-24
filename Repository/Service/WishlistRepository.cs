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
    public class WishlistRepository : IWishlistRepository
    {
        private SqlConnection connection;
        private readonly IConfiguration configuration;
        public readonly string connectionString;
        public WishlistRepository(IConfiguration configuration)
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



        public bool AddToWishlist(WishlistModel model)
        {
            try
            {
                Connection();
                SqlCommand sqlCommand = new SqlCommand("spAddToWishList", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@UserId", model.UserId);
                sqlCommand.Parameters.AddWithValue("@BookId", model.BookId);
               

                connection.Open();
                int i = sqlCommand.ExecuteNonQuery();
                connection.Close();
                if (i <= 1)
                { return true; }
                else
                { return false; }
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


        public IEnumerable<WishlistModel> GetAllWishlist()
        {


            try
            {
                Connection();
                List<WishlistModel> Wishlistist = new List<WishlistModel>();

                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("spAddToWishListGetAll", connection);

                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader sqlReader = sqlCommand.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        WishlistModel model = new WishlistModel();

                        model.WishListId = sqlReader.GetInt64(0);
                        model.UserId = sqlReader.GetInt64(1);
                        model.BookId = sqlReader.GetInt64(2);

                        Wishlistist.Add(model);
                    }
                    connection.Close();
                    return Wishlistist;


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


        public bool RemoveFromWishlist(long WishListId)
        {

            try
            {

                Connection();
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("spAddToWishListDelete", connection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@WishListId", WishListId);
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


    }
}
