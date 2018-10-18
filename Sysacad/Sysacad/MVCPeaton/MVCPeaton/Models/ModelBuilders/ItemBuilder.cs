using HalClient.Net.Parser;
using MVCPeaton.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPeaton.Models.ModelBuilders
{
    public static class ItemBuilder
    {
        public static List<ItemVM> FillCollection(IRootResourceObject resource)
        {
            List<ItemVM> listdto = new List<ItemVM>();
            foreach (var item in resource.Embedded.Count == 0 ? new List<IEmbeddedResourceObject>() : resource.Embedded["items"].ToList())
            {
                var Item = new ItemVM()
                {
                    Id = Int64.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("IdItem")).Value),
                    Name = item.State.Values.FirstOrDefault(t => t.Name.Equals("Name")) == null ? String.Empty : item.State.Values.FirstOrDefault(t => t.Name.Equals("Name")).Value,
                    MyLink = item.Links.First(t => t.Key.Equals("self")).Value.
                        First(d => d.Rel.Equals("self")).Href.ToString(),
                    UpdateLink = item.Links.First(t => t.Key.Equals("update")).Value.
                        First(d => d.Rel.Equals("update")).Href.ToString(),
                    DeleteLink = item.Links.First(t => t.Key.Equals("delete")).Value.
                        First(d => d.Rel.Equals("delete")).Href.ToString()
                };
                listdto.Add(Item);
            };
            return listdto;
        }

        public static ItemVM Fill(IRootResourceObject resource)
        {
            return new ItemVM()
            {
                Id = Int64.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("IdItem")).Value),
                Name = resource.State.Values.FirstOrDefault(t => t.Name.Equals("Name")).Value,
                MyLink = resource.Links.First(t => t.Key.Equals("self")).Value.
                        First(d => d.Rel.Equals("self")).Href.ToString(),
            };
        }
    }
}