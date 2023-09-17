using Common.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Interface
{
    public interface IAccountBussiness
    {
        public RegisterModel RegisterUser(RegisterModel model);
    }
}
