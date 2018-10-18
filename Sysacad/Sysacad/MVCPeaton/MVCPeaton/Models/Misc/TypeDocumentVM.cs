using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPeaton.Models.Misc
{
    public class TypeDocumentVM
    {
        public Int64 IdTypeDocument { get; set; }
        public string Name { get; set; }
        public Int32 State { get; set; }
    }
}