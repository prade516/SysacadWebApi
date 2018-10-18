using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiFileUpload.DesktopClient.MercadoModels
{
   public class MercadoItem
    {
       public string id { get; set; }

        public string	title { get; set; }
        public string	currency_id { get; set; }
        public string	picture_url { get; set; }
        public string	description { get; set; }
        public string	category_id { get; set; } // Available categories at https://api.mercadopago.com/item_categories
        public int	quantity { get; set; }
        public double	unit_price { get; set; }
    }
}
