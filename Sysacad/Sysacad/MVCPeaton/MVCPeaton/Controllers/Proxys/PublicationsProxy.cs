using HalClient.Net.Parser;
using MVCPeaton.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCPeaton.Models.ModelBuilders;

namespace MVCPeaton.Controllers.Proxys
{
    public class PublicationsProxy : BaseProxy<PublicationVM>
    {
        protected override PublicationVM Fill(IRootResourceObject resource)
        {
            return PublicationBuilder.Fill(resource);
        }

        protected override List<PublicationVM> FillCollection(IRootResourceObject list)
        {
            return PublicationBuilder.FillCollection(list);
        }

        protected override string MyRelationEmbeeded()
        {
            throw new NotImplementedException();
        }

        protected override string MySpecificUrl()
        {
            return "/api/publications";
        }
    }
}