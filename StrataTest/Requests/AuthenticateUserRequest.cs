using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StrataTest.Requests
{
    public class AuthenticateUserRequest
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}