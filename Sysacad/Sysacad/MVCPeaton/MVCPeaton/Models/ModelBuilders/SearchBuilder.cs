using HalClient.Net.Parser;
using MVCPeaton.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPeaton.Models.ModelBuilders
{
    public class SearchBuilder
    {
        public static SearchVM Fill(IRootResourceObject resource)
        {
            var Search = new SearchVM()
            {
                SearchTerms = resource.State.Values.FirstOrDefault(t => t.Name.Equals("searchterms")) == null ? string.Empty
                    : (resource.State.Values.FirstOrDefault(t => t.Name.Equals("searchterms")).Value),
                Businesses = new List<BusinessSearchVM>(),
                Publications = new List<PublicationSearchVM>(),
            };
            foreach (var itemsubnivel in resource.Embedded.Keys.Any(x => x == "businesses") ? resource.Embedded["businesses"].ToList() : new List<IEmbeddedResourceObject>())
                FillCollectionBusiness(Search, itemsubnivel);

            foreach (var itemsubnivel in resource.Embedded.Keys.Any(x => x == "publications") ? resource.Embedded["publications"].ToList() : new List<IEmbeddedResourceObject>())
                FillCollectionPublications(Search, itemsubnivel);

            return Search;
        }

        private static void FillCollectionBusiness(SearchVM search, IEmbeddedResourceObject itemsubnivel)
        {
            search.Businesses.Add(BusinessSearchBuilder.Fill(itemsubnivel));
        }

        private static void FillCollectionPublications(SearchVM search, IEmbeddedResourceObject itemsubnivel)
        {
            search.Publications.Add(PublicationSearchBuilder.Fill(itemsubnivel));
        }
    }
}