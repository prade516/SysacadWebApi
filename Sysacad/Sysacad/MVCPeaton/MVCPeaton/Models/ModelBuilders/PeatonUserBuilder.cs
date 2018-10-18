using HalClient.Net.Parser;
using MVCPeaton.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPeaton.Models.ModelBuilders
{
    public static class PeatonUserBuilder
    {
        public static List<RegisterUserVM> FillCollection(IRootResourceObject resource)
        {
            List<RegisterUserVM> listdto = new List<RegisterUserVM>();
            if (resource.Embedded.ContainsKey("peatonusers"))
            {
                foreach (var item in resource.Embedded["peatonusers"].ToList())
                {
                    var vm = Fill(item);
                    listdto.Add(vm);
                };
                return listdto;
            }
            else
            {
                return null;
            }
        }

        public static RegisterUserVM Fill(IEmbeddedResourceObject resource)
        {
            return new RegisterUserVM()
            {
                address = resource.State.Values.FirstOrDefault(t => t.Name.Equals("address")) == null ? String.Empty
                     : resource.State.Values.FirstOrDefault(t => t.Name.Equals("address")).Value,
                addressnumber = resource.State.Values.FirstOrDefault(t => t.Name.Equals("addressnumber")) == null ? 
                0 : Int32.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("addressnumber")).Value),
                age = Int32.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("age")).Value),
                dni = resource.State.Values.FirstOrDefault(t => t.Name.Equals("dni")).Value,
                Email = resource.State.Values.FirstOrDefault(t => t.Name.Equals("Email")) == null ? String.Empty
                     : resource.State.Values.FirstOrDefault(t => t.Name.Equals("Email")).Value,
                FirstName = resource.State.Values.FirstOrDefault(t => t.Name.Equals("name")).Value,
                genre = resource.State.Values.FirstOrDefault(t => t.Name.Equals("genre")) == null ? String.Empty
                     : resource.State.Values.FirstOrDefault(t => t.Name.Equals("genre")).Value,
                idlocation = Int32.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("idlocation")).Value),
                LastName = resource.State.Values.FirstOrDefault(t => t.Name.Equals("lastname")).Value,
                profession = resource.State.Values.FirstOrDefault(t => t.Name.Equals("profession")) == null ? String.Empty
                     : resource.State.Values.FirstOrDefault(t => t.Name.Equals("profession")).Value,
                profilephoto = resource.State.Values.FirstOrDefault(t => t.Name.Equals("profilephoto")).Value,
                state = Int32.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("state")).Value),
                Username = resource.State.Values.FirstOrDefault(t => t.Name.Equals("Username")) == null ? String.Empty
                     : resource.State.Values.FirstOrDefault(t => t.Name.Equals("Username")).Value,
                idpeatonusers = Int64.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("idpeatonusers")).Value),

                //MyLink = item.Links.First(t => t.Key.Equals("self")).Value.
                //    First(d => d.Rel.Equals("self")).Href.ToString(),
                //UpdateLink = item.Links.First(t => t.Key.Equals("update")).Value.
                //    First(d => d.Rel.Equals("update")).Href.ToString(),
                //DeleteLink = item.Links.First(t => t.Key.Equals("delete")).Value.
                //    First(d => d.Rel.Equals("delete")).Href.ToString(),
                //MyProvinceLink = item.Links.First(t => t.Key.Equals("province")).Value.
                //    First(d => d.Rel.Equals("province")).Href.ToString(),
            };
        }

        public static UpdateUserVM FillUpdate(IRootResourceObject resource)
        {
            return new UpdateUserVM()
            {
                address = resource.State.Values.FirstOrDefault(t => t.Name.Equals("address")) == null ? String.Empty
                     : resource.State.Values.FirstOrDefault(t => t.Name.Equals("address")).Value,
                addressnumber = resource.State.Values.FirstOrDefault(t => t.Name.Equals("addressnumber")) == null ?
                0 : Int32.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("addressnumber")).Value),
                age = Int32.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("age")).Value),
                dni = resource.State.Values.FirstOrDefault(t => t.Name.Equals("dni")).Value,
                Email = resource.State.Values.FirstOrDefault(t => t.Name.Equals("email")) == null ? String.Empty
                     : resource.State.Values.FirstOrDefault(t => t.Name.Equals("email")).Value,
                FirstName = resource.State.Values.FirstOrDefault(t => t.Name.Equals("name")).Value,
                genre = resource.State.Values.FirstOrDefault(t => t.Name.Equals("genre")) == null ? String.Empty
                     : resource.State.Values.FirstOrDefault(t => t.Name.Equals("genre")).Value,
                idlocation = Int32.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("idlocation")).Value),
                LastName = resource.State.Values.FirstOrDefault(t => t.Name.Equals("lastname")).Value,
                profession = resource.State.Values.FirstOrDefault(t => t.Name.Equals("profession")) == null ? String.Empty
                     : resource.State.Values.FirstOrDefault(t => t.Name.Equals("profession")).Value,
                profilephoto = resource.State.Values.FirstOrDefault(t => t.Name.Equals("profilephoto")).Value,
                state = Int32.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("state")).Value),
                Username = resource.State.Values.FirstOrDefault(t => t.Name.Equals("username")) == null ? String.Empty
                     : resource.State.Values.FirstOrDefault(t => t.Name.Equals("username")).Value,
                idpeatonusers = Int64.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("idpeatonusers")).Value),

                //MyLink = item.Links.First(t => t.Key.Equals("self")).Value.
                //    First(d => d.Rel.Equals("self")).Href.ToString(),
                //UpdateLink = item.Links.First(t => t.Key.Equals("update")).Value.
                //    First(d => d.Rel.Equals("update")).Href.ToString(),
                //DeleteLink = item.Links.First(t => t.Key.Equals("delete")).Value.
                //    First(d => d.Rel.Equals("delete")).Href.ToString(),
                //MyProvinceLink = item.Links.First(t => t.Key.Equals("province")).Value.
                //    First(d => d.Rel.Equals("province")).Href.ToString(),
            };
        }


    }
}