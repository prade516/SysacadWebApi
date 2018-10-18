using HalClient.Net.Parser;
using MVCPeaton.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPeaton.Models.ModelBuilders
{
    public static class PublicationCategoryBuilder
    {
        public static List<PublicationCategoryVM> FillCollection(IRootResourceObject resource)
        {
            var embeeded = resource.Embedded["publicationcategories"].ToList();
            PublicationCategoryVM publicationcategory;
            List<PublicationCategoryVM> listdto = new List<PublicationCategoryVM>();
            foreach (var item in embeeded)
            {
                publicationcategory = new PublicationCategoryVM()
                {
                    Id = Int64.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("idpublicationcategory")).Value),
                    name = item.State.Values.FirstOrDefault(t => t.Name.Equals("name")) == null ? String.Empty : item.State.Values.FirstOrDefault(t => t.Name.Equals("name")).Value,
                    description = item.State.Values.FirstOrDefault(t => t.Name.Equals("description")) == null ? String.Empty : item.State.Values.FirstOrDefault(t => t.Name.Equals("description")).Value,
                    state = Int32.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("state")).Value),
                    MyLink = item.Links.First(t => t.Key.Equals("self")).Value.First(d => d.Rel.Equals("self")).Href.ToString(),
                    UpdateLink = item.Links.First(t => t.Key.Equals("update")).Value.First(d => d.Rel.Equals("update")).Href.ToString(),
                    DeleteLink = item.Links.First(t => t.Key.Equals("delete")).Value.First(d => d.Rel.Equals("delete")).Href.ToString()
                };
                listdto.Add(publicationcategory);
            };
            return listdto;
        }

        public static PublicationCategoryVM Fill(IRootResourceObject resource)
        {
            return new PublicationCategoryVM()
            {
                Id = Int64.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("idpublicationcategory")).Value),
                name = resource.State.Values.FirstOrDefault(t => t.Name.Equals("name")) == null ? String.Empty : resource.State.Values.FirstOrDefault(t => t.Name.Equals("name")).Value,
                description = resource.State.Values.FirstOrDefault(t => t.Name.Equals("description")) == null ? String.Empty : resource.State.Values.FirstOrDefault(t => t.Name.Equals("description")).Value,
                state = Int32.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("state")).Value),
                MyLink = resource.Links.First(t => t.Key.Equals("self")).Value.First(d => d.Rel.Equals("self")).Href.ToString()
            };
        }
    }
}