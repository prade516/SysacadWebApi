using HalClient.Net.Parser;
using MVCPeaton.Models.ModelBuilders;
using MVCPeaton.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPeaton.Controllers.Proxys
{
    public class TagProxy : BaseProxy<TagVM>
    {
        protected override TagVM Fill(IRootResourceObject resource)
        {
            return TagBuilder.Fill(resource);
        }

        protected override List<TagVM> FillCollection(IRootResourceObject list)
        {
            return TagBuilder.FillCollection(list);
        }

        protected override string MyRelationEmbeeded()
        {
            throw new NotImplementedException();
        }

        protected override string MySpecificUrl()
        {
            return "/api/tags";
        }
    }
}