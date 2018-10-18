using HalClient.Net.Parser;
using MVCPeaton.Models.ModelBuilders;
using MVCPeaton.Models.ViewModels;
using MVCPeaton.Security;
using MVCPeaton.Tools.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVCPeaton.Controllers
{
    public class LocationController : BaseController<LocationVM>
    {
        #region Get Methods
        // GET: Location
        [Authorize(Roles = "Admin,Empleados,Empresas,User,Usuarios,NuevoRol")]
        public ActionResult Index(String name)
        {
            //string name = nameloc;
            Int32 top = 999;
            String orderby = "idprovince";
            String ascending = "asc";
            Int32 page = 1;
            String filtros = "?name=" + name + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page;
            List<LocationVM> list = this.ListForm(filtros).Result;
            return View("List",list);
        }

        protected override ActionResult MyAddForm()
        {
            return View("Insert", new InsertLocationVM() { provinces = SearchProvinces("?name=&top=100&orderby=idprovince&ascending=asc") });
        }

        protected override ActionResult MyUpdateForm(LocationVM vm)
        {
            return View("UpdateForm", vm);
        }
        
        protected override ActionResult MyDeleteForm(LocationVM vm)
        {
            return View("DeleteForm", vm);
        }

        [Authorize(Roles = "Admin,Empleados,Empresas,User,Usuarios,NuevoRol")]
        public ActionResult Search(Nullable<Int32> id, String name = "")
        {
            Int32 top = 999;
            String orderby = "idprovince";
            String ascending = "asc";
            Int32 page = 1;
            String filtros = "?name=" + name + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page;
            List<LocationVM> list;
            if (id == null)
                list = this.ListForm(filtros).Result;
            else
                list = this.SearchByProvince((Int32)id, filtros);
            return View("List", list);
        }

        private List<LocationVM> SearchByProvince(Int32 id, String filtros)
        {
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
                var response = Task.Run(() => client.GetAsync(new Uri(ProvinceController.baseUrl + "/api/provinces/" + id + "/locations" + filtros))).Result;
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
                        return listdto;
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

        private List<ProvinceVM> SearchProvinces(String filtros)
        {
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
                var response = Task.Run(() => client.GetAsync(new Uri(ProvinceController.baseUrl + "/api/provinces/" + filtros))).Result;
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
                        var listdto = ProvinceBuilder.FillCollection(response.Resource);
                        return listdto;
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
        #endregion
        #region Post Methods
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Add2(InsertLocationVM VM)
        {
            try
            {
                // En caso de ser invalido el ModelState.
                if (!ModelState.IsValid)
                    return View("AddForm");

                return this.AddCustom2(VM);
            }
            catch (Exception ex)
            {
                CompositeFillErrors cfe = HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                if (cfe != null)
                    ModelState.AddModelError(cfe.Field, cfe.Message);
                return View("List");
            }
        }

        public ActionResult AddCustom2(InsertLocationVM model)
        {
            bool success = false;
            HttpStatusCode code;
            string responseBody = "";
            using (var client = Factory.CreateClient())
            {
                client.HttpClient.DefaultRequestHeaders.Clear();
                client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));

                //if (Session["ApiToken"] != null)
                if (User.Identity.IsAuthenticated)
                {
                    DataValues datavalue = Decode();
                    client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", datavalue.Token);
                }
                string postBody = JsonConvert.SerializeObject(model);
                Task taskDownload = client.HttpClient.PostAsync((Myurl), new StringContent(postBody, Encoding.UTF8, "application/json"))
                    .ContinueWith(task =>
                    {
                        if (task.Status == TaskStatus.RanToCompletion)
                        {
                            var response = task.Result;

                            if (response.IsSuccessStatusCode)
                            {
                                success = true;
                                code = response.StatusCode;
                            }
                            else
                            {
                                code = response.StatusCode;
                                responseBody = response.Content.ReadAsStringAsync().Result;

                            }
                        }
                    });
                taskDownload.Wait();

            }
            if (success)
                return RedirectToAction("Index");
            throw new Exception();

        }

        public override ActionResult Update(LocationVM model)
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
        public override List<LocationVM> FillCollection(IRootResourceObject resource)
        {
            return LocationBuilder.FillCollection(resource);
        }
        
        protected override LocationVM Fill(IRootResourceObject resource)
        {
            return LocationBuilder.Fill(resource);
        }
        #endregion
        #region Override methods needed for base controller
        protected override string MySpecificUrl()
        {
            return "/api/locations";
        }

        public override String MyRelationEmbeeded()
        {
            return "locations";
        }
        #endregion
    }
}