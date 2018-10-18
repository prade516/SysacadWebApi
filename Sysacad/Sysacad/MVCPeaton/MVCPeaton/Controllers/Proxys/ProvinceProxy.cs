using HalClient.Net.Parser;
using MVCPeaton.Models.ModelBuilders;
using MVCPeaton.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPeaton.Controllers.Proxys
{
    public class ProvinceProxy : BaseProxy<ProvinceVM>
    {
        protected override ProvinceVM Fill(IRootResourceObject resource)
        {
            return ProvinceBuilder.Fill(resource);
        }

        protected override List<ProvinceVM> FillCollection(IRootResourceObject list)
        {
            return ProvinceBuilder.FillCollection(list);
        }

        protected override string MyRelationEmbeeded()
        {
            throw new NotImplementedException();
        }

        protected override string MySpecificUrl()
        {
            return "/api/provinces";
        }
    }
}