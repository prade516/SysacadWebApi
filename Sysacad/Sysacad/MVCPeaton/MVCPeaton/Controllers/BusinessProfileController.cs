using MVCPeaton.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HalClient.Net.Parser;
using MVCPeaton.Controllers.Proxys;
using MVCPeaton.Tools;
using MVCPeaton.Enums;
using MVCPeaton.Tools.Exceptions;

namespace MVCPeaton.Controllers
{
    public class BusinessProfileController : BaseProxyController<BusinessProfileVM>
    {
        private BusinessProfileProxy _myProxy;

        public BusinessProfileProxy MyProxy
        {
            get
            {
                if (_myProxy == null)
                    _myProxy = new BusinessProfileProxy();
                return _myProxy;
            }

            set
            {
                _myProxy = value;
            }
        }

        protected override string MySpecificUrl()
        {
            return "/api/businessprofiles";
        }

        // GET: BusinessProfile
        public ActionResult Index()
        {
            //var bussinessid = Convert.ToInt64(HttpContext.Current.User.Identity.GetUserId());
            //MyProxy.Get(bussinessid, null);
            return RedirectToAction("Update");
        }

        public override ActionResult AddForm()
        {
            BusinessProfileVM vm = new BusinessProfileVM() { Photos = new List<PhotoVM>() {
            new PhotoVM(), new PhotoVM(), new PhotoVM(), new PhotoVM(), new PhotoVM()}
            };
            return View("Insert", vm);
        }

        public override ActionResult UpdateForm(long id)
        {
            base.UpdateForm(id);
            return View("Update");
        }       

        public ActionResult Miperfil()
        {
            List<BusinessProfileVM> businessprofile = new List<BusinessProfileVM>();
            if (!ModelState.IsValid)
                return View();
            string cookievalue = "";
            if (User.Identity.IsAuthenticated)
                cookievalue = Decode().Token;
            Int32 top = 1;
            String orderby = "idbusinessprofile";
            String ascending = "asc";
            Int32 page = 1;
            String user = Decode().UserName;
            String filtros = "?user=" + user + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page + "&name=" + user;
            try
            {
                businessprofile = Myproxy().GetAll(filtros, cookievalue).Result;
                businessprofile.FirstOrDefault().Links.RemoveAll(x => x.state == (Int32)StatesEnum.Annulled);
                businessprofile.FirstOrDefault().Photos.RemoveAll(x => x.state == (Int32)StatesEnum.Annulled);
                return View("Update", businessprofile.FirstOrDefault());
            }
            catch (Exception ex)
            {
                return RedirectToAction("AddForm");
            }
         }           
      
        public override ActionResult Update(BusinessProfileVM model)
        {
            #region Variables
            PhotoVM manuPhoto = new PhotoVM();
            List<String> listManuPhotoString = new List<String>();
            int index = 0;
            if (model.Foto1 != null) { listManuPhotoString.Add(model.Foto1); index = 0; }
            if (model.Foto2 != null) { listManuPhotoString.Add(model.Foto2); index = 1; }
            if (model.Foto3 != null) { listManuPhotoString.Add(model.Foto3); index = 2; }
            if (model.Foto4 != null) { listManuPhotoString.Add(model.Foto4); index = 3; }
            if (model.Foto5 != null) { listManuPhotoString.Add(model.Foto5); index = 4; }
            if (model.Foto6 != null) { listManuPhotoString.Add(model.Foto6); index = 5; }
            #endregion
            #region Manu Photo
            if (model.Photos != null)
            {
                foreach (var item in listManuPhotoString)
                {
                    if (index >= model.Photos.Count)
                    {
                        manuPhoto = new PhotoVM()
                        {
                            photo = item,
                            state = (Int32)StatesEnum.Valid,
                            idbusinessprofile = model.idbusinessprofile,
                            idphoto = 0,
                        };
                        model.Photos.Add(manuPhoto);
                    }
                    else
                    {
                        if (item == model.Photos[index].photo)
                        {
                            manuPhoto = new PhotoVM()
                            {
                                photo = model.Photos[index].photo,
                                state = model.Photos[index].state,
                                idphoto = model.Photos[index].idphoto,
                                idbusinessprofile = model.Photos[index].idbusinessprofile
                            };
                            model.Photos[index] = manuPhoto;
                        }
                        else
                        {
                            manuPhoto = new PhotoVM()
                            {
                                photo = item,
                                state = (Int32)StatesEnum.Annulled,
                                idphoto = model.Photos[index].idphoto,
                                idbusinessprofile = model.Photos[index].idbusinessprofile
                            };
                            model.Photos[index] = manuPhoto;
                        }
                    }
                }
            }
            else
            {
                model.Photos = new List<PhotoVM>();
                foreach (var item in listManuPhotoString)
                {
                    manuPhoto = new PhotoVM()
                    {
                        photo = item,
                        state = (Int32)StatesEnum.Valid,
                        idbusinessprofile = model.idbusinessprofile,
                        idphoto = 0,
                    };
                    model.Photos.Add(manuPhoto);
                }
            }
            #endregion

            #region Links
            LinkVM linkvm = new LinkVM();

            linkvm = new LinkVM()
            {
                link = model.Link6,
                idbusinessprofile = model.idbusinessprofile,
                state = Convert.ToInt32(StatesEnum.Valid),
                type = Convert.ToInt32(SocialEnum.Other)
            };
            model.Links.Add(linkvm);
            linkvm = new LinkVM()
            {
                link = model.Link7,
                idbusinessprofile = model.idbusinessprofile,
                state = Convert.ToInt32(StatesEnum.Valid),
                type = Convert.ToInt32(SocialEnum.Other)
            };
            model.Links.Add(linkvm);
            linkvm = new LinkVM()
            {
                link = model.Link8,
                idbusinessprofile = model.idbusinessprofile,
                state = Convert.ToInt32(StatesEnum.Valid),
                type = Convert.ToInt32(SocialEnum.Other)
            };
            model.Links.Add(linkvm);

            model.Links.RemoveAll(x => x.link == null);
            #endregion

            try
            {
                // En caso de ser invalido el ModelState.
                if (!ModelState.IsValid)
                    return RedirectToAction("Miperfil"); //Error del modelo
                string cookievalue = "";
                if (User.Identity.IsAuthenticated)
                    cookievalue = Decode().Token;
                Myproxy().Update(model, cookievalue);
                return RedirectToAction("Miperfil"); //Exito
            }
            catch (Exception ex)
            {
                HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                return RedirectToAction("Miperfil"); //Error
            }
        }
        //Ejemplo
        public ActionResult GetDelApi()
        {
           // MyProxy.Get()
            BusinessProfileVM vm = new BusinessProfileVM();
            return View("Insert", vm);
        }
        [HttpPost]
        public override ActionResult Add(BusinessProfileVM model)
        {
            #region  Photos
            List<PhotoVM> listPhoto = new List<PhotoVM>();
            PhotoVM photovm = new PhotoVM();

            photovm = new PhotoVM()
            {
                photo = model.Foto1,
            };
            listPhoto.Add(photovm);

            photovm = new PhotoVM()
            {
                photo = model.Foto2,
            };
            listPhoto.Add(photovm);

            photovm = new PhotoVM()
            {
                photo = model.Foto3,
            };
            listPhoto.Add(photovm);

            photovm = new PhotoVM()
            {
                photo = model.Foto4,
            };
            listPhoto.Add(photovm);

            photovm = new PhotoVM()
            {
                photo = model.Foto5,
            };
            listPhoto.Add(photovm);

            photovm = new PhotoVM()
            {
                photo = model.Foto6,
            };
            listPhoto.Add(photovm);

            listPhoto.RemoveAll(x => x.photo == null);

            model.Photos = listPhoto;

            #endregion
            #region Links
            List<LinkVM> listLinks = new List<LinkVM>();
            LinkVM linkvm = new LinkVM();

            linkvm = new LinkVM()
            {
                link = model.Link1,
                type = Convert.ToInt32(SocialEnum.Facebook)
            };
            listLinks.Add(linkvm);

            linkvm = new LinkVM()
            {
                link = model.Link2,
                type = Convert.ToInt32(SocialEnum.Twitter)
            };
            listLinks.Add(linkvm);

            linkvm = new LinkVM()
            {
                link = model.Link3,
                type = Convert.ToInt32(SocialEnum.Instagram)
            };
            listLinks.Add(linkvm);

            linkvm = new LinkVM()
            {
                link = model.Link4,
                type = Convert.ToInt32(SocialEnum.WebSite)
            };
            listLinks.Add(linkvm);

            linkvm = new LinkVM()
            {
                link = model.Link5,
                type = Convert.ToInt32(SocialEnum.GooglePlus)
            };
            listLinks.Add(linkvm);

            linkvm = new LinkVM()
            {
                link = model.Link6,
                type = Convert.ToInt32(SocialEnum.Other)
            };

            linkvm = new LinkVM()
            {
                link = model.Link7,
                type = Convert.ToInt32(SocialEnum.Other)
            };

            linkvm = new LinkVM()
            {
                link = model.Link8,
                type = Convert.ToInt32(SocialEnum.Other)
            };
            listLinks.Add(linkvm);

            listLinks.RemoveAll(x => x.link == null);

            model.Links = listLinks;

            #endregion
            #region State
            foreach (var a in model.Links)
            {
                a.state = (Int32)StatesEnum.Valid;
            }

            foreach (var a in model.Photos)
            {
                a.state = (Int32)StatesEnum.Valid;
            }

            #endregion

            base.Add(model);
            return View("Exito");
        }
        public override BaseProxy<BusinessProfileVM> Myproxy()
        {
            return MyProxy;
        }

        public override string MyRelationEmbeeded()
        {
            throw new NotImplementedException();
        }
    }
}