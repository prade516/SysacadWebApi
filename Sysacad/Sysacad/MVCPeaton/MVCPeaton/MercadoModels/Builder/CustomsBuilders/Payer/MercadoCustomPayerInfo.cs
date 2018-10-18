using MVCPeaton.MercadoModels.Builder.CustomsBuilders.Payer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPeaton.MercadoModels.Builder.CustomsBuilders
{
    public class MercadoCustomPayerInfo
    {
        public MercadoCustomPayerInfo(CustomClientPhone cp, CustomClientAddress ca)
        {
            phone = cp;
            address = ca;
        }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string registration_date { get; set; }
        public CustomClientPhone phone { get; set; }
        public CustomClientAddress address { get; set; }
    }
}