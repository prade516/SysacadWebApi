using HalClient.Net.Parser;
using MVCPeaton.Models.ModelBuilders;
using MVCPeaton.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPeaton.Controllers.Proxys
{
    public class LocationProxy : BaseProxy<LocationVM>
    {
        protected override LocationVM Fill(IRootResourceObject resource)
        {
            return LocationBuilder.Fill(resource);
        }

        protected override List<LocationVM> FillCollection(IRootResourceObject list)
        {
            return LocationBuilder.FillCollection(list);
        }

        protected override string MyRelationEmbeeded()
        {
            throw new NotImplementedException();
        }

        protected override string MySpecificUrl()
        {
            return "/api/locations";
        }
    }
}