using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Model
{
    public class RegisterModel
    {
        public long UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }    

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
