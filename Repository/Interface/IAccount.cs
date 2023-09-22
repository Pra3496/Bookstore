using Common.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface IAccount
    {
        public RegisterModel RegisterUser(RegisterModel model);

        public IEnumerable<RegisterModel> GetAllUsers();

        public bool UpdateUserDetails(RegisterModel model);

        public bool DeleteUser(long UserId);
    }
}
