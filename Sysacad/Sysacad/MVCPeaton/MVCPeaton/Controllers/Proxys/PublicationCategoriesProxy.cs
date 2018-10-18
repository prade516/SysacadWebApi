using HalClient.Net.Parser;
using MVCPeaton.Models.ModelBuilders;
using MVCPeaton.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPeaton.Controllers.Proxys
{
    public class PublicationCategoriesProxy : BaseProxy<PublicationCategoryVM>
    {
        protected override PublicationCategoryVM Fill(IRootResourceObject resource)
        {
            return PublicationCategoryBuilder.Fill(resource);
        }

        protected override List<PublicationCategoryVM> FillCollection(IRootResourceObject list)
        {
            return PublicationCategoryBuilder.FillCollection(list);
        }

        protected override string MyRelationEmbeeded()
        {
            throw new NotImplementedException();
        }

        protected override string MySpecificUrl()
        {
            return "/api/publicationcategories";
        }
    }
}