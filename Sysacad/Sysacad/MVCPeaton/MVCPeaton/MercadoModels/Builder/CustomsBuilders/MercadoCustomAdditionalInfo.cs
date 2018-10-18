using MVCPeaton.MercadoModels.Builder.CustomsBuilders.Payer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPeaton.MercadoModels.Builder.CustomsBuilders
{
    public class MercadoCustomAdditionalInfo
    {
        //private CustomClientPhone _cp;
        //private CustomClientAddress _ca;
        //public MercadoCustomAdditionalInfo(CustomClientPhone cp, CustomClientAddress ca)
        //{
        //    _cp = cp;
        //    _ca = ca;
        //}
       public List<MercadoCustomItem> items=new List<MercadoCustomItem>();
        public MercadoCustomPayerInfo payer;
    }
}