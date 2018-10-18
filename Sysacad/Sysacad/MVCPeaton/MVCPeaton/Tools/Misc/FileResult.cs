using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPeaton.Tools.Misc
{
    public class FileResult
    {

        public string LocalFilePath { get; set; }
        public string FileName { get; set; }
        public long FileLength { get; set; }
        //[JsonIgnore]
        public string UserName { get; set; }
        //[JsonIgnore]
        public Qualitiers Qualitier { get; set; }

    }
}