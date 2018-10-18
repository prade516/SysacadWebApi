using HalClient.Net.Parser;
using MVCPeaton.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPeaton.Models.ModelBuilders
{
    public class BusinessBuilder
    {
        public static List<RegisterBusinessVM> FillCollection(IRootResourceObject resource)
        {
            List<RegisterBusinessVM> listdto = new List<RegisterBusinessVM>();
            if (resource.Embedded.ContainsKey("business"))
            {
                foreach (var item in resource.Embedded["business"].ToList())
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

        public static RegisterBusinessVM Fill(IEmbeddedResourceObject resource)
        {
            RegisterBusinessVM rb= new RegisterBusinessVM()
            {
                address = resource.State.Values.FirstOrDefault(t => t.Name.Equals("address")) == null ? String.Empty
                     : resource.State.Values.FirstOrDefault(t => t.Name.Equals("address")).Value,
                addressnumber = resource.State.Values.FirstOrDefault(t => t.Name.Equals("addressnumber")) == null ?
                0 : Int32.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("addressnumber")).Value),
                businesstype = resource.State.Values.FirstOrDefault(t => t.Name.Equals("businesstype")).Value.ToString(),
                cuitcuilcdi = resource.State.Values.FirstOrDefault(t => t.Name.Equals("cuitcuilcdi")).Value.ToString(),
                floor = resource.State.Values.FirstOrDefault(t => t.Name.Equals("floor")) == null ?
                String.Empty : resource.State.Values.FirstOrDefault(t => t.Name.Equals("floor")).Value.ToString(),
                floornumber = resource.State.Values.FirstOrDefault(t => t.Name.Equals("floornumber")) == null ?
                String.Empty : resource.State.Values.FirstOrDefault(t => t.Name.Equals("floornumber")).Value.ToString(),
                 idbusiness= Int64.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("idbusiness")).Value),
                  idprovince= resource.State.Values.FirstOrDefault(t => t.Name.Equals("idprovince")) == null ?
                    0 : Int32.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("idprovince")).Value),
                   idplayeruser= resource.State.Values.FirstOrDefault(t => t.Name.Equals("idplayeruser")) == null ?
                    0 : Int64.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("idplayeruser")).Value),
                    name= resource.State.Values.FirstOrDefault(t => t.Name.Equals("name")).Value.ToString(),
                     idtypedocument= Int64.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("idtypedocument")).Value),
                      playeruserid = Int64.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("idtypedocument")).Value),
                responsablename = resource.State.Values.FirstOrDefault(t => t.Name.Equals("responsablename")).Value.ToString(),
                responsablephone = resource.State.Values.FirstOrDefault(t => t.Name.Equals("responsablephone")).Value.ToString(),
                Email = resource.State.Values.FirstOrDefault(t => t.Name.Equals("Email")) == null ? String.Empty
                     : resource.State.Values.FirstOrDefault(t => t.Name.Equals("Email")).Value,
                idlocation = Int32.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("idlocation")).Value),
                state = Int32.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("state")).Value),
                Username = resource.State.Values.FirstOrDefault(t => t.Name.Equals("Username")) == null ? String.Empty
                     : resource.State.Values.FirstOrDefault(t => t.Name.Equals("Username")).Value,




                //MyLink = item.Links.First(t => t.Key.Equals("self")).Value.
                //    First(d => d.Rel.Equals("self")).Href.ToString(),
                //UpdateLink = item.Links.First(t => t.Key.Equals("update")).Value.
                //    First(d => d.Rel.Equals("update")).Href.ToString(),
                //DeleteLink = item.Links.First(t => t.Key.Equals("delete")).Value.
                //    First(d => d.Rel.Equals("delete")).Href.ToString(),
                //MyProvinceLink = item.Links.First(t => t.Key.Equals("province")).Value.
                //    First(d => d.Rel.Equals("province")).Href.ToString(),
            };




            if (rb.playeruserid > 0)
            {
                rb.CreatePlayerUser = Boolean.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("CreatePlayerUser")).Value);
                rb.birthdate = DateTime.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("addressnumber")).Value);
                rb.birthdate2 = resource.State.Values.FirstOrDefault(t => t.Name.Equals("addressnumber")).Value.ToString();
                rb.publicname = resource.State.Values.FirstOrDefault(t => t.Name.Equals("publicname")) == null ? String.Empty
                     : resource.State.Values.FirstOrDefault(t => t.Name.Equals("publicname")).Value;
                rb.profilephoto = resource.State.Values.FirstOrDefault(t => t.Name.Equals("profilephoto")).Value;
                rb.genre = resource.State.Values.FirstOrDefault(t => t.Name.Equals("genre")) == null ? String.Empty
                     : resource.State.Values.FirstOrDefault(t => t.Name.Equals("genre")).Value;
                rb.profession = resource.State.Values.FirstOrDefault(t => t.Name.Equals("profession")) == null ? String.Empty
                     : resource.State.Values.FirstOrDefault(t => t.Name.Equals("profession")).Value;
                rb.dni = resource.State.Values.FirstOrDefault(t => t.Name.Equals("dni")).Value;
                rb.stateplayeruser = Int32.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("state")).Value);
            }
            return rb;
        }

        public static UpdateBusinessVM FillUpdate(IRootResourceObject resource)
        {
            UpdateBusinessVM rb = new UpdateBusinessVM()
            {
                address = resource.State.Values.FirstOrDefault(t => t.Name.Equals("address")) == null ? String.Empty
                     : resource.State.Values.FirstOrDefault(t => t.Name.Equals("address")).Value,
                addressnumber = resource.State.Values.FirstOrDefault(t => t.Name.Equals("addressnumber")) == null ?
                0 : Int32.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("addressnumber")).Value),
                businesstype = resource.State.Values.FirstOrDefault(t => t.Name.Equals("businesstype")).Value.ToString(),
                cuitcuilcdi = resource.State.Values.FirstOrDefault(t => t.Name.Equals("cuitcuilcdi")).Value.ToString(),
                floor = resource.State.Values.FirstOrDefault(t => t.Name.Equals("floor")) == null ?
                String.Empty : resource.State.Values.FirstOrDefault(t => t.Name.Equals("floor")).Value.ToString(),
                floornumber = resource.State.Values.FirstOrDefault(t => t.Name.Equals("floornumber")) == null ?
                String.Empty : resource.State.Values.FirstOrDefault(t => t.Name.Equals("floornumber")).Value.ToString(),
                idbusiness = Int64.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("idbusiness")).Value),
                idprovince = resource.State.Values.FirstOrDefault(t => t.Name.Equals("idprovince")) == null ?
                    0 : Int32.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("idprovince")).Value),
                idplayeruser = resource.State.Values.FirstOrDefault(t => t.Name.Equals("idplayeruser")) == null ?
                    0 : Int64.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("idplayeruser")).Value),
                name = resource.State.Values.FirstOrDefault(t => t.Name.Equals("name")).Value.ToString(),
                idtypedocument = Int64.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("idtypedocument")).Value),
                playeruserid = Int64.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("playeruserid")).Value),
                responsablename = resource.State.Values.FirstOrDefault(t => t.Name.Equals("responsablename")).Value.ToString(),
                responsablephone = resource.State.Values.FirstOrDefault(t => t.Name.Equals("responsablephone")).Value.ToString(),
                Email = resource.State.Values.FirstOrDefault(t => t.Name.Equals("email")) == null ? String.Empty
                     : resource.State.Values.FirstOrDefault(t => t.Name.Equals("email")).Value,
                idlocation = Int32.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("idlocation")).Value),
                state = Int32.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("state")).Value),
                Username = resource.State.Values.FirstOrDefault(t => t.Name.Equals("username")) == null ? String.Empty
                     : resource.State.Values.FirstOrDefault(t => t.Name.Equals("username")).Value,




                //MyLink = item.Links.First(t => t.Key.Equals("self")).Value.
                //    First(d => d.Rel.Equals("self")).Href.ToString(),
                //UpdateLink = item.Links.First(t => t.Key.Equals("update")).Value.
                //    First(d => d.Rel.Equals("update")).Href.ToString(),
                //DeleteLink = item.Links.First(t => t.Key.Equals("delete")).Value.
                //    First(d => d.Rel.Equals("delete")).Href.ToString(),
                //MyProvinceLink = item.Links.First(t => t.Key.Equals("province")).Value.
                //    First(d => d.Rel.Equals("province")).Href.ToString(),
            };



            rb.CreatePlayerUser = false;
            if (rb.playeruserid > 1)
            {
                rb.CreatePlayerUser = true;
                var pu=resource.Embedded["playerusers"].First();
                rb.birthdate = DateTime.Parse(pu.State.Values.FirstOrDefault(t => t.Name.Equals("birthdate")).Value);
                rb.birthdate2 = pu.State.Values.FirstOrDefault(t => t.Name.Equals("birthdate")).Value.ToString();
                rb.publicname = pu.State.Values.FirstOrDefault(t => t.Name.Equals("publicname")) == null ? String.Empty
                     : pu.State.Values.FirstOrDefault(t => t.Name.Equals("publicname")).Value;
                rb.profilephoto = pu.State.Values.FirstOrDefault(t => t.Name.Equals("profilephoto")).Value;
                rb.genre = pu.State.Values.FirstOrDefault(t => t.Name.Equals("genre")) == null ? String.Empty
                     : pu.State.Values.FirstOrDefault(t => t.Name.Equals("genre")).Value;
                rb.profession = pu.State.Values.FirstOrDefault(t => t.Name.Equals("profession")) == null ? String.Empty
                     : pu.State.Values.FirstOrDefault(t => t.Name.Equals("profession")).Value;
                rb.dni = pu.State.Values.FirstOrDefault(t => t.Name.Equals("dni")).Value;
                rb.stateplayeruser = Int32.Parse(pu.State.Values.FirstOrDefault(t => t.Name.Equals("state")).Value);
            }
            return rb;
        }
    }
}