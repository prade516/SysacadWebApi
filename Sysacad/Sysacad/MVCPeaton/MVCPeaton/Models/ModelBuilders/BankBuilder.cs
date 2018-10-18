using HalClient.Net.Parser;
using MVCPeaton.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPeaton.Models.ModelBuilders
{
    public static class BankBuilder
    {
        public static List<BankVM> FillCollection(IRootResourceObject list)
        {
            var embeeded = list.Embedded.Count == 0 ? new List<IEmbeddedResourceObject>() : list.Embedded["banks"].ToList();
            List<BankVM> listdto = new List<BankVM>();
            foreach (var item in embeeded)
            {
                BankVM bank = new BankVM()
                {
                    Id = Int64.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("idbank")).Value),
                    Name = item.State.Values.FirstOrDefault(t => t.Name.Equals("name")).Value,
                    Logo = item.State.Values.FirstOrDefault(t => t.Name.Equals("logo"))==null ? string.Empty:
                    item.State.Values.FirstOrDefault(t => t.Name.Equals("logo")).Value,
                    MyLink = item.Links.First(t => t.Key.Equals("self")).Value.
                        First(d => d.Rel.Equals("self")).Href.ToString(),
                    UpdateLink = item.Links.First(t => t.Key.Equals("update")).Value.
                        First(d => d.Rel.Equals("update")).Href.ToString(),
                    DeleteLink = item.Links.First(t => t.Key.Equals("delete")).Value.
                        First(d => d.Rel.Equals("delete")).Href.ToString()

                };
                listdto.Add(bank);
            };
            return listdto;
        }
        public static BankVM Fill(IRootResourceObject resource)
        {
            return new BankVM()
            {
                Id = Int64.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("Id")).Value),
                Name = resource.State.Values.FirstOrDefault(t => t.Name.Equals("name")).Value,
                Logo = resource.State.Values.FirstOrDefault(t => t.Name.Equals("logo")).Value,
                MyLink = resource.Links.First(t => t.Key.Equals("self")).Value.
                       First(d => d.Rel.Equals("self")).Href.ToString(),
            };
        }
    }
}