using HalClient.Net.Parser;
using MVCPeaton.Models.ModelBuilders;
using MVCPeaton.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPeaton.Controllers.Proxys
{
    public class ItemProxy : BaseProxy<ItemVM>
    {
        protected override ItemVM Fill(IRootResourceObject resource)
        {
            return ItemBuilder.Fill(resource);
        }

        protected override List<ItemVM> FillCollection(IRootResourceObject list)
        {
            return ItemBuilder.FillCollection(list);
        }

        protected override string MyRelationEmbeeded()
        {
            throw new NotImplementedException();
        }

        protected override string MySpecificUrl()
        {
            return "/api/items";
        }
    }
}