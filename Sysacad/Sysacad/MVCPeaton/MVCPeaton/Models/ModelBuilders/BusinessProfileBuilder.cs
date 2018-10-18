using HalClient.Net.Parser;
using MVCPeaton.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPeaton.Models.ModelBuilders
{
    public static class BusinessProfileBuilder
    {
       
        public static List<BusinessProfileVM> FillCollection(IRootResourceObject resource)
        {
            var photoEmbeeded = resource.Embedded["businessprofiles"].First().Embedded.Keys.Any(x => x == "photo") ? resource.Embedded["businessprofiles"].First().Embedded["photo"]: new List<IEmbeddedResourceObject>();
            var linkEmbeeded = resource.Embedded["businessprofiles"].First().Embedded.Keys.Any(x => x == "link") ? resource.Embedded["businessprofiles"].First().Embedded["link"] : new List<IEmbeddedResourceObject>();
           // var linkEmbeeded = resource.Embedded["businessprofiles"].First().Embedded["link"];

            List<BusinessProfileVM> listdto = new List<BusinessProfileVM>();
            foreach (var item in resource.Embedded.Count == 0 ? new List<IEmbeddedResourceObject>() : resource.Embedded["businessprofiles"].ToList())
            {
                var businesProfile = new BusinessProfileVM
                {
                    Id = Int64.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("Idbusiness")).Value),
                    idbusinessprofile = Int32.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("Idbusinessprofile")).Value),
                    coverphoto = item.State.Values.FirstOrDefault(t => t.Name.Equals("Coverphoto")) == null ? string.Empty :
                    item.State.Values.FirstOrDefault(t => t.Name.Equals("Coverphoto")).Value,
                    MyLink = item.Links.First(t => t.Key.Equals("self")).Value.
                        First(d => d.Rel.Equals("self")).Href.ToString(),
                    UpdateLink = item.Links.First(t => t.Key.Equals("update")).Value.
                        First(d => d.Rel.Equals("update")).Href.ToString(),
                    DeleteLink = item.Links.First(t => t.Key.Equals("delete")).Value.
                        First(d => d.Rel.Equals("delete")).Href.ToString(),
                    Linklink = item.Links.First(t => t.Key.Equals("link")).Value.First(d => d.Rel.Equals("link")).Href.ToString(),
                    Photolink = item.Links.First(t => t.Key.Equals("photo")).Value.First(d => d.Rel.Equals("photo")).Href.ToString(),
                    Photos = FillCollectionPhoto(photoEmbeeded),
                    Links = FillCollectionLink(linkEmbeeded)
                };
                
                listdto.Add(businesProfile);
            };
            return listdto;
        }

        public static BusinessProfileVM Fill(IRootResourceObject resource)
        {
            return new BusinessProfileVM()
            {
                Id = Int64.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("Idbusiness")).Value),
                idbusinessprofile = Int32.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("Idbusinessprofile")).Value),
                coverphoto = resource.State.Values.FirstOrDefault(t => t.Name.Equals("Coverphoto")) == null ? string.Empty :
                    resource.State.Values.FirstOrDefault(t => t.Name.Equals("Coverphoto")).Value,
                MyLink = resource.Links.First(t => t.Key.Equals("self")).Value.
                        First(d => d.Rel.Equals("self")).Href.ToString(),
                UpdateLink = resource.Links.First(t => t.Key.Equals("update")).Value.
                        First(d => d.Rel.Equals("update")).Href.ToString(),
                DeleteLink = resource.Links.First(t => t.Key.Equals("delete")).Value.
                        First(d => d.Rel.Equals("delete")).Href.ToString(),
            };
        }

        public static List<PhotoVM> FillCollectionPhoto(IEnumerable<IEmbeddedResourceObject> resource)
        {
            List<PhotoVM> listPhoto = new List<PhotoVM>();
            //foreach (var item in resource.Embedded.Count == 0 ? new List<IEmbeddedResourceObject>() : resource.Embedded["photo"].ToList())
            foreach (var item in resource)
            {
                var photo = new PhotoVM()
                {
                    idbusinessprofile = Int64.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("Idbusinessprofile")).Value),
                    idphoto = Int64.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("Idphoto")).Value),
                    photo = item.State.Values.FirstOrDefault(t => t.Name.Equals("Photo")) == null ? string.Empty :
                    item.State.Values.FirstOrDefault(t => t.Name.Equals("Photo")).Value,
                    state = Int32.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("State")).Value),
                    //MyLink = resource.Links.First(t => t.Key.Equals("self")).Value.
                    //    First(d => d.Rel.Equals("self")).Href.ToString(),
                    //UpdateLink = resource.Links.First(t => t.Key.Equals("update")).Value.
                    //    First(d => d.Rel.Equals("update")).Href.ToString(),
                    //DeleteLink = resource.Links.First(t => t.Key.Equals("delete")).Value.
                    //    First(d => d.Rel.Equals("delete")).Href.ToString(),

                };
                listPhoto.Add(photo);
            };
            return listPhoto;
        }

        public static List<LinkVM> FillCollectionLink(IEnumerable<IEmbeddedResourceObject> resource)
        {
            List<LinkVM> listLink = new List<LinkVM>();
            //foreach (var item in resource.Embedded.Count == 0 ? new List<IEmbeddedResourceObject>() : resource.Embedded["photo"].ToList())
            foreach (var item in resource)
            {
                var link = new LinkVM()
                {
                    idbusinessprofile = Int64.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("Idbusinessprofile")).Value),
                    idlink = Int64.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("idlink")).Value),
                    link = item.State.Values.FirstOrDefault(t => t.Name.Equals("Link")) == null ? string.Empty :
                    item.State.Values.FirstOrDefault(t => t.Name.Equals("Link")).Value,
                    state = Int32.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("State")).Value),
                    type = Int32.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("Type")).Value),
                    //MyLink = resource.Links.First(t => t.Key.Equals("self")).Value.
                    //    First(d => d.Rel.Equals("self")).Href.ToString(),
                    //UpdateLink = resource.Links.First(t => t.Key.Equals("update")).Value.
                    //    First(d => d.Rel.Equals("update")).Href.ToString(),
                    //DeleteLink = resource.Links.First(t => t.Key.Equals("delete")).Value.
                    //    First(d => d.Rel.Equals("delete")).Href.ToString(),

                };
                listLink.Add(link);
            };
            return listLink;
        }
    }
}