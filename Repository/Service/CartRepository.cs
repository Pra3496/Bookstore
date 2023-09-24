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
    public class CartRepository : ICartRepository
    {
        private SqlConnection connection;
        private readonly IConfiguration configuration;
        public readonly string connectionString;
        public CartRepository(IConfiguration configuration)
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

        public bool AddToCart(CartModel model)
        {
            try
            {
                Connection();
                SqlCommand sqlCommand = new SqlCommand("spAddToCart", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@UserId", model.UserId);
                sqlCommand.Parameters.AddWithValue("@BookId", model.BookId);
                sqlCommand.Parameters.AddWithValue("@Quantity", model.Quantity);
                sqlCommand.Parameters.AddWithValue("@IsPurchesed", model.IsPurchesed);

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



        public IEnumerable<CartModel> GetAllUsers()
        {


            try
            {
                Connection();
                List<CartModel> CartList = new List<CartModel>();

                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("spGetAllItemFromCartWhichNotPurches", connection);

                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader sqlReader = sqlCommand.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        CartModel model = new CartModel();
                        model.CartId = sqlReader.GetInt64(0);
                        model.UserId = sqlReader.GetInt64(1);
                        model.BookId = sqlReader.GetInt64(2);
                        model.Quantity = sqlReader.GetInt32(3);
                        model.IsPurchesed = sqlReader.GetBoolean(4);




                        CartList.Add(model);
                    }
                    connection.Close();
                    return CartList;


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

        public bool DeleteFromCart(long CartId)
        {

            try
            {

                Connection();
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("spRemoveItemFromCartWhichNotPurches", connection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@CartId", CartId);
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
