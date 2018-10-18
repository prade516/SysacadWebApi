using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiFileUpload.DesktopClient.MercadoModels;

namespace MVCPeaton.MercadoModels.Builder.CustomsBuilders
{
    public class CustomMercadoPack
    {
       
        public MercadoCustomPayer payer = new MercadoCustomPayer();
        public MercadoCustomMetaData metadata = new MercadoCustomMetaData();
        public MercadoCustomAdditionalInfo additional_info = new MercadoCustomAdditionalInfo();

        //custom
        public decimal transaction_amount { get; set; }
        public string token { get; set; }
        public string description { get; set; }
        public int installments { get; set; }
        public string payment_method_id { get; set; }
        public string external_reference { get; set; }
        public string statement_descriptor { get; set; }
        
        //Your houk
        public string notification_url { get; set; }

    }
}