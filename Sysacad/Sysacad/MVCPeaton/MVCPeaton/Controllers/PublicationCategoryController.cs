using MVCPeaton.Controllers.Proxys;
using MVCPeaton.Models.ViewModels;
using MVCPeaton.Tools;
using MVCPeaton.Tools.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPeaton.Controllers
{
    public class PublicationCategoryController : BaseProxyController<PublicationCategoryVM>
    {
        #region Override methods needed for base controller
        public override BaseProxy<PublicationCategoryVM> Myproxy()
        {
            return new PublicationCategoriesProxy();
        }

        public override string MyRelationEmbeeded()
        {
            throw new NotImplementedException();
        }

        protected override string MySpecificUrl()
        {
            return "/api/publicationcategories";
        }
        #endregion
        #region Get methods
        [HttpGet]
        [System.Web.Mvc.Authorize(Roles = "Admin, Empresas")]
        public ActionResult Index()
        {
            if (!ModelState.IsValid)
                return View();
            #region Cookie
            string cookievalue = "";
            if (User.Identity.IsAuthenticated)
                cookievalue = Decode().Token;
            #endregion
            int state = 1;
            int top = 100;
            string orderby = "idpublicationcategory";
            string ascending = "asc";
            int page = 1;
            string filters = "?state=" + state + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page;
            List<PublicationCategoryVM> list = Myproxy().GetAll(filters, cookievalue).Result;
            
            return View("List", list);
        }

        [HttpGet]
        [System.Web.Mvc.Authorize(Roles = "Admin, Empresas")]
        public override ActionResult AddForm()
        {
            if (!ModelState.IsValid)
                return View();

            return View("Insert", new PublicationCategoryVM());
        }

        [HttpGet]
        [System.Web.Mvc.Authorize(Roles = "Admin, Empresas")]
        public ActionResult DetailForm(long id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();
                string cookievalue = "";
                if (User.Identity.IsAuthenticated)
                    cookievalue = Decode().Token;
                PublicationCategoryVM model = Myproxy().Get(id, cookievalue);
                return View("Details", model);
            }
            catch (Exception ex)
            {
                CompositeFillErrors cfe = HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                if (cfe != null)
                    ModelState.AddModelError(cfe.Field, cfe.Message);
                return View();
            }
        }

        [HttpGet]
        [System.Web.Mvc.Authorize(Roles = "Admin, Empresas")]
        public override ActionResult UpdateForm(long id)
        {
            if (!ModelState.IsValid)
                return View();
            #region Cookie
            string cookievalue = "";
            if (User.Identity.IsAuthenticated)
                cookievalue = Decode().Token;
            #endregion
            PublicationCategoryVM vm = Myproxy().Get(id, cookievalue);
            
            return View("Update", vm);
        }
        #endregion

        #region Post methods
        [HttpPost]
        [ValidateAntiForgeryToken]
        public override ActionResult Add(PublicationCategoryVM model)
        {
            try
            {
                model.state = (Int32)StatesEnum.Valid;
                
                // En caso de ser invalido el ModelState.
                if (!ModelState.IsValid)
                    return View("AddForm");
                string cookievalue = "";
                if (User.Identity.IsAuthenticated)
                    cookievalue = Decode().Token;
                Myproxy().Create(model, cookievalue);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [System.Web.Mvc.Authorize(Roles = "Admin, Empresas")]
        public override ActionResult Update(PublicationCategoryVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.state = (Int32)StatesEnum.Valid;
                    
                    if (!ModelState.IsValid)
                        return RedirectToAction("Index");
                    string cookievalue = "";
                    if (User.Identity.IsAuthenticated)
                        cookievalue = Decode().Token;
                    Myproxy().Update(model, cookievalue);
                    return RedirectToAction("Index");
                }
                else
                    return View("Error");
            }
            catch (Exception ex)
            {
                HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [System.Web.Mvc.Authorize(Roles = "Admin, Empresas")]
        public override ActionResult DeleteForm(long id)
        {
            PublicationCategoryVM vm = new PublicationCategoryVM();
            vm.Id = id;
            try
            {
                // En caso de ser invalido el ModelState.
                if (!ModelState.IsValid)
                    return RedirectToAction("Index");
                string cookievalue = "";
                if (User.Identity.IsAuthenticated)
                    cookievalue = Decode().Token;
                Myproxy().Delete(vm, cookievalue);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                return View("List");
            }
        }
        #endregion
    }
}