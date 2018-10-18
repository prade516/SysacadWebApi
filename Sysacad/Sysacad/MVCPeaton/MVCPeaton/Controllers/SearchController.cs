using MVCPeaton.Controllers.Proxys;
using MVCPeaton.Models.ViewModels;
using MVCPeaton.Tools.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPeaton.Controllers
{
    public class SearchController : BaseProxyController<SearchVM>
    {
        #region Override methods needed for base controller
        public override BaseProxy<SearchVM> Myproxy()
        {
            return new SearchProxy();
        }

        public override string MyRelationEmbeeded()
        {
            throw new NotImplementedException();
        }

        protected override string MySpecificUrl()
        {
            return "/api/search";
        }
        #endregion
        #region GET
        //[HttpGet]
        //[Authorize(Roles = "Admin,Empresas,Usuarios")]
        public ActionResult Resultado(String busqueda="")
        {
            //top = 5 & orderby = idprovince & ascending = asc & page = 2
            //string name = nameprov;
            Int32 top = 100;
            String orderby = "slogan";
            String ascending = "asc";
            Int32 page = 1;
            String searchterms = busqueda;
            String filtros = "?searchterms=" + searchterms + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page;
            return this.ListForm(filtros);
        }

        public override ActionResult ListForm(String filtros)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();
                string cookievalue = "";
                if (User.Identity.IsAuthenticated)
                    cookievalue = Decode().Token;
                SearchVM model = new SearchProxy().GetAllNew(filtros, cookievalue);
                return View("List", model);
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
    }
}