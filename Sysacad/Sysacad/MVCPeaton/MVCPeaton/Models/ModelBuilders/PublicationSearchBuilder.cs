using HalClient.Net.Parser;
using MVCPeaton.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPeaton.Models.ModelBuilders
{
    public class PublicationSearchBuilder
    {
        public static List<PublicationSearchVM> FillCollection(IRootResourceObject resource)
        {
            var embeeded = resource.Embedded["publications"].ToList();
            PublicationSearchVM publication;
            List<PublicationSearchVM> listdto = new List<PublicationSearchVM>();
            foreach (var item in embeeded)
            {
                publication = new PublicationSearchVM()
                {
                    Id = Int64.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("idpublication")).Value),
                    title = item.State.Values.FirstOrDefault(t => t.Name.Equals("Title")).Value,
                    tags = item.State.Values.FirstOrDefault(t => t.Name.Equals("tags")) == null ? String.Empty
                    : item.State.Values.FirstOrDefault(t => t.Name.Equals("tags")).Value,
                    description = item.State.Values.FirstOrDefault(t => t.Name.Equals("description")).Value,
                    maxquantity = Int32.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("maxquantity")) == null ? String.Empty
                    : item.State.Values.FirstOrDefault(t => t.Name.Equals("maxquantity")).Value),
                    termscondition = item.State.Values.FirstOrDefault(t => t.Name.Equals("termscondition")) == null ? String.Empty
                    : item.State.Values.FirstOrDefault(t => t.Name.Equals("termscondition")).Value,
                    visiblecondition = item.State.Values.FirstOrDefault(t => t.Name.Equals("visiblecondition")) == null ? String.Empty
                    : item.State.Values.FirstOrDefault(t => t.Name.Equals("visiblecondition")).Value,
                    photo = item.State.Values.FirstOrDefault(t => t.Name.Equals("photo")) == null ? String.Empty
                    : item.State.Values.FirstOrDefault(t => t.Name.Equals("photo")).Value,
                    idpublicationcategory = Int32.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("idpublicationcategory")).Value),
                    state = Int32.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("state")).Value),
                    MyLink = item.Links.First(t => t.Key.Equals("self")).Value.First(d => d.Rel.Equals("self")).Href.ToString(),
                    UpdateLink = item.Links.First(t => t.Key.Equals("update")).Value.First(d => d.Rel.Equals("update")).Href.ToString(),
                    DeleteLink = item.Links.First(t => t.Key.Equals("delete")).Value.First(d => d.Rel.Equals("delete")).Href.ToString(),
                    //MyTagCategoryLink = item.Links.First(t => t.Key.Equals("tagcategories")).Value.First(d => d.Rel.Equals("tagcategories")).Href.ToString()
                };
                listdto.Add(publication);
            };
            return listdto;
        }

        public static PublicationSearchVM Fill(IEmbeddedResourceObject resource)
        {
            return new PublicationSearchVM()
            {
                Id = Int64.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("idpublication")).Value),
                title = resource.State.Values.FirstOrDefault(t => t.Name.Equals("title")).Value,
                tags = resource.State.Values.FirstOrDefault(t => t.Name.Equals("tags")) == null ? String.Empty
                    : resource.State.Values.FirstOrDefault(t => t.Name.Equals("tags")).Value,
                description = resource.State.Values.FirstOrDefault(t => t.Name.Equals("description")).Value,
                state = Int32.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("state")).Value),
                idpublicationcategory = Int32.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("idpublicationcategory")).Value),
                MyLink = resource.Links.First(t => t.Key.Equals("self")).Value.First(d => d.Rel.Equals("self")).Href.ToString(),
                
                maxquantity = Int32.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("maxquantity")) == null ? String.Empty
                    : resource.State.Values.FirstOrDefault(t => t.Name.Equals("maxquantity")).Value),
                termscondition = resource.State.Values.FirstOrDefault(t => t.Name.Equals("termscondition")) == null ? String.Empty
                    : resource.State.Values.FirstOrDefault(t => t.Name.Equals("termscondition")).Value,
                visiblecondition = resource.State.Values.FirstOrDefault(t => t.Name.Equals("visiblecondition")) == null ? String.Empty
                    : resource.State.Values.FirstOrDefault(t => t.Name.Equals("visiblecondition")).Value,
                photo = resource.State.Values.FirstOrDefault(t => t.Name.Equals("photo")) == null ? String.Empty
                    : resource.State.Values.FirstOrDefault(t => t.Name.Equals("photo")).Value,
            };
        }
    }
}