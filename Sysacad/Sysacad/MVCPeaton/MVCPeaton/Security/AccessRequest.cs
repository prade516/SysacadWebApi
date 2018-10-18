using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPeaton.Security
{
    public class AccessRequest
    {
       public readonly string grant_type = "password";
       public string username { get; set; }
       public string password { get; set; }
        public AccessRequest(string user,string pass)
        {
            username = user;
            password = pass;
        }
    }
}