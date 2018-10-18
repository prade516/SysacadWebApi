using MVCPeaton.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HalClient.Net.Parser;
using MVCPeaton.Models.ModelBuilders;

namespace MVCPeaton.Controllers.Proxys
{
    public class BusinessProfileProxy : BaseProxy<BusinessProfileVM>
    {

        protected override BusinessProfileVM Fill(IRootResourceObject resource)
        {
            return BusinessProfileBuilder.Fill(resource);
        }

        protected override List<BusinessProfileVM> FillCollection(IRootResourceObject list)
        {
            return BusinessProfileBuilder.FillCollection(list);
        }

        protected override string MyRelationEmbeeded()
        {
            throw new NotImplementedException();
        }

        protected override string MySpecificUrl()
        {
            return "/api/businessprofiles";
        }
    }
}