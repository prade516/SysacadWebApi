using HalClient.Net.Parser;
using MVCPeaton.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPeaton.Models.ModelBuilders
{
    public class BusinessSearchBuilder
    {
        public static List<BusinessSearchVM> FillCollection(IEmbeddedResourceObject resource)
        {
            List<BusinessSearchVM> listdto = new List<BusinessSearchVM>();
            foreach (var item in resource.Embedded.Count == 0 ? new List<IEmbeddedResourceObject>() : resource.Embedded["businesses"].ToList())
            {
                var business = new BusinessSearchVM()
                {
                    Id = Int64.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("idbusiness")).Value),
                    name = item.State.Values.FirstOrDefault(t => t.Name.Equals("name")) == null ? string.Empty
                    : item.State.Values.FirstOrDefault(t => t.Name.Equals("name")).Value,
                    address = item.State.Values.FirstOrDefault(t => t.Name.Equals("address")) == null ? string.Empty
                    : item.State.Values.FirstOrDefault(t => t.Name.Equals("address")).Value,

                    addressnumber = Int32.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("addressnumber")) == null ? string.Empty
                    : item.State.Values.FirstOrDefault(t => t.Name.Equals("addressnumber")).Value),
                    floor = item.State.Values.FirstOrDefault(t => t.Name.Equals("floor")) == null ? string.Empty
                    : item.State.Values.FirstOrDefault(t => t.Name.Equals("floor")).Value,
                    floornumber = item.State.Values.FirstOrDefault(t => t.Name.Equals("floornumber")) == null ? string.Empty
                    : item.State.Values.FirstOrDefault(t => t.Name.Equals("floornumber")).Value,
                     cuitcuilcdi = item.State.Values.FirstOrDefault(t => t.Name.Equals("cuitcuilcdi")) == null ? string.Empty
                    : item.State.Values.FirstOrDefault(t => t.Name.Equals("cuitcuilcdi")).Value,
                     email = item.State.Values.FirstOrDefault(t => t.Name.Equals("email")) == null ? string.Empty
                    : item.State.Values.FirstOrDefault(t => t.Name.Equals("email")).Value,
                     state = Int32.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("state")) == null ? string.Empty
                    : item.State.Values.FirstOrDefault(t => t.Name.Equals("state")).Value),

                    MyLink = item.Links.First(t => t.Key.Equals("self")).Value.
                        First(d => d.Rel.Equals("self")).Href.ToString(),
                    UpdateLink = item.Links.First(t => t.Key.Equals("update")).Value.
                        First(d => d.Rel.Equals("update")).Href.ToString(),
                    DeleteLink = item.Links.First(t => t.Key.Equals("delete")).Value.
                        First(d => d.Rel.Equals("delete")).Href.ToString()
                };
                listdto.Add(business);
            };
            return listdto;
        }

        public static BusinessSearchVM Fill(IEmbeddedResourceObject resource)
        {
            return new BusinessSearchVM()
            {
                Id = Int64.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("idbusiness")).Value),
                name = resource.State.Values.FirstOrDefault(t => t.Name.Equals("name")) == null ? string.Empty
                    : resource.State.Values.FirstOrDefault(t => t.Name.Equals("name")).Value,
                address = resource.State.Values.FirstOrDefault(t => t.Name.Equals("address")) == null ? string.Empty
                    : resource.State.Values.FirstOrDefault(t => t.Name.Equals("address")).Value,
                tags = resource.State.Values.FirstOrDefault(t => t.Name.Equals("tags")) == null ? string.Empty : resource.State.Values.FirstOrDefault(t => t.Name.Equals("tags")).Value,
                addressnumber = Int32.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("addressnumber")) == null ? string.Empty
                    : resource.State.Values.FirstOrDefault(t => t.Name.Equals("addressnumber")).Value),
                floor = resource.State.Values.FirstOrDefault(t => t.Name.Equals("floor")) == null ? string.Empty
                    : resource.State.Values.FirstOrDefault(t => t.Name.Equals("floor")).Value,
                floornumber = resource.State.Values.FirstOrDefault(t => t.Name.Equals("floornumber")) == null ? string.Empty
                    : resource.State.Values.FirstOrDefault(t => t.Name.Equals("floornumber")).Value,
                cuitcuilcdi = resource.State.Values.FirstOrDefault(t => t.Name.Equals("cuitcuilcdi")) == null ? string.Empty
                    : resource.State.Values.FirstOrDefault(t => t.Name.Equals("cuitcuilcdi")).Value,
                email = resource.State.Values.FirstOrDefault(t => t.Name.Equals("email")) == null ? string.Empty
                    : resource.State.Values.FirstOrDefault(t => t.Name.Equals("email")).Value,
                state = Int32.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("state")) == null ? string.Empty
                    : resource.State.Values.FirstOrDefault(t => t.Name.Equals("state")).Value),

                MyLink = resource.Links.First(t => t.Key.Equals("self")).Value.
                        First(d => d.Rel.Equals("self")).Href.ToString(),
                //UpdateLink = resource.Links.First(t => t.Key.Equals("update")).Value.
                //        First(d => d.Rel.Equals("update")).Href.ToString(),
                //DeleteLink = resource.Links.First(t => t.Key.Equals("delete")).Value.
                //        First(d => d.Rel.Equals("delete")).Href.ToString()
            };
        }
    }
}