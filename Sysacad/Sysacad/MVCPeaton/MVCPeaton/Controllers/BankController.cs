using MVCPeaton.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HalClient.Net.Parser;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.IO;
using MVCPeaton.Models.ModelBuilders;

namespace MVCPeaton.Controllers
{
    public class BankController : BaseController<BankVM>
    {
        protected override string MySpecificUrl()
        {
            return "/api/banks";
        }
        public override List<BankVM> FillCollection(IRootResourceObject list)
        {
            return BankBuilder.FillCollection(list);
        }

        // GET: Bank
        public ActionResult Index(string name="")
        {
            try
            {
                List<BankVM> list = this.ListForm("?name=" + name + "&top=100").Result;
                return View("List", list);
            }
            catch (Exception ex)
            {
               return View();
            }
            
        }

        public override string MyRelationEmbeeded()
        {
            return "banks";
        }

        protected override BankVM Fill(IRootResourceObject resource)
        {
            return BankBuilder.Fill(resource);
        }

        protected override ActionResult MyAddForm()
        {
            throw new NotImplementedException();
        }

        protected override ActionResult MyDeleteForm(BankVM vm)
        {
            throw new NotImplementedException();
        }
        protected override ActionResult MyUpdateForm(BankVM vm)
        {
            throw new NotImplementedException();
        }       
    }
}