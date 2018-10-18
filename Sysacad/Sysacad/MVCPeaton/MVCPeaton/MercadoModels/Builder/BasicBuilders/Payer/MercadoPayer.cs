using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiFileUpload.DesktopClient.MercadoModels
{
   public class MercadoPayer
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string date_created { get; set; }
       
        public ClientPhone phone { get; set; }
        public ClientIdentification identification { get; set; }
        public ClientAddress address { get; set; }
    }
}
