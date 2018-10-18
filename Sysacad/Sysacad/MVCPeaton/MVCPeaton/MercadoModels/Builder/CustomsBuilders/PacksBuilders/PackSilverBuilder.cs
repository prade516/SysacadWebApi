using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPeaton.MercadoModels.Builder.CustomsBuilders
{
    public class PackSilverBuilder : BaseCustomPackBuilder
    {
        public override List<MercadoCustomItem> BuildItems()
        {
            List<MercadoCustomItem> items = new List<MercadoCustomItem>();
            items.Add(new MercadoCustomItem()
            {
                category_id = "cat2",
                description = "desc2",
                id = "2",
                picture_url = "http://",
                quantity = 21,
                title = "titulo2",
                unit_price = 30
            });
            return items;
        }
    }
}