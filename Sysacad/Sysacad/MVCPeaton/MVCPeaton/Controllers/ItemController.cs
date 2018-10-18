using MVCPeaton.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HalClient.Net.Parser;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using MVCPeaton.Models.ModelBuilders;

namespace MVCPeaton.Controllers
{
    public class ItemController : BaseController<ItemVM>
    {
 
        protected override string MySpecificUrl()
        {
            return "/api/items";
        }

        // GET: Item
        public ActionResult Index(string name="")
        {
            List<ItemVM> list = this.ListForm("?name="+ name).Result;
            return View("List",list);
        }

        public override string MyRelationEmbeeded()
        {
            return "items";
        }

        protected override ItemVM Fill(IRootResourceObject resource)
        {
            throw new NotImplementedException();
        }

        public override List<ItemVM> FillCollection(IRootResourceObject listResource)
        {
            return ItemBuilder.FillCollection(listResource);
        }

        // GET
        //[Authorize(Roles = "Admin")]
        protected override ActionResult MyAddForm()
        {
            ItemVM vm = new ItemVM();
            return View("Insert", vm);
        }

        // POST
        //[Authorize(Roles = "Admin")]
        public override ActionResult Add(ItemVM model)
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

        protected override ActionResult MyDeleteForm(ItemVM vm)
        {
            throw new NotImplementedException();
        }
        
        protected override ActionResult MyUpdateForm(ItemVM vm)
        {
            throw new NotImplementedException();
        }

    }
}