using MVCPeaton.Models.ViewModels.Preferences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HalClient.Net.Parser;
using MVCPeaton.Controllers.Proxys;
using MVCPeaton.Tools.Exceptions;
using System.Net;
using System.Net.Http.Headers;
using MVCPeaton.Security;
using System.Threading.Tasks;

namespace MVCPeaton.Controllers
{
    public class PreferenceController : BaseProxyController<PreferenceVM>
    {
        #region Main method [flow depends on wether the user is creating or updating their preferences]
        [HttpGet]
        [Authorize(Roles = "Admin,Empresas,Usuarios")]
        public ActionResult MiPreferencia()
        {
            if (!ModelState.IsValid)
                return View();
            string cookievalue = "";
            if (User.Identity.IsAuthenticated)
                cookievalue = Decode().Token;

            Int32 top = 1;
            String orderby = "idpreference";
            String ascending = "asc";
            Int32 page = 1;
            String user = Decode().UserName;
            String filtros = "?user=" + user + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page;
            List<PreferenceVM> preferences = Myproxy().GetAll(filtros, cookievalue).Result;
            if(preferences.Count == 0)
            {
                return RedirectToAction("AddForm");
            }
            else
            {
                return RedirectToAction("UpdateForm", new { id = preferences.First().Id });
            }

            // PreferenceVM model = Myproxy().Get(id, cookievalue);


        }
        #endregion
        #region Get Methods
        [HttpGet]
        [Authorize(Roles = "Admin,Empresas,Usuarios")]
        public ActionResult List()
        {
            //top = 5 & orderby = idprovince & ascending = asc & page = 2
            //string name = nameprov;
            Int32 top = 100;
            String orderby = "idpreference";
            String ascending = "asc";
            Int32 page = 1;
            String user = "";
            String filtros = "?name=" + user + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page;
            return this.ListForm(filtros);
        }
        
        [HttpGet]
        [Authorize(Roles = "Admin,Empresas,Usuarios")]
        public override ActionResult AddForm()
        {
            string cookievalue = "";
            if (User.Identity.IsAuthenticated)
                cookievalue = Decode().Token;
            PreferenceVM model = new PreferenceVM() { mybanks = new List<PreferenceBankVM>(), myitems = new List<PreferenceItemVM>(), mytags = new List<PreferenceTagVM>() };
            #region Banks
            var banks = new BankProxy().GetAll("?top=1000", cookievalue).Result;
            foreach (var bank in banks)
                model.mybanks.Add(new PreferenceBankVM() { ischecked = false, Idbank = bank.Id, Name = bank.Name, Logo = bank.Logo });
            model.mybanks = model.mybanks.OrderBy(x => x.Name).ToList();
            #endregion
            #region Items
            var items = new ItemProxy().GetAll("?top=1000", cookievalue).Result;
            foreach (var item in items)
                model.myitems.Add(new PreferenceItemVM() { ischecked = false, IdItem = item.Id, Name = item.Name });
            model.myitems = model.myitems.OrderBy(x => x.Name).ToList();
            #endregion
            #region Tags
            var tags = new TagProxy().GetAll("?top=1000", cookievalue).Result;
            foreach (var tag in tags)
                model.mytags.Add(new PreferenceTagVM() { ischecked = false, Idtag = tag.Id, Name = tag.name });
            model.mytags = model.mytags.OrderBy(x => x.Name).ToList();
            #endregion
            return View("Insert", model);
        }
        
        [HttpGet]
        [Authorize(Roles = "Admin,Empresas,Usuarios")]
        public override ActionResult UpdateForm(Int64 id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View("Error");
                string cookievalue = "";
                if (User.Identity.IsAuthenticated)
                    cookievalue = Decode().Token;
                PreferenceVM model = Myproxy().Get(id, cookievalue);
                #region Banks
                var banks = new BankProxy().GetAll("?top=1000", cookievalue).Result;
                foreach (var bank in banks)
                {
                    if (!model.mybanks.Exists(x => x.Idbank == bank.Id))
                    {
                        model.mybanks.Add(new PreferenceBankVM() { ischecked = false, Idbank = bank.Id, Name = bank.Name, Logo = bank.Logo });
                    }
                    else model.mybanks.FirstOrDefault(x => x.Idbank == bank.Id).ischecked = model.mybanks.FirstOrDefault(x => x.Idbank == bank.Id).State == 2 ? false : true;
                }
                model.mybanks = model.mybanks.OrderBy(x => x.Name).ToList();
                #endregion
                #region Items
                var items = new ItemProxy().GetAll("?top=1000", cookievalue).Result;
                foreach (var item in items)
                {
                    if (!model.myitems.Exists(x => x.IdItem == item.Id))
                    {
                        model.myitems.Add(new PreferenceItemVM() { ischecked = false, IdItem = item.Id, Name = item.Name });
                    }
                    else model.myitems.FirstOrDefault(x => x.IdItem == item.Id).ischecked = model.myitems.FirstOrDefault(x => x.IdItem == item.Id).State == 2 ? false : true;
                }
                model.myitems = model.myitems.OrderBy(x => x.Name).ToList();
                #endregion
                #region Tags
                var tags = new TagProxy().GetAll("?top=5000", cookievalue).Result;
                foreach (var tag in tags)
                {
                    if (!model.mytags.Exists(x => x.Idtag == tag.Id))
                    {
                        model.mytags.Add(new PreferenceTagVM() { ischecked = false, Idtag = tag.Id, Name = tag.name });
                    }
                    else model.mytags.FirstOrDefault(x => x.Idtag == tag.Id).ischecked = model.mytags.FirstOrDefault(x => x.Idtag == tag.Id).State == 2 ? false : true;
                }
                model.mytags = model.mytags.OrderBy(x => x.Name).ToList();
                #endregion
                return View("Update",model);
            }
            catch (Exception ex)
            {
                CompositeFillErrors cfe = HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                if (cfe != null)
                    ModelState.AddModelError(cfe.Field, cfe.Message);
                return View("Error");
            }
        }
        #endregion
        #region Post methods Roles = Admin, Empresas, Usuarios
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Empresas,Usuarios")]
        public override ActionResult Update(PreferenceVM model)
        {
            try
            {
                // En caso de ser invalido el ModelState.
                if (!ModelState.IsValid)
                    return View("Error");
                string cookievalue = "";
                if (User.Identity.IsAuthenticated)
                    cookievalue = Decode().Token;
                model.username = Decode().UserName;
                #region Banks
                for(int i = model.mybanks.Count -1; i>=0;i--)
                {
                    if (model.mybanks[i].ischecked == true)
                    { 
                        if (model.mybanks[i].State != 1)
                            model.mybanks[i].State = 1;
                    }
                    else
                    {
                        if (model.mybanks[i].State == 0)
                            model.mybanks.Remove(model.mybanks[i]);
                        else
                            if (model.mybanks[i].State == 1)
                            model.mybanks[i].State = 2;
                    }
                }
                #endregion
                #region Items
                for (int i = model.myitems.Count - 1; i >= 0; i--)
                {
                    if (model.myitems[i].ischecked == true)
                    {
                        if (model.myitems[i].State != 1)
                            model.myitems[i].State = 1;
                    }
                    else
                    {
                        if (model.myitems[i].State == 0)
                            model.myitems.Remove(model.myitems[i]);
                        else
                            if (model.myitems[i].State == 1)
                            model.myitems[i].State = 2;
                    }
                }
                #endregion
                #region Tags
                for (int i = model.mytags.Count - 1; i >= 0; i--)
                {
                    if (model.mytags[i].ischecked == true)
                    {
                        if (model.mytags[i].State != 1)
                            model.mytags[i].State = 1;
                    }
                    else
                    {
                        if (model.mytags[i].State == 0)
                            model.mytags.Remove(model.mytags[i]);
                        else
                            if (model.mytags[i].State == 1)
                            model.mytags[i].State = 2;
                    }
                }
                #endregion
                Myproxy().Update(model, cookievalue);
                //return View();
                return RedirectToAction("updateForm", new { id = model.Id });
            }
            catch (Exception ex)
            {
                HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Empresas,Usuarios")]
        public override ActionResult Add(PreferenceVM model)
        {
            try
            {
                // En caso de ser invalido el ModelState.
                if (!ModelState.IsValid)
                    return View("Error");
                string cookievalue = "";
                if (User.Identity.IsAuthenticated)
                    cookievalue = Decode().Token;

                model.username = Decode().UserName;
                #region Banks
                for (int i = model.mybanks.Count - 1; i >= 0; i--)
                {
                    if (model.mybanks[i].ischecked == true)
                        model.mybanks[i].State = 1;
                    else
                        model.mybanks.Remove(model.mybanks[i]);
                }
                #endregion
                #region Items
                for (int i = model.myitems.Count - 1; i >= 0; i--)
                {
                    if (model.myitems[i].ischecked == true)
                        model.myitems[i].State = 1;
                    else
                        model.myitems.Remove(model.myitems[i]);
                }
                #endregion
                #region Tags
                for (int i = model.mytags.Count - 1; i >= 0; i--)
                {
                    if (model.mytags[i].ischecked == true)
                        model.mytags[i].State = 1;
                    else
                        model.mytags.Remove(model.mytags[i]);
                }
                #endregion
                Myproxy().Create(model, cookievalue);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                return View("List");
            }
        }
        #endregion
        #region Json methods

        
        #endregion
        #region Override methods needed for base controller
        public override BaseProxy<PreferenceVM> Myproxy()
        {
            return new PreferenceProxy();
        }

        public override string MyRelationEmbeeded()
        {
            throw new NotImplementedException();
        }
        
        protected override string MySpecificUrl()
        {
            return "/api/preferences";
        }
        #endregion
    }
}