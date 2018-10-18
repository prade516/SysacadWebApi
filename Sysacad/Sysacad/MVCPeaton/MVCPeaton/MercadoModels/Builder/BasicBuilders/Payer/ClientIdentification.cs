using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiFileUpload.DesktopClient.MercadoModels
{
    public class ClientIdentification
    {
        public string type { get; set; } // Available ID types at https://api.mercadopago.com/v1/identification_types
        public string number { get; set; }
    }
}
