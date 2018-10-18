using MVCPeaton.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HalClient.Net.Parser;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using MVCPeaton.Security;
using System.Net.Http.Headers;
using build = MVCPeaton.Models.ModelBuilders;

namespace MVCPeaton.Controllers
{
    public class TagController : BaseController<TagVM>
    {
        //Index----------------------------------------------------------------------------------------------------------------------
        [System.Web.Mvc.Authorize(Roles = "Admin,Empresas,Usuarios")]
        public ActionResult Index()
        {
            int state = 1;
            int top = 100;
            string orderby = "idtag";
            string ascending = "asc";
            int page = 1;
            string filters = "?state=" + state + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page;
            List<TagVM> list = this.ListForm(filters).Result;
            return View("List", list);
        }

        //Gets-----------------------------------------------------------------------------------------------------------------------
        [System.Web.Mvc.Authorize(Roles = "Admin")]
        protected override ActionResult MyAddForm()
        {
            TagVM vm = new TagVM();
            GetAllTagCategories(vm);
            return View("Insert", vm);
        }

        [System.Web.Mvc.Authorize(Roles = "Admin")]
        protected override ActionResult MyDeleteForm(TagVM vm)
        {
            return View("Delete", vm);
        }

        [System.Web.Mvc.Authorize(Roles = "Admin")]
        protected override ActionResult MyUpdateForm(TagVM vm)
        {
            GetAllTagCategories(vm);
            return View("Update", vm);
        }

        //Posts----------------------------------------------------------------------------------------------------------------------
        public override ActionResult Add(TagVM model)
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

        public override ActionResult Update(TagVM model)
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

        public override ActionResult Delete(TagVM model)
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
        protected override string MySpecificUrl()
        {
            return "/api/tags";
        }

        public override string MyRelationEmbeeded()
        {
            return "tags";
        }

        public override List<TagVM> FillCollection(IRootResourceObject resource)
        {
            return build.TagBuilder.FillCollection(resource);
        }

        protected override TagVM Fill(IRootResourceObject resource)
        {
            return build.TagBuilder.Fill(resource);
        }

        //Private methods------------------------------------------------------------------------------------------------------------
        private void GetAllTagCategories(TagVM vm)
        {
            List<TagCategoryVM> listdto = new List<TagCategoryVM>();
            using (var client = Factory.CreateClient())
            {
                client.HttpClient.DefaultRequestHeaders.Clear();
                client.HttpClient.DefaultRequestHeaders.Add("Accept", "application/hal+json");
                HttpStatusCode code;
                string responseBody = "";
                if (User.Identity.IsAuthenticated)
                {
                    DataValues datavalue = Decode();
                    client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", datavalue.Token);
                }
                var response = Task.Run(() => client.GetAsync(new Uri("http://localhost:40784/api/tagcategories"))).Result;
                if (response.IsHalResponse)
                {
                    if (response.Message.IsSuccessStatusCode)
                    {
                        var selfUri = response.Resource.Links["self"].First().Href;
                        var findUri = response.Resource.Links["find"].First().Href;
                        var next = response.Resource.Links.ContainsKey("next") ?
                            response.Resource.Links["next"].FirstOrDefault().Href : new Uri("Http://N/A");
                        var prev = response.Resource.Links.ContainsKey("prev") ?
                            response.Resource.Links["prev"].FirstOrDefault().Href : new Uri("Http://N/A");
                        var first = response.Resource.Links.ContainsKey("first") ?
                            response.Resource.Links["first"].FirstOrDefault().Href : new Uri("Http://N/A");
                        var last = response.Resource.Links.ContainsKey("last") ?
                            response.Resource.Links["last"].FirstOrDefault().Href : new Uri("Http://N/A");
                        listdto = build.TagCategoryBuilder.FillCollection(response.Resource);
                    }
                    else
                    {
                        code = response.Message.StatusCode;
                        responseBody = response.Message.Content.ReadAsStringAsync().Result;
                    }
                }
            }
            vm.TagCategories = listdto;
        }

        //private TagVM GetOne(Int64 id)
        //{
        //    TagVM vm = new TagVM();
        //    using (var client = Factory.CreateClient())
        //    {
        //        client.HttpClient.DefaultRequestHeaders.Clear();
        //        client.HttpClient.DefaultRequestHeaders.Add("Accept", "application/hal+json");
        //        HttpStatusCode code;
        //        string responseBody = "";
        //        if (User.Identity.IsAuthenticated)
        //        {
        //            DataValues datavalue = Decode();
        //            client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", datavalue.Token);
        //        }
        //        var response = Task.Run(() => client.GetAsync(new Uri("http://localhost:8089/api/tagcategories/" + id))).Result;
        //        if (response.IsHalResponse)
        //        {
        //            if (response.Message.IsSuccessStatusCode)
        //            {
        //                var selfUri = response.Resource.Links["self"].First().Href;
        //                var findUri = response.Resource.Links["find"].First().Href;
        //                var next = response.Resource.Links.ContainsKey("next") ?
        //                    response.Resource.Links["next"].FirstOrDefault().Href : new Uri("Http://N/A");
        //                var prev = response.Resource.Links.ContainsKey("prev") ?
        //                    response.Resource.Links["prev"].FirstOrDefault().Href : new Uri("Http://N/A");
        //                var first = response.Resource.Links.ContainsKey("first") ?
        //                    response.Resource.Links["first"].FirstOrDefault().Href : new Uri("Http://N/A");
        //                var last = response.Resource.Links.ContainsKey("last") ?
        //                    response.Resource.Links["last"].FirstOrDefault().Href : new Uri("Http://N/A");
        //                vm = this.Fill(response.Resource);
        //            }
        //            else
        //            {
        //                code = response.Message.StatusCode;
        //                responseBody = response.Message.Content.ReadAsStringAsync().Result;
        //            }
        //        }
        //    }
        //    return vm;
        //}
    }
}
