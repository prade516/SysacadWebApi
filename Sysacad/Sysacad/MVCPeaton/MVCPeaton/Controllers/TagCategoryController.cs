using MVCPeaton.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HalClient.Net.Parser;
using System.Web.Mvc;
using MVCPeaton.Models.ModelBuilders;

namespace MVCPeaton.Controllers
{
    public class TagCategoryController : BaseController<TagCategoryVM>
    {
        //Index----------------------------------------------------------------------------------------------------------------------
        [System.Web.Mvc.Authorize(Roles = "Admin,Empresas,Usuarios")]
        public ActionResult Index()
        {
            int state = 1;
            int top = 100;
            string orderby = "idtagcategory";
            string ascending = "asc";
            int page = 1;
            string filters = "?state=" + state + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page;
            List<TagCategoryVM> list = this.ListForm(filters).Result;
            return View("List", list);
        }

        //Gets-----------------------------------------------------------------------------------------------------------------------
        [System.Web.Mvc.Authorize(Roles = "Admin")]
        protected override ActionResult MyAddForm()
        {
            return View("Insert", new TagCategoryVM());
        }

        [System.Web.Mvc.Authorize(Roles = "Admin")]
        protected override ActionResult MyDeleteForm(TagCategoryVM vm)
        {
            return View("Delete", vm);
        }

        [System.Web.Mvc.Authorize(Roles = "Admin")]
        protected override ActionResult MyUpdateForm(TagCategoryVM vm)
        {
            return View("Update", vm);
        }

        //Posts----------------------------------------------------------------------------------------------------------------------
        public override ActionResult Add(TagCategoryVM model)
        {
            try
            {
                return base.Add(model);
            }
            catch
            {
                return View("Error");
            }
        }

        public override ActionResult Update(TagCategoryVM model)
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

        public override ActionResult Delete(TagCategoryVM model)
        {
            try
            {
                return base.Delete(model);
            }
            catch
            {
                return View("Error");
            }
        }

        //Override-------------------------------------------------------------------------------------------------------------------
        public override string MyRelationEmbeeded()
        {
            return "tagcategories";
        }

        protected override string MySpecificUrl()
        {
            return "/api/tagcategories";
        }

        public override List<TagCategoryVM> FillCollection(IRootResourceObject resource)
        {
            return TagCategoryBuilder.FillCollection(resource);
        }

        protected override TagCategoryVM Fill(IRootResourceObject resource)
        {
            return TagCategoryBuilder.Fill(resource);
        }
    }
}
