using HalClient.Net.Parser;
using MVCPeaton.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPeaton.Models.ModelBuilders
{
    public class PublicationBuilder
    {
        public static List<PublicationVM> FillCollection(IRootResourceObject resource)
        {
            var embeeded = resource.Embedded["publications"].ToList();
            PublicationVM publication;
            List<PublicationVM> listdto = new List<PublicationVM>();
            foreach (var item in embeeded)
            {
                 publication = new PublicationVM()
                {
                    Id = Int64.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("idpublication")).Value),
                    title = item.State.Values.FirstOrDefault(t => t.Name.Equals("title")) == null ? String.Empty : item.State.Values.FirstOrDefault(t => t.Name.Equals("title")).Value,
                    description = item.State.Values.FirstOrDefault(t => t.Name.Equals("description")).Value == null ? String.Empty : item.State.Values.FirstOrDefault(t => t.Name.Equals("description")).Value,
                    maxquantity = Int32.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("maxquantity")).Value),
                    termscondition = item.State.Values.FirstOrDefault(t => t.Name.Equals("termscondition")) == null ? String.Empty : item.State.Values.FirstOrDefault(t => t.Name.Equals("termscondition")).Value,
                    visiblecondition = item.State.Values.FirstOrDefault(t => t.Name.Equals("visiblecondition")) == null ? String.Empty : item.State.Values.FirstOrDefault(t => t.Name.Equals("visiblecondition")).Value,
                    photo = item.State.Values.FirstOrDefault(t => t.Name.Equals("photo")) == null ? String.Empty : item.State.Values.FirstOrDefault(t => t.Name.Equals("photo")).Value,
                    idpublicationcategory = Int32.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("idpublicationcategory")).Value),
                    state = Int32.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("state")).Value),
                    MyLink = item.Links.First(t => t.Key.Equals("self")).Value.First(d => d.Rel.Equals("self")).Href.ToString(),
                    UpdateLink = item.Links.First(t => t.Key.Equals("update")).Value.First(d => d.Rel.Equals("update")).Href.ToString(),
                    DeleteLink = item.Links.First(t => t.Key.Equals("delete")).Value.First(d => d.Rel.Equals("delete")).Href.ToString(),
                };
                listdto.Add(publication);
            };
            return listdto;
        }

        public static PublicationVM Fill(IRootResourceObject resource)
        {
            var publication = new PublicationVM()
            {
                Id = Int64.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("idpublication")).Value),
                title = resource.State.Values.FirstOrDefault(t => t.Name.Equals("title")) == null ? String.Empty : resource.State.Values.FirstOrDefault(t => t.Name.Equals("title")).Value,
                description = resource.State.Values.FirstOrDefault(t => t.Name.Equals("description")) == null ? String.Empty : resource.State.Values.FirstOrDefault(t => t.Name.Equals("description")).Value,
                state = Int32.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("state")).Value),
                maxquantity = Int32.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("maxquantity")).Value),
                termscondition = resource.State.Values.FirstOrDefault(t => t.Name.Equals("termscondition")) == null ? String.Empty : resource.State.Values.FirstOrDefault(t => t.Name.Equals("termscondition")).Value,
                visiblecondition = resource.State.Values.FirstOrDefault(t => t.Name.Equals("visiblecondition")) == null ? String.Empty : resource.State.Values.FirstOrDefault(t => t.Name.Equals("visiblecondition")).Value,
                photo = resource.State.Values.FirstOrDefault(t => t.Name.Equals("photo")) == null ? String.Empty : resource.State.Values.FirstOrDefault(t => t.Name.Equals("photo")).Value,
                idpublicationcategory = Int32.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("idpublicationcategory")).Value),
                MyLink = resource.Links.First(t => t.Key.Equals("self")).Value.First(d => d.Rel.Equals("self")).Href.ToString(),
                tags = new List<PublicationBCTagVM>()
            };
            foreach (var itemsubnivel in resource.Embedded.Keys.Any(x => x == "tags") ? resource.Embedded["tags"].ToList() : new List<IEmbeddedResourceObject>())
                FillCollectionTags(publication, itemsubnivel);
            return publication;
        }

        public static void FillCollectionTags(PublicationVM publication, IEmbeddedResourceObject itemsubnivel)
        {
            var tag = new PublicationBCTagVM()
            {
                Id = Int64.Parse(itemsubnivel.State.Values.FirstOrDefault(t => t.Name.Equals("idpublicationbctag")).Value),
                idbusinessconfigurationtag = Int64.Parse(itemsubnivel.State.Values.FirstOrDefault(t => t.Name.Equals("idbusinessconfigurationtag")).Value),
                idpublication = Int64.Parse(itemsubnivel.State.Values.FirstOrDefault(t => t.Name.Equals("idpublication")).Value),
                idtag = Int32.Parse(itemsubnivel.State.Values.FirstOrDefault(t => t.Name.Equals("idtag")).Value),
                name = itemsubnivel.State.Values.FirstOrDefault(t => t.Name.Equals("name")).Value,
                state = Int32.Parse(itemsubnivel.State.Values.FirstOrDefault(t => t.Name.Equals("state")) == null ? string.Empty :
                                        itemsubnivel.State.Values.FirstOrDefault(t => t.Name.Equals("state")).Value),
                MyLink = itemsubnivel.Links.First(t => t.Key.Equals("self")).Value.
                                    First(d => d.Rel.Equals("self")).Href.ToString(),
                ischecked = Int32.Parse(itemsubnivel.State.Values.FirstOrDefault(t => t.Name.Equals("state")).Value) == 1 ? true : false,
            };
            publication.tags.Add(tag);
        }
    }
}