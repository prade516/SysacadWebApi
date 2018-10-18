using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace MVCPeaton.Security
{
    public class DataValues
    {
        public string Token { get; set; }
        public string UserName { get; set; }
        public string Roles { get; set; }
        public string Claims { get; set; }
        public DateTime ExpireToken;
        public string PrincipalId { get; set; }


    }
}