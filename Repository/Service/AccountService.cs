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
    public class AccountService : IAccount
    {
        private SqlConnection connection;
        private readonly IConfiguration configuration;
        public readonly string connectionString;
        public AccountService(IConfiguration configuration) 
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

        public RegisterModel RegisterUser(RegisterModel model)
        {
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("spAddingNewDataUserDetails", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
                cmd.Parameters.AddWithValue("@LastName", model.LastName);
                cmd.Parameters.AddWithValue("@Email", model.Email);
                cmd.Parameters.AddWithValue("@Password", model.Password);

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






    }
}
