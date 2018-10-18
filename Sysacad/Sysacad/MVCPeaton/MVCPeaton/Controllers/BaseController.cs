using HalClient.Net;
using HalClient.Net.Parser;
using MVCPeaton.Models;
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
using System.Web.Security;

namespace MVCPeaton.Controllers
{
    public abstract class BaseController<VM> : Controller where VM : BaseVM
        
    {
		public readonly static string baseUrl = "http://localhost:40784";

		public DataValues Decode()
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null)
                throw new NotImplementedException();
            FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            DataValues md = JsonConvert.DeserializeObject<DataValues>(authTicket.UserData);
            return md;
        }

        private static IHalJsonParser parser;
        private static IHalHttpClientFactory factory;

        //public abstract bool AnonymousAction();
        // GET: Base
        private string myurl;
        public string Myurl
        {
            get
            {
                return baseUrl+MySpecificUrl();
            }

            set
            {
                ;
            }
        }

        private static IHalJsonParser Parser
        {
            get
            {
                if(parser==null)
                    parser= new HalJsonParser();
                return parser;
            }

            set
            {
                parser = value;
            }
        }

        public static IHalHttpClientFactory Factory
        {
            get
            {
                if(factory==null)
                    factory= new HalHttpClientFactory(Parser);
                return factory;
            }

            set
            {
                factory = value;
            }
        }

        public abstract string MyRelationEmbeeded();
        protected abstract string MySpecificUrl();

        #region GetForms

        
        public virtual ActionResult AddForm()
        {
            try
            {
                // En caso de ser invalido el ModelState.
                if (!ModelState.IsValid)
                    return View();

                return this.AddFormCustom();
            }
            catch (Exception ex)
            {
                CompositeFillErrors cfe = HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                if (cfe != null)
                    ModelState.AddModelError(cfe.Field, cfe.Message);
                return View();
            }
        }
        public virtual ActionResult UpdateForm(long id)
        {
            try
            {
                // En caso de ser invalido el ModelState.
                if (!ModelState.IsValid)
                    return View();

                return this.UpdateFormCustom(id);
            }
            catch (Exception ex)
            {
                //
                CompositeFillErrors cfe = HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                if (cfe != null)
                    ModelState.AddModelError(cfe.Field, cfe.Message);
                return View();
            }
        }
        public virtual ActionResult DeleteForm(long id)
        {
            try
            {
                // En caso de ser invalido el ModelState.
                if (!ModelState.IsValid)
                    return View();

                return this.DeleteFormCustom(id);
            }
            catch (Exception ex)
            {
                CompositeFillErrors cfe = HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                if (cfe != null)
                    ModelState.AddModelError(cfe.Field, cfe.Message);
                return View();
            }
        }
        
        public virtual ActionResult AddFormCustom()
        {
            return MyAddForm();
        }
        protected abstract ActionResult MyAddForm();

        public virtual ActionResult UpdateFormCustom(Int64 id)
        {
                using (var client = Factory.CreateClient())
                {
                    HttpStatusCode code;
                    string responseBody = "";
                    client.HttpClient.DefaultRequestHeaders.Clear();
                    client.HttpClient.DefaultRequestHeaders.Add("Accept", "application/hal+json");
                    if (User.Identity.IsAuthenticated)
                    {
                        DataValues datavalue = Decode();
                        client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", datavalue.Token);
                    }
                    var response = Task.Run(() => client.GetAsync(new Uri(Myurl + "/" + id))).Result;
                    if (response.IsHalResponse)
                    {
                        if (response.Message.IsSuccessStatusCode)
                        {
                            VM vm = this.Fill(response.Resource);
                            return MyUpdateForm(vm);
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
        protected abstract ActionResult MyUpdateForm(VM vm);

        public virtual ActionResult DeleteFormCustom(Int64 id)
        {
                HttpStatusCode code;
                string responseBody = "";
                using (var client = Factory.CreateClient())
                {
                    client.HttpClient.DefaultRequestHeaders.Clear();
                    client.HttpClient.DefaultRequestHeaders.Add("Accept", "application/hal+json");
                    if (User.Identity.IsAuthenticated)
                    {
                        DataValues datavalue = Decode();
                        client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", datavalue.Token);
                    }
                    var response = Task.Run(() => client.GetAsync(new Uri(Myurl + "/" + id))).Result;
                    if (response.IsHalResponse)
                    {
                        if (response.Message.IsSuccessStatusCode)
                        {
                            VM vm = this.Fill(response.Resource);
                            return MyDeleteForm(vm);
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
        protected abstract ActionResult MyDeleteForm(VM vm);
        public virtual async Task<List<VM>> ListForm(string filters)
        {
            //"?top=2&orderby=Id&ascending=asc&page=1"
           
                using (var client = Factory.CreateClient())
                {
                    client.HttpClient.DefaultRequestHeaders.Clear();
                    client.HttpClient.DefaultRequestHeaders.Add("Accept", "application/hal+json");
                    HttpStatusCode code;
                    string responseBody = "";
                    if (User.Identity.IsAuthenticated)
                    {
                        DataValues datavalue = Decode();
                        client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", datavalue.Token);
                    }
                    var response = Task.Run(() => client.GetAsync(new Uri(Myurl + filters))).Result;
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
                            var listdto = FillCollection(response.Resource);
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
        #region ActionMethods        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Add(VM model)
        {
            try
            {
                // En caso de ser invalido el ModelState.
                if (!ModelState.IsValid)
                    return View("AddForm");

                return this.AddCustom(model);
            }
            catch (Exception ex)
            {
                HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                return View("List");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Update(VM model)
        {
            try
            {
                // En caso de ser invalido el ModelState.
                if (!ModelState.IsValid)
                    return View("UpdateForm");

                return this.UpdateCustom(model);
            }
            catch (Exception ex)
            {
                HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                return View("List");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Delete(VM model)
        {
            try
            {
                // En caso de ser invalido el ModelState.
                if (!ModelState.IsValid)
                    return View("DeleteForm");

                return this.DeleteCustom(model);
            }
            catch (Exception ex)
            {
                HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                return View("List");
            }
        }

        public virtual ActionResult AddCustom(VM model)
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
        public virtual ActionResult UpdateCustom(VM model)
        {
            
                bool success = false;
                HttpStatusCode code;
                string responseBody = "";
                using (var client = Factory.CreateClient())
                {
                    client.HttpClient.DefaultRequestHeaders.Clear();
                    client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));
                    //if(Session["ApiToken"] != null)
                    //client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["ApiToken"].ToString());
                    if (User.Identity.IsAuthenticated)
                    {
                        DataValues datavalue = Decode();
                        client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", datavalue.Token);
                    }

                    string postBody = JsonConvert.SerializeObject(model);
                    Task taskDownload = client.HttpClient.PutAsync((Myurl + "/" + model.Id), new StringContent(postBody, Encoding.UTF8, "application/json"))
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
                                    ExceptionsFromStatusCodes(code,responseBody);
                                }
                            }
                        });
                    taskDownload.Wait();

                }
                if (success)
                    return RedirectToAction("Index");
                throw new Exception();
           }

        private void ExceptionsFromStatusCodes(HttpStatusCode code, string responseBody)
        {
            switch (code)
            {
                 case HttpStatusCode.BadRequest:
                     {
                 break;
                     }
                case HttpStatusCode.Unauthorized:
                    {
                        break;
                    }
                case HttpStatusCode.Forbidden:
                     {
                        break;
                     }
                case HttpStatusCode.GatewayTimeout:
                    {
                        break;
                    }
                case HttpStatusCode.Gone:
                    {
                        break;
                    }
                case HttpStatusCode.InternalServerError:
                    {
                        break;
                    }
                case HttpStatusCode.MethodNotAllowed:
                    {
                        break;
                    }
                case HttpStatusCode.NotAcceptable:
                    {
                        break;
                    }
                case HttpStatusCode.NotFound:
                    {
                        break;
                    }
                case HttpStatusCode.RequestTimeout:
                    {
                        break;
                    }
                case HttpStatusCode.ServiceUnavailable:
                    {
                        break;
                    }
                 case HttpStatusCode.UnsupportedMediaType:
                    {
                        break;
                    }
            }
        }

        public virtual ActionResult DeleteCustom(VM model)
        {
                bool success = false;
                HttpStatusCode code;
                string responseBody = "";
                using (var client = Factory.CreateClient())
                {
                    client.HttpClient.DefaultRequestHeaders.Clear();
                    client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));
                    if (User.Identity.IsAuthenticated)
                    {
                        DataValues datavalue = Decode();
                        client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", datavalue.Token);
                    }
                    string postBody = JsonConvert.SerializeObject(model);
                    Task taskDownload = client.HttpClient.DeleteAsync((Myurl + "/" + model.Id))
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
                return View();
        }

        public abstract List<VM> FillCollection(IRootResourceObject list);
        protected abstract VM Fill(IRootResourceObject resource);
        #endregion


    }
}