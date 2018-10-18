using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiFileUpload.DesktopClient.MercadoModels
{
    public class MercadoPack
    {
       public List<MercadoItem> items = new List<MercadoItem>();
        public MercadoPayer payer = new MercadoPayer();
        public MercadoBackUrls back_urls = new MercadoBackUrls();
        public MercadoPaymentsMethods payment_methods = new MercadoPaymentsMethods();
        public string auto_return { get; set; }
        public string notification_url { get; set; }
        public string external_reference { get; set; }
        public bool expires { get; set; }
        public string expiration_date_from { get; set; }
        public string expiration_date_to { get; set; }
       
    }
}
