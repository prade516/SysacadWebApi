using HalClient.Net;
using HalClient.Net.Parser;
using MVCPeaton.Controllers.Proxys;
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
    public abstract class BaseProxyController<VM> : Controller where VM : BaseVM
    {
		public readonly static string baseUrl = "http://localhost:40784";
		private BaseProxy<VM> _myproxy;

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

        public abstract BaseProxy<VM> Myproxy();

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
                return new JsonResult();
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
                if (!ModelState.IsValid)
                    return View();
                string cookievalue = "";
                if (User.Identity.IsAuthenticated)
                    cookievalue = Decode().Token;
                VM model = Myproxy().Get(id, cookievalue);
                return View(model);
            }
            catch (Exception ex)
            {
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
                if (!ModelState.IsValid)
                    return View();
                string cookievalue = "";
                if (User.Identity.IsAuthenticated)
                    cookievalue = Decode().Token;
                VM model = Myproxy().Get(id, cookievalue);
                return View(model);
            }
            catch (Exception ex)
            {
                CompositeFillErrors cfe = HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                if (cfe != null)
                    ModelState.AddModelError(cfe.Field, cfe.Message);
                return View();
            }
        }

        public virtual ActionResult ListForm(string filters="")
        {
            try
            {
                // En caso de ser invalido el ModelState.
                if (!ModelState.IsValid)
                    return View();
                string cookievalue = "";
                if (User.Identity.IsAuthenticated)
                    cookievalue = Decode().Token;
                return View(Myproxy().GetAll(filters, cookievalue).Result);
                //return new JsonResult() { Data=Myproxy().GetAll(filters,cookievalue) };
            }
            catch (Exception ex)
            {
                CompositeFillErrors cfe = HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                if (cfe != null)
                    ModelState.AddModelError(cfe.Field, cfe.Message);
                return View();
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
                string cookievalue = "";
                if (User.Identity.IsAuthenticated)
                    cookievalue = Decode().Token;
                Myproxy().Create(model, cookievalue);
                return View();
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
                    return View("AddForm");
                string cookievalue = "";
                if (User.Identity.IsAuthenticated)
                    cookievalue = Decode().Token;
                Myproxy().Update(model, cookievalue);
                return View();
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
                    return View("AddForm");
                string cookievalue = "";
                if (User.Identity.IsAuthenticated)
                    cookievalue = Decode().Token;
                Myproxy().Delete(model, cookievalue);
                return View();
            }
            catch (Exception ex)
            {
                HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                return View("List");
            }
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

        #endregion


    }
}