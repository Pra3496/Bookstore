using Common.Model;
using Microsoft.Extensions.Configuration;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
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
                SqlCommand sqlCommand = new SqlCommand("spAddingNewDataUserDetails", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@FirstName", model.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", model.LastName);
                sqlCommand.Parameters.AddWithValue("@Email", model.Email);
                sqlCommand.Parameters.AddWithValue("@Password", model.Password);

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

        public IEnumerable<RegisterModel> GetAllUsers()
        {

            
            try
            {
                    Connection();
                    List<RegisterModel> UserList = new List<RegisterModel>();

                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand("spRetriveAllUsers", connection);

                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlReader = sqlCommand.ExecuteReader();

                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            RegisterModel model = new RegisterModel();

                            model.UserId = sqlReader.GetInt64(0);
                            model.FirstName = sqlReader.GetString(1);
                            model.LastName = sqlReader.GetString(2);
                            model.Email = sqlReader.GetString(3);
                            model.Password = sqlReader.GetString(4);



                            UserList.Add(model);
                        }
                        connection.Close();
                        return UserList;


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



        public bool UpdateUserDetails(RegisterModel model)
        {
            bool flags = false;
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                Connection();
                connection.Open();

                    SqlCommand sqlCommand = new SqlCommand("spUpdateUserDeatils", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@UserId", model.UserId);
                    sqlCommand.Parameters.AddWithValue("@FirstName", model.FirstName);
                    sqlCommand.Parameters.AddWithValue("@LastName", model.LastName);
                    sqlCommand.Parameters.AddWithValue("@Email", model.Email);
                    sqlCommand.Parameters.AddWithValue("@Password", model.Password);

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

        public bool DeleteUser(long UserId)
        {
            
            try
            {

                Connection();
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("spDeleteUser", connection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@UserId", UserId);
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
