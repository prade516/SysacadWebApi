using HalClient.Net.Parser;
using MVCPeaton.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPeaton.Models.ModelBuilders
{
    public static class PhotoBuilder
    {
        public static List<PhotoVM> FillCollection(IRootResourceObject resource)
        {
            List<PhotoVM> listdto = new List<PhotoVM>();
            foreach (var item in resource.Embedded.Count == 0 ? new List<IEmbeddedResourceObject>() : resource.Embedded["links"].ToList())
            {
                var link = new PhotoVM()
                {
                    Id = Int64.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("idphoto")).Value),
                    photo = item.State.Values.FirstOrDefault(t => t.Name.Equals("photo")).Value,
                    MyLink = item.Links.First(t => t.Key.Equals("self")).Value.
                        First(d => d.Rel.Equals("self")).Href.ToString(),
                    UpdateLink = item.Links.First(t => t.Key.Equals("update")).Value.
                        First(d => d.Rel.Equals("update")).Href.ToString(),
                    DeleteLink = item.Links.First(t => t.Key.Equals("delete")).Value.
                        First(d => d.Rel.Equals("delete")).Href.ToString(),

                };
                listdto.Add(link);
            };
            return listdto;
        }

        public static PhotoVM Fill(IRootResourceObject resource)
        {
            return new PhotoVM()
            {
                Id = Int64.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("idphoto")).Value),
                photo = resource.State.Values.FirstOrDefault(t => t.Name.Equals("photo")).Value,
                MyLink = resource.Links.First(t => t.Key.Equals("self")).Value.
                        First(d => d.Rel.Equals("self")).Href.ToString(),
                UpdateLink = resource.Links.First(t => t.Key.Equals("update")).Value.
                        First(d => d.Rel.Equals("update")).Href.ToString(),
                DeleteLink = resource.Links.First(t => t.Key.Equals("delete")).Value.
                        First(d => d.Rel.Equals("delete")).Href.ToString(),
            };
        }
    }
}