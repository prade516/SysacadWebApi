using HalClient.Net.Parser;
using MVCPeaton.Models.ModelBuilders;
using MVCPeaton.Models.ViewModels;
using MVCPeaton.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVCPeaton.Controllers
{
    public class ProvinceController : BaseController<ProvinceVM>
    {
        #region Get Methods
        [Authorize(Roles = "Admin,Empleados,Empresas,User,Usuarios,NuevoRol")]
        public ActionResult Index(String name)
        {
            //top = 5 & orderby = idprovince & ascending = asc & page = 2
            //string name = nameprov;
            Int32 top = 100;
            String orderby = "idprovince";
            String ascending = "asc";
            Int32 page = 1;
            String filtros = "?name=" + name + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page;
            List<ProvinceVM> list = this.ListForm(filtros).Result;
            return View("List",list);
        }

        public JsonResult SearchByProvince(Int32 idprovince, String name = "")
        {
            Int32 top = 999;
            String orderby = "idprovince";
            String ascending = "asc";
            Int32 page = 1;
            String filtros = "?name=" + name + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page;

            using (var client = Factory.CreateClient())
            {
                client.HttpClient.DefaultRequestHeaders.Clear();
                client.HttpClient.DefaultRequestHeaders.Add("Accept", "application/hal+json");
                HttpStatusCode code;
                String responseBody = "";
                if (User.Identity.IsAuthenticated)
                {
                    DataValues datavalue = Decode();
                    client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", datavalue.Token);
                }
                var response = Task.Run(() => client.GetAsync(new Uri(Myurl + "/" + idprovince + "/locations" + filtros))).Result;
                if (response.IsHalResponse)
                {
                    if (response.Message.IsSuccessStatusCode)
                    {
                        // get the self link of the root resource
                        var selfUri = response.Resource.Links["self"].First().Href;
                        var findUri = response.Resource.Links["find"].First().Href;
                        var next = response.Resource.Links.ContainsKey("next") ?
                            response.Resource.Links["next"].FirstOrDefault().Href : new Uri("Http://N/A");
                        var prev = response.Resource.Links.ContainsKey("prev") ?
                            response.Resource.Links["prev"].FirstOrDefault().Href : new Uri("Http://N/A");
                        var first = response.Resource.Links.ContainsKey("first") ?
                            response.Resource.Links["first"].FirstOrDefault().Href : new Uri("Http://N/A");
                        var last = response.Resource.Links.ContainsKey("last") ?
                            response.Resource.Links["last"].FirstOrDefault().Href : new Uri("Http://N/A");
                        var listdto = LocationBuilder.FillCollection(response.Resource);
                        return Json(listdto, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        code = response.Message.StatusCode;
                        responseBody = response.Message.Content.ReadAsStringAsync().Result;

                    }
                }
                throw new Exception();
            }
        }

        protected override ActionResult MyAddForm()
        {
            return View("Insert", new ProvinceVM());
        }

        protected override ActionResult MyDeleteForm(ProvinceVM vm)
        {
            return View("DeleteForm", vm);
        }
        
        protected override ActionResult MyUpdateForm(ProvinceVM vm)
        {
            return View("Update", vm);
        }
        #endregion
        #region Post methods Roles = All
        public override ActionResult Add(ProvinceVM model)
        {
            try
            {
                return base.Add(model);
            }
            catch
            {
                return View("Error");
            }
        }

        public override ActionResult Update(ProvinceVM model)
        {
            try
            {
                return base.Update(model);
            }
            catch
            {
                return View("Error");
            }
        }
        #endregion
        #region FILLS
        public override List<ProvinceVM> FillCollection(IRootResourceObject resource)
        {
            return ProvinceBuilder.FillCollection(resource);
        }
        
        protected override ProvinceVM Fill(IRootResourceObject resource)
        {
            return ProvinceBuilder.Fill(resource);
        }
        #endregion
        #region Override methods needed for base controller
        protected override string MySpecificUrl()
        {
            return "/api/provinces";
        }

        public override string MyRelationEmbeeded()
        {
            return "provinces";
        }
        #endregion
    }
}