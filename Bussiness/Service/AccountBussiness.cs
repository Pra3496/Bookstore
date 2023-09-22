using Bussiness.Interface;
using Common.Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Bussiness.Service
{
    public class AccountBussiness : IAccountBussiness
    {
        private readonly IAccount account;

        public AccountBussiness(IAccount account)
        {
            this.account = account; 
        }


        public RegisterModel RegisterUser(RegisterModel model)
        {
            try
            {
                return this.account.RegisterUser(model);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<RegisterModel> GetAllUsers()
        {
            try
            {
                return this.account.GetAllUsers();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public bool UpdateUserDetails(RegisterModel model)
        {
            try
            {
                return this.account.UpdateUserDetails(model);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public bool DeleteUser(long UserId)
        {
            try
            {
                return this.account.DeleteUser(UserId);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


    }
}
