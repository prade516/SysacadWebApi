using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPeaton.MercadoModels.Builder.CustomsBuilders.Payer
{
    public class CustomClientAddress
    {
        public string street_name { get; set; }
        public int street_number { get; set; }
        public string zip_code { get; set; }
    }
}