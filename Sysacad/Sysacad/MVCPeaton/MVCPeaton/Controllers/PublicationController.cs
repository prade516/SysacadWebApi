using MVCPeaton.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HalClient.Net.Parser;
using System.Net;
using System.Net.Http.Headers;
using MVCPeaton.Security;
using System.Threading.Tasks;
using build = MVCPeaton.Models.ModelBuilders;
using MVCPeaton.Tools;
using MVCPeaton.Controllers.Proxys;
using MVCPeaton.Tools.Exceptions;

namespace MVCPeaton.Controllers
{
    public class PublicationController : BaseProxyController<PublicationVM>
    {
        #region Override methods needed for base controller
        public override BaseProxy<PublicationVM> Myproxy()
        {
            return new PublicationsProxy();
        }

        public override string MyRelationEmbeeded()
        {
            throw new NotImplementedException();
        }

        protected override string MySpecificUrl()
        {
            return "/api/publications";
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
            string orderby = "idpublication";
            string ascending = "asc";
            int page = 1;
            string filters = "?state=" + state + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page;
            List<PublicationVM> list = Myproxy().GetAll(filters, cookievalue).Result;
            
            PublicationVM newVM = new PublicationVM();
            List<PublicationCategoryVM> categories = new PublicationCategoriesProxy().GetAll("?top=1000", cookievalue).Result;

            foreach(var item in list)
            {
                item.name = categories.FirstOrDefault(z => z.Id == item.idpublicationcategory).name;
            }
            return View("List", list);
        }
        
        [HttpGet]
        [System.Web.Mvc.Authorize(Roles = "Admin, Empresas")]
        public override ActionResult AddForm()
        {
            if (!ModelState.IsValid)
                return View();
            #region Cookie
            string cookievalue = "";
            if (User.Identity.IsAuthenticated)
                cookievalue = Decode().Token;
            #endregion
            PublicationVM vm = new PublicationVM();
            GetRelatesTags(vm, cookievalue);
            vm.publicationcategories = new PublicationCategoriesProxy().GetAll("?top=1000", cookievalue).Result;
            return View("Insert", vm);
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
                PublicationVM model = Myproxy().Get(id, cookievalue);
                model.publicationcategories = new PublicationCategoriesProxy().GetAll("?top=1000", cookievalue).Result;
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
            PublicationVM vm = Myproxy().Get(id, cookievalue);

            vm.publicationcategories = new PublicationCategoriesProxy().GetAll("?top=1000", cookievalue).Result;
            GetRelatesTags(vm,cookievalue);
            return View("Update", vm);
        }

        private void GetRelatesTags(PublicationVM vm, string cookievalue)
        {
            var listTags = new BusinessConfigurationProxy().GetTagsById("?top=1000", cookievalue).Result;

            if (vm.tags == null)
                vm.tags = new List<PublicationBCTagVM>();

            foreach (var item in listTags)
            {
                if (!vm.tags.Exists(x => x.idtag == item.idtag))
                {
                    vm.tags.Add(new PublicationBCTagVM()
                    {
                        idtag = item.idtag,
                        idbusinessconfigurationtag = item.idbusinessconfigurationtag,
                        ischecked = false,
                        idpublication = vm.Id,
                        name = item.Tag.name,
                        state = 0
                    });
                }
            }
        }
        #endregion
        #region Post methods
        [HttpPost]
        [ValidateAntiForgeryToken]
        public override ActionResult Add(PublicationVM model)
        {
            try
            {
                model.state = (Int32)StatesEnum.Valid;
                #region Tags
                if (model.tags != null)
                {
                    for (int i = model.tags.Count - 1; i >= 0; i--)
                    {
                        if (model.tags[i].ischecked == true)
                            model.tags[i].state = 1;
                        else
                            model.tags.Remove(model.tags[i]);
                    }
                }
                #endregion
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
        public override ActionResult Update(PublicationVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.state = (Int32)StatesEnum.Valid;

                    //model.tags.RemoveAll(x => x.state != (Int32)StatesEnum.Valid);
                    #region Tags
                    for (int i = model.tags.Count - 1; i >= 0; i--)
                    {
                        if (model.tags[i].ischecked == true)
                        {
                            if (model.tags[i].state != 1)
                                model.tags[i].state = 1;
                        }
                        else
                        {
                            if (model.tags[i].state == 0)
                                model.tags.Remove(model.tags[i]);
                            else
                                if (model.tags[i].state == 1)
                                model.tags[i].state = 2;
                        }
                    }
                    #endregion
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

        [HttpPost]
        [System.Web.Mvc.Authorize(Roles = "Admin, Empresas")]
        public override ActionResult DeleteForm(long id)
        {
            PublicationVM vm = new PublicationVM();
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