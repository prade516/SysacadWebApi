using HalClient.Net;
using HalClient.Net.Parser;
using MVCPeaton.Enums;
using MVCPeaton.Models;
using MVCPeaton.Models.ModelBuilders;
using MVCPeaton.Models.ViewModels;
using MVCPeaton.Security;
using MVCPeaton.Security.Filters;
using MVCPeaton.Tools.Exceptions;
using MVCPeaton.Tools.Exceptions.CustomFormaterExceptions;
using MVCPeaton.Tools.Exceptions.Handlers;
using MVCPeaton.Tools.ListResolvers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Security;
using static MVCPeaton.Enums.RolesEnum;

namespace MVCPeaton.Controllers
{
    public class AccountController : Controller
    {

		public readonly static string baseUrl = "http://localhost:40784";

		private static IHalJsonParser parser;
        private static IHalHttpClientFactory factory;

        public DataValues Decode()
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null)
                throw new NotImplementedException();
            FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            DataValues md = JsonConvert.DeserializeObject<DataValues>(authTicket.UserData);
            return md;
        }

        public void GenerateCookie(DataValues md)
        {
            var ticket = new FormsAuthenticationTicket(1, md.UserName, DateTime.Now, md.ExpireToken, true, JsonConvert.SerializeObject(md));
            string encryptedTicket = FormsAuthentication.Encrypt(ticket);
            string[] roles = md.Roles.Split(',');
            GenericPrincipal userPrincipal = new GenericPrincipal(new GenericIdentity(md.UserName), roles);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            cookie.HttpOnly = true;
            Response.Cookies.Add(cookie);
        }

        #region UseSesion
        private const string ApiTokenKey = "ApiToken";
        private const string RolesTokenKey = "RolesToken";
        private const string ClaimsTokenKey = "ClaimsToken";
        private const string ExpireTokenKey = "ExpireToken";

        public object ApiToken
        {
            get { return Session != null ? Session[ApiTokenKey] : null; }
            set { if (Session != null) Session[ApiTokenKey] = value; }
        }
        public object RolesToken
        {
            get { return Session != null ? Session[RolesTokenKey] : null; }
            set { if (Session != null) Session[RolesTokenKey] = value; }
        }
        public object ClaimsToken
        {
            get { return Session != null ? Session[ClaimsTokenKey] : null; }
            set
            {
                if (Session != null && value != null)
                {
                    Session[ClaimsTokenKey] = value;
                }
            }
        }
        public object ExpireToken
        {
            get { return Session != null ? Session[ExpireTokenKey] : null; }
            set
            {
                if (Session != null && value != null)
                {
                    Session[ExpireTokenKey] = value;
                }
            }
        }
        #endregion


        // GET: Base
        private string myurl;
        public string Myurl
        {
            get
            {
                return baseUrl + MySpecificUrl();
            }

            set
            {
                ;
            }
        }

        protected string MySpecificUrl()
        {
            return "/api/accounts";
        }

        private static IHalJsonParser Parser
        {
            get
            {
                if (parser == null)
                    parser = new HalJsonParser();
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
                if (factory == null)
                    factory = new HalHttpClientFactory(Parser);
                return factory;
            }

            set
            {
                factory = value;
            }
        }


        public AccountController()
        {

        }

        public ActionResult Login()
        {
            var model = new LoginVM();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginVM model)
        {
            var loginSuccess = await PerformLoginActions(model.Username, model.Password);
            if (loginSuccess.Equals("ok"))
                return RedirectToAction("Principal", "Home");
            else if (loginSuccess.Contains("invalid_grant"))
            {
                ModelState.Clear();
                ModelState.AddModelError("", "El nombre de usuario y/o contraseña son incorrectos");
            }
            else if (loginSuccess.Contains("no_confirmed"))
            {
                ModelState.Clear();
                ModelState.AddModelError("", "Su cuenta no esta habilitada, confirme el registro desde su casilla de email");
            }
            return View(model);
        }

        private async Task<string> PerformLoginActions(string username, string password)
        {
            try
            {
                bool success = false;
                HttpStatusCode code;
                string responseBody = "";
                using (var client = Factory.CreateClient())
                {
                    client.HttpClient.DefaultRequestHeaders.Clear();
                    client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));

                    var values = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>( "grant_type", "password" ),
                        new KeyValuePair<string, string>( "username", username ),
                        new KeyValuePair<string, string> ( "Password", password )
                    };

                    FormUrlEncodedContent postBody = new FormUrlEncodedContent(values);
                    Task taskDownload = client.HttpClient.PostAsync((baseUrl + "/oauth/token"), postBody)
                         .ContinueWith(task =>
                        {
                            if (task.Status == TaskStatus.RanToCompletion)
                            {
                                var response = task.Result;

                                if (response.IsSuccessStatusCode)
                                {
                                    success = true;
                                    code = response.StatusCode;
                                    responseBody= response.Content.ReadAsStringAsync().Result;
                                    ApiToken = responseBody;
                                    TokenGrant token = JsonConvert.DeserializeObject<TokenGrant>
                                         (ApiToken.ToString());
                                    ApiToken = token.access_token;
                                    DataValues md = TokenDecode.GetInstance()
                                    .Decode(token);
                                    md.UserName = username;
                                    this.GenerateCookie(md);
                                    ///////If use sesionrequest
                                    //RolesToken = md.Roles;
                                    //ClaimsToken = md.Claims;
                                    //ExpireToken = md.ExpireToken;

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
                    responseBody = "ok";
                return responseBody;
                //if (success)
                //    return "ok";
                //else if (responseBody.Contains("invalid_grant"))
                //    return responseBody;
                //else if (responseBody.Contains("no_confirmed"))
                //    return responseBody;
                throw new Exception();


            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Session.Clear();

            // clear authentication cookie
            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie1.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie1);
            Response.Cookies[FormsAuthentication.FormsCookieName].Expire‌​s = DateTime.Now.AddDays(-1);

            // clear session cookie (not necessary for your current problem but i would recommend you do it anyway)
            SessionStateSection sessionStateSection = (SessionStateSection)WebConfigurationManager.GetSection("system.web/sessionState");
            HttpCookie cookie2 = new HttpCookie(sessionStateSection.CookieName, "");
            cookie2.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie2);

            IIdentity a = User.Identity;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ExpireSession()
        {
            return RedirectToAction("LogOut");
        }

        #region PeatonUsers
        public async Task<ActionResult> RegisterUsers()
        {
            var model = new RegisterUserVM()
            { 
                provinces = this.ChargeProvinces("?top=999"),
                locations = new List<LocationVM>(),
                genres = GenreEnum.Genres

            };

            return View(model);
        }


        [Authorize(Roles = "usuarios")]
        public async Task<ActionResult> MiAccount()
        {
            try
            {
                UpdateUserVM vm;
                using (var client = Factory.CreateClient())
                {

                    HttpStatusCode code;
                    string responseBody = "";
                    client.HttpClient.DefaultRequestHeaders.Clear();
                    client.HttpClient.DefaultRequestHeaders.Add("Accept", "application/hal+json");
                    DataValues datavalue = Decode();
                    client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", datavalue.Token);
                    var response = Task.Run(() => client.GetAsync(new Uri(baseUrl + "/api/peatonusers/" + datavalue.PrincipalId))).Result;
                    if (response.IsHalResponse)
                    {
                        if (response.Message.IsSuccessStatusCode)
                        {
                            vm = PeatonUserBuilder.FillUpdate(response.Resource);
                            vm.provinces = this.ChargeProvinces("?top=999");
                            vm.locations = new List<LocationVM>();
                            vm.genres = GenreEnum.Genres;
                            vm.ConfirmEmail = vm.Email;
                            vm.idprovince = this.GetLocation(vm.idlocation).idprovince;
                            vm.locations = this.GetLocationsByProvince(vm.idprovince);
                            return View("UpdateUsers", vm);
                        }
                        else
                        {
                            code = response.Message.StatusCode;
                            responseBody = response.Message.Content.ReadAsStringAsync().Result;

                        }

                    }
                    throw new Exception();
                }
                return View(vm);
            }
            catch (Exception ex)
            {

                CompositeFillErrors cfe = HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                if (cfe != null)
                    ModelState.AddModelError(cfe.Field, cfe.Message);
                return View();
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [Authorize(Roles = "Usuarios")]
        public ActionResult UpdateUsers(UpdateUserVM model)
        {
            try
            {
                //model.profilephoto = "recontraruta";
                if (!ModelState.IsValid)
                    throw new Exception("Inválido");
                bool success = false;
                HttpStatusCode code;
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
                    Task taskDownload = client.HttpClient.PostAsync((Myurl + "/update"), new StringContent
                        (postBody, Encoding.UTF8, "application/json"))
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
                                    JsonHalExceptionClientHandler.HandleError(response);
                                }
                            }
                        });
                    taskDownload.Wait();

                }
                if (success)
                    return RedirectToAction("Index", "Home");
                return View();
            }
            catch (Exception ex)
            {
                CompositeFillErrors cfe = HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                if (cfe != null)
                    ModelState.AddModelError(cfe.Field, cfe.Message);
                //var mymodel = new RegisterUserVM()
                //{ /*locations = ChargeLocations()*/
                //    provinces = this.ChargeProvinces("?top=100"),
                //    locations = new List<LocationVM>(),
                //    genres = GenreEnum.Genres

                //};

                return MiAccount().Result;
            }

        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult RegisterUsers(RegisterUserVM model)
        {
            try
            {
                //model.profilephoto = "recontraruta";
                if (!ModelState.IsValid)
                    throw new Exception("Inválido");
                model.RoleName = RolesEnum.Roles.Usuarios.ToString();
                bool success = false;
                HttpStatusCode code;
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
                    Task taskDownload = client.HttpClient.PostAsync((Myurl + "/create"), new StringContent
                        (postBody, Encoding.UTF8, "application/json"))
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
                                    JsonHalExceptionClientHandler.HandleError(response);
                                }
                            }
                        });
                    taskDownload.Wait();

                }
                if (success)
                    return RedirectToAction("Index", "Home");
                return View();
            }
            catch (Exception ex)
            {
                CompositeFillErrors cfe = HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                if (cfe != null)
                    ModelState.AddModelError(cfe.Field, cfe.Message);
                var mymodel = new RegisterUserVM()
                { /*locations = ChargeLocations()*/
                    provinces = this.ChargeProvinces("?top=100"),
                    locations = new List<LocationVM>(),
                    genres = GenreEnum.Genres

                };

                return View(mymodel);
            }

        }
        #endregion

        #region Business
        public ActionResult RegisterCompanies()
        {
            var model = new RegisterBusinessVM()
            {
                provinces = this.ChargeProvinces("?top=999"),
                locations = new List<LocationVM>(),
                genres = GenreEnum.Genres,
                typesactors= ListResolver.GetInstance().Typesactors,
                 typesdocuments=ListResolver.GetInstance().Typesdocuments
            };

            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult RegisterCompanies(RegisterBusinessVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Inválido");
                if (model.CreatePlayerUser)
                    model.birthdate = DateTime.Parse(model.birthdate2);
                model.RoleName = RolesEnum.Roles.Empresas.ToString();
                bool success = false;
                HttpStatusCode code;
                using (var client = Factory.CreateClient())
                {
                    client.HttpClient.DefaultRequestHeaders.Clear();
                    client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));
                    string postBody = JsonConvert.SerializeObject(model);
                    Task taskDownload = client.HttpClient.PostAsync((Myurl + "/createbusiness"), new StringContent
                        (postBody, Encoding.UTF8, "application/json"))
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
                                    JsonHalExceptionClientHandler.HandleError(response);
                                }
                            }
                        });
                    taskDownload.Wait();

                }
                if (success)
                    return RedirectToAction("Index", "Home");
                return View();
            }
            catch (Exception ex)
            {
                CompositeFillErrors cfe = HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                if (cfe != null)
                    ModelState.AddModelError(cfe.Field, cfe.Message);
                var mymodel = new RegisterBusinessVM()
                {
                    provinces = this.ChargeProvinces("?top=100"),
                    locations = new List<LocationVM>(),
                    genres = GenreEnum.Genres,
                    typesactors = ListResolver.GetInstance().Typesactors,
                    typesdocuments = ListResolver.GetInstance().Typesdocuments
                };

                return View(mymodel);
            }

        }

        public JsonResult SearchByAddress(int idlocation, string address, int addressnumber,string name)
        {
            using (var client = new HttpClient())
            {
                HttpStatusCode code;
                string responseBody = "";
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("Accept", "application/hal+json");
                if (User.Identity.IsAuthenticated)
                {
                    DataValues datavalue = Decode();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", datavalue.Token);
                }
                var response = Task.Run(() => client.GetAsync(new Uri(baseUrl + "/api/accounts/address?idlocation=" + idlocation
                    +" &address="+address+ "&addressnumber="+ addressnumber+"&name="+name))).Result;
                if (response.IsSuccessStatusCode)
                {
                    return Json(new { Data = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    code = response.StatusCode;
                    responseBody = response.Content.ReadAsStringAsync().Result;
                    if (code == HttpStatusCode.NotFound)
                        return Json(new { Data = false }, JsonRequestBehavior.AllowGet);
                }


                throw new Exception();
            }

        }

        public JsonResult SearchByCccdi(long idtypedoc, string cccdi)
        {
            using (var client = new HttpClient())
            {
                HttpStatusCode code;
                string responseBody = "";
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                if (User.Identity.IsAuthenticated)
                {
                    DataValues datavalue = Decode();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", datavalue.Token);
                }
                var response = Task.Run(() => client.GetAsync(new Uri(baseUrl + "/api/accounts/businessdnis?idtypedoc=" + idtypedoc
                    + " &cccdi=" + cccdi))).Result;
                if (response.IsSuccessStatusCode)
                {
                    return Json(new { Data = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    code = response.StatusCode;
                    responseBody = response.Content.ReadAsStringAsync().Result;
                    if (code == HttpStatusCode.NotFound)
                        return Json(new { Data = false }, JsonRequestBehavior.AllowGet);
                }


                throw new Exception();
            }

        }

        [Authorize(Roles = "Empresas")]
        public async Task<ActionResult> MiAccountBusiness()
        {
            try
            {
                UpdateBusinessVM vm;
                using (var client = Factory.CreateClient())
                {

                    HttpStatusCode code;
                    string responseBody = "";
                    client.HttpClient.DefaultRequestHeaders.Clear();
                    client.HttpClient.DefaultRequestHeaders.Add("Accept", "application/hal+json");
                    DataValues datavalue = Decode();
                    client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", datavalue.Token);
                    var response = Task.Run(() => client.GetAsync(new Uri(baseUrl + "/api/business/" + datavalue.PrincipalId))).Result;
                    if (response.IsHalResponse)
                    {
                        if (response.Message.IsSuccessStatusCode)
                        {
                            vm = BusinessBuilder.FillUpdate(response.Resource);
                            vm.provinces = this.ChargeProvinces("?top=999");
                            vm.locations = new List<LocationVM>();
                            vm.genres = GenreEnum.Genres;
                            vm.ConfirmEmail = vm.Email;
                            vm.idprovince = this.GetLocation(vm.idlocation).idprovince;
                            vm.locations = this.GetLocationsByProvince(vm.idprovince);
                            vm.typesactors = ListResolver.GetInstance().Typesactors;
                            vm.typesdocuments = ListResolver.GetInstance().Typesdocuments;
                            vm.idplayeruser = vm.playeruserid;
                            return View("UpdateCompanies", vm);
                        }
                        else
                        {
                            code = response.Message.StatusCode;
                            responseBody = response.Message.Content.ReadAsStringAsync().Result;

                        }

                    }
                    throw new Exception();
                }
                return View(vm);
            }
            catch (Exception ex)
            {

                CompositeFillErrors cfe = HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                if (cfe != null)
                    ModelState.AddModelError(cfe.Field, cfe.Message);
                return View();
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [Authorize(Roles = "Empresas")]
        public ActionResult UpdateBusiness(UpdateBusinessVM model)
        {
            try
            {
                //model.profilephoto = "recontraruta";
                if (!ModelState.IsValid)
                    throw new Exception("Inválido");
                if (model.CreatePlayerUser)
                    model.birthdate = DateTime.Parse(model.birthdate2);
                if (model.idplayeruser > 1 && !model.CreatePlayerUser)
                    throw new Exception("No se puede deshabilitar el usuario jugador");
                bool success = false;
                HttpStatusCode code;
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
                    Task taskDownload = client.HttpClient.PostAsync((Myurl + "/updatebusiness"), new StringContent
                        (postBody, Encoding.UTF8, "application/json"))
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
                                    JsonHalExceptionClientHandler.HandleError(response);
                                }
                            }
                        });
                    taskDownload.Wait();

                }
                if (success)
                    return RedirectToAction("Index", "Home");
                return View();
            }
            catch (Exception ex)
            {
                CompositeFillErrors cfe = HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                if (cfe != null)
                    ModelState.AddModelError(cfe.Field, cfe.Message);
                return MiAccountBusiness().Result;
            }

        }
        #endregion

        #region Global
        private List<ProvinceVM> ChargeProvinces(string filters)
        {
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
                var response = Task.Run(() => client.GetAsync(new Uri(baseUrl + "/api/provinces" + filters))).Result;
                if (response.IsHalResponse)
                {
                    if (response.Message.IsSuccessStatusCode)
                    {
                        var embeeded = response.Resource.Embedded["provinces"].ToList();
                        ProvinceVM province;
                        List<ProvinceVM> listdto = new List<ProvinceVM>();
                        foreach (var item in embeeded)
                        {
                            province = new ProvinceVM()
                            {
                                Id = Int64.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("idprovince")).Value),
                                Name = item.State.Values.FirstOrDefault(t => t.Name.Equals("name")).Value,
                                Country = item.State.Values.FirstOrDefault(t => t.Name.Equals("country")) == null ? string.Empty :
                                item.State.Values.FirstOrDefault(t => t.Name.Equals("country")).Value,
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
                    };

                }
                else
                {
                    code = response.Message.StatusCode;
                    responseBody = response.Message.Content.ReadAsStringAsync().Result;

                }
            }
            throw new Exception();
        }

        private List<LocationVM> GetLocationsByProvince(Int32 id)
        {
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
                var response = Task.Run(() => client.GetAsync(new Uri(baseUrl + "/api/provinces/" + id + "/locations"))).Result;
                if (response.IsHalResponse)
                {
                    if (response.Message.IsSuccessStatusCode)
                    {
                        List<LocationVM> listdto = LocationBuilder.FillCollection(response.Resource);
                        return listdto;
                    };

                }
                else
                {
                    code = response.Message.StatusCode;
                    responseBody = response.Message.Content.ReadAsStringAsync().Result;

                }
            }
            throw new Exception();
        }

        private LocationVM GetLocation(Int32 idlocation)
        {
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
                var response = Task.Run(() => client.GetAsync(new Uri(baseUrl + "/api/locations/" + idlocation))).Result;
                if (response.IsHalResponse)
                {
                    if (response.Message.IsSuccessStatusCode)
                    {
                        LocationVM location = LocationBuilder.Fill(response.Resource);
                        return location;
                    }

                }
                else
                {
                    code = response.Message.StatusCode;
                    responseBody = response.Message.Content.ReadAsStringAsync().Result;

                }
            }
            throw new Exception();
        }
        private List<LocationVM> ChargeLocations()
        {

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
                var response = Task.Run(() => client.GetAsync(new Uri(baseUrl + "/api/locations"))).Result;
                if (response.IsHalResponse)
                {
                    if (response.Message.IsSuccessStatusCode)
                    {
                        var embeeded = response.Resource.Embedded["locations"].ToList();
                        LocationVM location;
                        List<LocationVM> listdto = new List<LocationVM>();
                        foreach (var item in embeeded)
                        {
                            location = new LocationVM()
                            {
                                Id = Int64.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("idlocation")).Value),
                                Name = item.State.Values.FirstOrDefault(t => t.Name.Equals("name")).Value,
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
                    else
                    {
                        code = response.Message.StatusCode;
                        responseBody = response.Message.Content.ReadAsStringAsync().Result;

                    }
                }
                throw new Exception();
            }
        }

        public List<LocationVM> FillCollection(IRootResourceObject resource)
        {
            var embeeded = resource.Embedded["locations"].ToList();
            LocationVM location;
            List<LocationVM> listdto = new List<LocationVM>();
            foreach (var item in embeeded)
            {
                location = new LocationVM()
                {
                    Id = Int64.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("idlocation")).Value),
                    Name = item.State.Values.FirstOrDefault(t => t.Name.Equals("name")).Value,
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

        public ActionResult ForgotPassword()
        {
            ForgotPasswordVM fp = new ForgotPasswordVM();
            return View(fp);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult RequestNewPassword(ForgotPasswordVM fp)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Inválido");
                
                using (var client = Factory.CreateClient())
                {

                    HttpStatusCode code;
                    string responseBody = "";
                    client.HttpClient.DefaultRequestHeaders.Clear();
                    client.HttpClient.DefaultRequestHeaders.Add("Accept", "application/hal+json");
                    var response = Task.Run(() => client.GetAsync(new Uri(baseUrl + "/api/accounts/requestresetpassword/" + fp.Email+ "/"))).Result;
                        if (response.Message.IsSuccessStatusCode)
                        {
                            return View();
                        }
                        else
                        {
                            JsonHalExceptionClientHandler.HandleError(response.Message);
                        }
                    throw new Exception();
                }
                
            }
            catch (Exception ex)
            {

                CompositeFillErrors cfe = HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                if (cfe != null)
                    ModelState.AddModelError(cfe.Field, cfe.Message);
                 return View("ForgotPassword", fp);
            }
        }


        public ActionResult ConfirmResetPassword(string pthresepsw,string email,string rid)
        {
            try
            {
                return View("ChangePassword", new ResetPasswordVM()
                { email = email, token = pthresepsw, rid=rid });
            }
            catch (Exception ex)
            {
                CompositeFillErrors cfe = HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                if (cfe != null)
                    ModelState.AddModelError(cfe.Field, cfe.Message);
                //var mymodel = new RegisterUserVM()
                //{ /*locations = ChargeLocations()*/
                //    provinces = this.ChargeProvinces("?top=100"),
                //    locations = new List<LocationVM>(),
                //    genres = GenreEnum.Genres

                //};

                return MiAccountBusiness().Result;
            }


        }

        public ActionResult ResetPassword(ResetPasswordVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Inválido");
                bool success = false;
                HttpStatusCode code;
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
                    Task taskDownload = client.HttpClient.PostAsync((Myurl + "/resetpassword"), new StringContent
                        (postBody, Encoding.UTF8, "application/json"))
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
                                    JsonHalExceptionClientHandler.HandleError(response);
                                }
                            }
                        });
                    taskDownload.Wait();

                }
                if (success)
                    return RedirectToAction("Index", "Home");
                return View();
            }
            catch (Exception ex)
            {
                CompositeFillErrors cfe = HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                if (cfe != null)
                    ModelState.AddModelError(cfe.Field, cfe.Message);
                return ConfirmResetPassword(model.token,model.email,model.rid);
            }

        }

        #endregion

        public JsonResult SearchByDocument(string dni)
        {
            using (var client = new HttpClient())
            {
                HttpStatusCode code;
                string responseBody = "";
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                if (User.Identity.IsAuthenticated)
                {
                    DataValues datavalue = Decode();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", datavalue.Token);
                }
                var response = Task.Run(() => client.GetAsync(new Uri(baseUrl + "/api/accounts/dnis/" + dni))).Result;
                if (response.IsSuccessStatusCode)
                {
                    return Json(new { Data = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    code = response.StatusCode;
                    responseBody = response.Content.ReadAsStringAsync().Result;
                    if (code == HttpStatusCode.NotFound)
                        return Json(new { Data = false }, JsonRequestBehavior.AllowGet);
                }


                throw new Exception();
            }

        }

        public JsonResult SearchByUsername(string username)
        {
            using (var client = new HttpClient())
            {
                HttpStatusCode code;
                string responseBody = "";
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                if (User.Identity.IsAuthenticated)
                {
                    DataValues datavalue = Decode();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", datavalue.Token);
                }
                var response = Task.Run(() => client.GetAsync(new Uri(baseUrl + "/api/accounts/user/" + username))).Result;
                if (response.IsSuccessStatusCode)
                {
                    return Json(new { Data = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    code = response.StatusCode;
                    responseBody = response.Content.ReadAsStringAsync().Result;
                    if (code == HttpStatusCode.NotFound)
                        return Json(new { Data = false }, JsonRequestBehavior.AllowGet);
                }


                throw new Exception();
            }

        }

        public JsonResult SearchByEmail(string email)
        {
            using (var client = new HttpClient())
            {
                HttpStatusCode code;
                string responseBody = "";
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                if (User.Identity.IsAuthenticated)
                {
                    DataValues datavalue = Decode();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", datavalue.Token);
                }
                var response = Task.Run(() => client.GetAsync(new Uri(baseUrl + "/api/accounts/emails/" + email + "/"))).Result;
                if (response.IsSuccessStatusCode)
                {
                    return Json(new { Data = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    code = response.StatusCode;
                    responseBody = response.Content.ReadAsStringAsync().Result;
                    if (code == HttpStatusCode.NotFound)
                        return Json(new { Data = false }, JsonRequestBehavior.AllowGet);
                }


                throw new Exception();
            }

        }

        [AllowAnonymous]
        public ActionResult ConfirmRegistration(string pthreg)
        {
            try
            {
                bool success = false;
                HttpStatusCode code;
                MVCPeaton.Security.ConfirmRegistration cr = new Security.ConfirmRegistration()
                {
                    RandomKey = pthreg,
                    DateRequest = DateTime.Now
                };
                using (var client = Factory.CreateClient())
                {
                    client.HttpClient.DefaultRequestHeaders.Clear();
                    client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));
                    string postBody = JsonConvert.SerializeObject(cr);
                    Task taskDownload = client.HttpClient.PostAsync((Myurl + "/confirmregistration"), new StringContent
                        (postBody, Encoding.UTF8, "application/json"))
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
                                    JsonHalExceptionClientHandler.HandleError(response);
                                }
                            }
                        });
                    taskDownload.Wait();

                }
                if (success)
                    return View("RegisterSuccess");
                return View();
            }
            catch (Exception ex)
            {
                CompositeFillErrors cfe = HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                if (cfe != null)
                    ModelState.AddModelError(cfe.Field, cfe.Message);
                //var mymodel = new RegisterUserVM()
                //{ /*locations = ChargeLocations()*/
                //    provinces = this.ChargeProvinces("?top=100"),
                //    locations = new List<LocationVM>(),
                //    genres = GenreEnum.Genres

                //};

                return View();
            }

        }


        [AllowAnonymous]
        public ActionResult RequestNewConfirmRegistration()
        {
            try
            {
                return View(new RenewConfirmRegistrationVM());
            }
            catch (Exception ex)
            {
                CompositeFillErrors cfe = HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                if (cfe != null)
                    ModelState.AddModelError(cfe.Field, cfe.Message);
                return View(new RenewConfirmRegistrationVM());
            }

        }

        [AllowAnonymous]
        public ActionResult ReNewConfirmRegistration(RenewConfirmRegistrationVM fp)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Inválido");

                using (var client = Factory.CreateClient())
                {

                    HttpStatusCode code;
                    string responseBody = "";
                    client.HttpClient.DefaultRequestHeaders.Clear();
                    client.HttpClient.DefaultRequestHeaders.Add("Accept", "application/hal+json");
                    var response = Task.Run(() => client.GetAsync(new Uri(baseUrl + "/api/accounts/requestnewconfirmregistration/" + fp.Email + "/"))).Result;
                    if (response.Message.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        JsonHalExceptionClientHandler.HandleError(response.Message);
                    }
                    throw new Exception();
                }

            }
            catch (Exception ex)
            {

                CompositeFillErrors cfe = HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                if (cfe != null)
                    ModelState.AddModelError(cfe.Field, cfe.Message);
                return View("RequestNewConfirmRegistration", fp);
            }

        }

        
    }
}