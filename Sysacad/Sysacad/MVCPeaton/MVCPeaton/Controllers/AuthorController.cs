using MVCPeaton.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HalClient.Net.Parser;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using HalClient.Net;
using System.Net.Http;
using System.Text;
using System.Net;

namespace MVCPeaton.Controllers
{
    public class AuthorController : BaseController<AuthorVM>
    {
        protected override string MySpecificUrl()
        {
            return "/api/authors";
        }
        // GET: Author
        public ActionResult Index()
        {
          List<AuthorVM> list= this.ListForm("").Result;
          return View(list);
        }
        public override List<AuthorVM> FillCollection(IRootResourceObject resource)
        {
            var embeeded = resource.Embedded["authors"].ToList();
            AuthorVM author;
            List<AuthorVM> listdto = new List<AuthorVM>(); 
            foreach (var item in embeeded)
            {
                author = new AuthorVM()
                {
                    Id = Int64.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("Id")).Value),
                    Name = item.State.Values.FirstOrDefault(t => t.Name.Equals("Name")).Value,
                    MyLink = item.Links.First(t => t.Key.Equals("self")).Value.
                        First(d => d.Rel.Equals("self")).Href.ToString(),
                    UpdateLink = item.Links.First(t => t.Key.Equals("update")).Value.
                        First(d=>d.Rel.Equals("update")).Href.ToString(),
                    DeleteLink = item.Links.First(t => t.Key.Equals("delete")).Value.
                        First(d => d.Rel.Equals("delete")).Href.ToString(),
                     MyBooksLink= item.Links.First(t => t.Key.Equals("books")).Value.
                        First(d => d.Rel.Equals("books")).Href.ToString(),
                };
                listdto.Add(author);
            };
            return listdto;
        }

        public override string MyRelationEmbeeded()
        {
            return "authors";
        }
        
               
        protected override ActionResult MyUpdateForm(AuthorVM vm)
        {
            return View("UpdateForm", vm);
        }

        protected override AuthorVM Fill(IRootResourceObject resource)
        {
            return new AuthorVM()
            {
                Id = Int64.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("Id")).Value),
                Name = resource.State.Values.FirstOrDefault(t => t.Name.Equals("Name")).Value,
                MyLink = resource.Links.First(t => t.Key.Equals("self")).Value.
                        First(d => d.Rel.Equals("self")).Href.ToString(),
            };
        }

        protected override ActionResult MyAddForm()
        {
            return View("AddForm", new AuthorVM());
        }

        protected override ActionResult MyDeleteForm(AuthorVM vm)
        {
            return View("DeleteForm", vm);
        }
    }
}