using HalClient.Net.Parser;
using MVCPeaton.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPeaton.Models.ModelBuilders
{
    public static class LocationBuilder
    {
        public static List<LocationVM> FillCollection(IRootResourceObject resource)
        {
            List<LocationVM> listdto = new List<LocationVM>();
            foreach (var item in resource.Embedded.Count == 0 ? new List<IEmbeddedResourceObject>() : resource.Embedded["locations"].ToList())
            {
                var location = new LocationVM()
                {
                    Id = Int64.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("idlocation")).Value),
                    idprovince = Int32.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("idprovince")).Value),
                    Name = item.State.Values.FirstOrDefault(t => t.Name.Equals("name")) == null ? string.Empty:
                    item.State.Values.FirstOrDefault(t => t.Name.Equals("name")).Value,
                    MyLink = item.Links.First(t => t.Key.Equals("self")).Value.
                        First(d => d.Rel.Equals("self")).Href.ToString(),
                    UpdateLink = item.Links.First(t => t.Key.Equals("update")).Value.
                        First(d => d.Rel.Equals("update")).Href.ToString(),
                    DeleteLink = item.Links.First(t => t.Key.Equals("delete")).Value.
                        First(d => d.Rel.Equals("delete")).Href.ToString(),
                    MyProvinceLink = item.Links.First(t => t.Key.Equals("province")).Value.
                        First(d => d.Rel.Equals("province")).Href.ToString(),
                };
                listdto.Add(location);
            };
            return listdto;
        }

        public static LocationVM Fill(IRootResourceObject resource)
        {
            return new LocationVM()
            {
                Id = Int64.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("idlocation")).Value),
                idprovince = Int32.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("idprovince")).Value),
                Name = resource.State.Values.FirstOrDefault(t => t.Name.Equals("name")) == null ? string.Empty :
                    resource.State.Values.FirstOrDefault(t => t.Name.Equals("name")).Value,
                MyLink = resource.Links.First(t => t.Key.Equals("self")).Value.
                        First(d => d.Rel.Equals("self")).Href.ToString(),
                UpdateLink = resource.Links.First(t => t.Key.Equals("update")).Value.
                        First(d => d.Rel.Equals("update")).Href.ToString(),
                DeleteLink = resource.Links.First(t => t.Key.Equals("delete")).Value.
                        First(d => d.Rel.Equals("delete")).Href.ToString(),
                MyProvinceLink = resource.Links.First(t => t.Key.Equals("province")).Value.
                        First(d => d.Rel.Equals("province")).Href.ToString(),
            };
        }
    }
}