using HalClient.Net.Parser;
using MVCPeaton.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPeaton.Models.ModelBuilders
{
    public static class ProvinceBuilder
    {
        public static List<ProvinceVM> FillCollection(IRootResourceObject resource)
        {
            List<ProvinceVM> listdto = new List<ProvinceVM>();
            foreach (var item in resource.Embedded.Count == 0 ? new List<IEmbeddedResourceObject>() : resource.Embedded["provinces"].ToList())
            {
                var province = new ProvinceVM()
                {
                    Id = Int64.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("idprovince")).Value),
                    Name = item.State.Values.FirstOrDefault(t => t.Name.Equals("name")) == null ? string.Empty
                    : item.State.Values.FirstOrDefault(t => t.Name.Equals("name")).Value,
                    Country = item.State.Values.FirstOrDefault(t => t.Name.Equals("country")) == null ? string.Empty
                    : item.State.Values.FirstOrDefault(t => t.Name.Equals("country")).Value,
                    MyLink = item.Links.First(t => t.Key.Equals("self")).Value.
                        First(d => d.Rel.Equals("self")).Href.ToString(),
                    UpdateLink = item.Links.First(t => t.Key.Equals("update")).Value.
                        First(d => d.Rel.Equals("update")).Href.ToString(),
                    DeleteLink = item.Links.First(t => t.Key.Equals("delete")).Value.
                        First(d => d.Rel.Equals("delete")).Href.ToString(),
                    MyLocationsLink = item.Links.First(t => t.Key.Equals("locations")).Value.
                        First(d => d.Rel.Equals("locations")).Href.ToString(),
                };
                listdto.Add(province);
            };
            return listdto;
        }

        public static ProvinceVM Fill(IRootResourceObject resource)
        {
            return new ProvinceVM()
            {
                Id = Int64.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("idprovince")).Value),
                Name = resource.State.Values.FirstOrDefault(t => t.Name.Equals("name")) == null ? string.Empty
                    : resource.State.Values.FirstOrDefault(t => t.Name.Equals("name")).Value,
                Country = resource.State.Values.FirstOrDefault(t => t.Name.Equals("country")) == null ? string.Empty
                    : resource.State.Values.FirstOrDefault(t => t.Name.Equals("country")).Value,
                MyLink = resource.Links.First(t => t.Key.Equals("self")).Value.
                        First(d => d.Rel.Equals("self")).Href.ToString(),
                UpdateLink = resource.Links.First(t => t.Key.Equals("update")).Value.
                        First(d => d.Rel.Equals("update")).Href.ToString(),
                DeleteLink = resource.Links.First(t => t.Key.Equals("delete")).Value.
                        First(d => d.Rel.Equals("delete")).Href.ToString(),
                MyLocationsLink = resource.Links.First(t => t.Key.Equals("locations")).Value.
                        First(d => d.Rel.Equals("locations")).Href.ToString(),
            };
        }
    }
}