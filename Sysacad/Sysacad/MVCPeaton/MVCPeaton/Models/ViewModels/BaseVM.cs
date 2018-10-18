using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPeaton.Models.ViewModels
{
    public abstract class BaseVM
    {
        public Int64 Id { get; set; }
        public string MyLink { get; set; }
        public string UpdateLink { get; set; }
        public string DeleteLink { get; set; }
    }
}