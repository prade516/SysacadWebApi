using MVCPeaton.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HalClient.Net.Parser;
using build = MVCPeaton.Models.ModelBuilders;
using System.Net;
using MVCPeaton.Security;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MVCPeaton.Controllers.Proxys;
using MVCPeaton.Tools;

namespace MVCPeaton.Controllers
{
    public class BusinessConfigurationController : BaseProxyController<BusinessConfigurationVM>
    {
        #region Proxy
        private BusinessConfigurationProxy _myProxy;
        public BusinessConfigurationProxy MyProxy
        {
            get
            {
                if (_myProxy == null)
                    _myProxy = new BusinessConfigurationProxy();
                return _myProxy;
            }

            set
            {
                _myProxy = value;
            }
        }

        public override BaseProxy<BusinessConfigurationVM> Myproxy()
        {
            return MyProxy;
        }
        #endregion

        #region Index
        [System.Web.Mvc.Authorize(Roles = "Admin,Empresas,Usuarios")]
        public ActionResult Index()
        {
            string cookievalue = "";
            if (User.Identity.IsAuthenticated)
            {
                cookievalue = Decode().Token;
            }
            BusinessConfigurationVM vm = Myproxy().Get(0, cookievalue);
            if(vm.Id != 0)
            {
                return RedirectToAction("UpdateForm", "BusinessConfiguration", new { id = vm.Id });
            }
            else
            {
                return RedirectToAction("AddForm");
            }
        }
        #endregion

        #region Get Methods
        [System.Web.Mvc.Authorize(Roles = "Admin,Empresas,Usuarios")]
        public override ActionResult AddForm()
        {
            try
            {
                //Model State
                if (!ModelState.IsValid)
                {
                    return View("Error");
                }

                //Cookie
                string cookievalue = "";
                if (User.Identity.IsAuthenticated)
                {
                    cookievalue = Decode().Token;
                }

                //Get One For Relates
                BusinessConfigurationVM vm = Myproxy().Get(0, cookievalue);
                GetAllItems(vm);
                GetAllBusinessConfigurationTags(vm);
                List<BusinessConfigurationTagVM> list = new List<BusinessConfigurationTagVM>();
                BusinessConfigurationTagVM item = new BusinessConfigurationTagVM();
                list.Add(item);
                vm.MyBusinessConfigurationTags = list;

                //Return View
                return View("Insert", vm);
            }
            catch (Exception ex)
            {
                Tools.Exceptions.CompositeFillErrors cfe = Tools.Exceptions.HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                if (cfe != null)
                    ModelState.AddModelError(cfe.Field, cfe.Message);
                return View("Error");
            }
        }

        [System.Web.Mvc.Authorize(Roles = "Admin,Empresas,Usuarios")]
        public override ActionResult UpdateForm(long id)
        {
            try
            {
                //Model State
                if (!ModelState.IsValid)
                {
                    return View("Error");
                }

                //Cookie
                string cookievalue = "";
                if (User.Identity.IsAuthenticated)
                {
                    cookievalue = Decode().Token;
                }

                //Get One
                BusinessConfigurationVM vm = new BusinessConfigurationVM();
                vm = Myproxy().Get(id, cookievalue);
                vm.Branches.RemoveAll(x => x.state == (Int32)StatesEnum.Annulled);
                vm.EmployeeAccounts.RemoveAll(x => x.state == (Int32)StatesEnum.Annulled);
                vm.MyBusinessConfigurationTags.RemoveAll(x => x.state == (Int32)StatesEnum.Annulled);
                GetAllItems(vm);
                GetAllBusinessConfigurationTags(vm);
                BusinessConfigurationTagVM bctVM = new BusinessConfigurationTagVM();
                foreach (var item in vm.MyBusinessConfigurationTags)
                {
                    bctVM = vm.BusinessConfigurationTags.Find(x => x.idtag == item.idtag);
                    bctVM.ischecked = false;
                    if (item.state == (Int32)StatesEnum.Valid)
                    {
                        bctVM.ischecked = true;
                        bctVM.state = item.state;
                        bctVM.idbusinessconfigurationtag = item.idbusinessconfigurationtag;
                    }
                }

                //Set confirm psasword
                foreach (var item in vm.EmployeeAccounts)
                {
                    item.confirm = item.password;
                }

                //Return View
                return View("Update", vm);
            }
            catch (Exception ex)
            {
                Tools.Exceptions.CompositeFillErrors cfe = Tools.Exceptions.HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                if (cfe != null)
                    ModelState.AddModelError(cfe.Field, cfe.Message);
                return View("Error");
            }

        }
        #endregion

        #region Post Methods
        public override ActionResult Add(BusinessConfigurationVM model)
        {
            try
            {
                #region With lists
                if(model.Branches != null)
                {
                    model.Branches.RemoveAll(x => x.state == (Int32)StatesEnum.Annulled);
                    model.Branches.ForEach(x => x.state = (Int32)StatesEnum.Valid);
                }
                if(model.EmployeeAccounts != null)
                {
                    model.EmployeeAccounts.RemoveAll(x => x.state == (Int32)StatesEnum.Annulled);
                    model.EmployeeAccounts.ForEach(x => x.state = (Int32)StatesEnum.Valid);
                }
                if (model.BusinessConfigurationTags != null)
                {
                    model.BusinessConfigurationTags.RemoveAll(x => x.ischecked == false);
                    model.BusinessConfigurationTags.ForEach(x => x.state = (Int32)StatesEnum.Valid);
                }
                #endregion
                
                //Model State
                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Principal", "Home");
                }

                //Cookie
                string cookievalue = "";
                if (User.Identity.IsAuthenticated)
                {
                    cookievalue = Decode().Token;
                }

                //Create
                Myproxy().Create(model, cookievalue);

                //Return
                return RedirectToAction("Principal", "Home");
            }
            catch (Exception ex)
            {
                Tools.Exceptions.CompositeFillErrors cfe = Tools.Exceptions.HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                if (cfe != null)
                    ModelState.AddModelError(cfe.Field, cfe.Message);
                return View("Error");
            }
        }

        public override ActionResult Update(BusinessConfigurationVM model)
        {
            try
            {
                #region With lists
                if (model.Branches != null)
                {
                    List<BrancheVM> listBranches = new List<BrancheVM>();
                    foreach(var item in model.Branches)
                    {
                        if(item.state != (Int32)StatesEnum.Annulled)
                        {
                            listBranches.Add(item);
                        }
                    }
                    model.Branches = listBranches;
                }

                if (model.EmployeeAccounts != null)
                {
                    List<EmployeeAccountVM> listAccounts = new List<EmployeeAccountVM>();
                    foreach (var item in model.EmployeeAccounts)
                    {
                        if (item.state != (Int32)StatesEnum.Annulled)
                        {
                            listAccounts.Add(item);
                        }
                    }
                    model.EmployeeAccounts = listAccounts;
                }

                if (model.BusinessConfigurationTags != null)
                {
                    List<BusinessConfigurationTagVM> listBCT = new List<BusinessConfigurationTagVM>();
                    foreach (var item in model.BusinessConfigurationTags)
                    {
                        if (item.ischecked == true && item.idbusinessconfigurationtag == 0)
                        {
                            item.state = (Int32)StatesEnum.Valid;
                            listBCT.Add(item);
                        }
                        else if (item.ischecked == false && item.idbusinessconfigurationtag != 0)
                        {
                            item.state = (Int32)StatesEnum.Annulled;
                            listBCT.Add(item);
                        }
                    }
                    model.BusinessConfigurationTags = listBCT;
                }
                #endregion

                //Model State
                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Principal", "Home");
                }

                //Cookie
                string cookievalue = "";
                if (User.Identity.IsAuthenticated)
                {
                    cookievalue = Decode().Token;
                }

                //Update
                Myproxy().Update(model, cookievalue);

                //Return
                return RedirectToAction("Principal", "Home");
            }
            catch (Exception ex)
            {
                Tools.Exceptions.CompositeFillErrors cfe = Tools.Exceptions.HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                if (cfe != null)
                    ModelState.AddModelError(cfe.Field, cfe.Message);
                return View("Error");
            }
        }
        #endregion

        #region Override Methods
        protected override string MySpecificUrl()
        {
            return "/api/businessconfigurations";
        }

        public override string MyRelationEmbeeded()
        {
            return "businessconfigurations";
        }
        #endregion

        #region Private Methods
        private void GetAllItems(BusinessConfigurationVM vm)
        {
            try
            {
                ItemProxy itemProxy = new ItemProxy();
                vm.Items = itemProxy.GetAll("?top=1000", Decode().Token).Result;
            }
            catch (Exception ex)
            {
                Tools.Exceptions.CompositeFillErrors cfe = Tools.Exceptions.HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                if (cfe != null)
                    ModelState.AddModelError(cfe.Field, cfe.Message);
            }
        }

        private void GetAllBusinessConfigurationTags(BusinessConfigurationVM vm)
        {
            try
            {
                //Get All Tags
                TagProxy tagProxy = new TagProxy();
                List<TagVM> listTags = tagProxy.GetAll("?top=1000", Decode().Token).Result;

                //Transform Tags to BusinessConfigurationTags
                List<BusinessConfigurationTagVM> listBCT = new List<BusinessConfigurationTagVM>();
                BusinessConfigurationTagVM bctVM = new BusinessConfigurationTagVM();
                foreach(var item in listTags)
                {
                    bctVM = new BusinessConfigurationTagVM
                    {
                        idbusinessconfiguration = vm.Id,
                        idbusinessconfigurationtag = 0,
                        idtag = item.Id,
                        state = 0,
                        Tag = item
                    };
                    listBCT.Add(bctVM);
                }
                vm.BusinessConfigurationTags = listBCT;
            }
            catch (Exception ex)
            {
                Tools.Exceptions.CompositeFillErrors cfe = Tools.Exceptions.HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                if (cfe != null)
                    ModelState.AddModelError(cfe.Field, cfe.Message);
            }
        }
        #endregion
    }
}