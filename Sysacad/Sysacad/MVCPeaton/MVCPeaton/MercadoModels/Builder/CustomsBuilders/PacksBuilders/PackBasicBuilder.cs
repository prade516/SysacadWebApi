using MVCPeaton.MercadoModels.Builder.CustomsBuilders.Payer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPeaton.MercadoModels.Builder.CustomsBuilders
{
    public class PackBasicBuilder : BaseCustomPackBuilder
    {
        public override List<MercadoCustomItem> BuildItems()
        {
            List<MercadoCustomItem> items = new List<MercadoCustomItem>();
            items.Add(new MercadoCustomItem()
            {
                category_id = "cat1",
                description = "desc1",
                id = "1",
                picture_url = "http://",
                quantity = 20,
                title = "titulo1",
                unit_price = 25
            });
            return items;
        }

        
    }
}