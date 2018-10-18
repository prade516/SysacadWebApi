using HalClient.Net;
using HalClient.Net.Parser;
using MVCPeaton.Models.ViewModels;
using MVCPeaton.Tools.Exceptions.Handlers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MVCPeaton.Controllers.Proxys
{
    public abstract class BaseProxy<VM>  where VM : BaseVM
    {
		public readonly static string baseUrl = "http://localhost:40784";
		private static IHalJsonParser parser;
        private static IHalHttpClientFactory factory;
        private string myurl;
        public string Myurl
        {
            get
            {
                return baseUrl + MySpecificUrl();
            }

            set
            {
                ;
            }
        }

        private static IHalJsonParser Parser
        {
            get
            {
                if (parser == null)
                    parser = new HalJsonParser();
                return parser;
            }

            set
            {
                parser = value;
            }
        }

        public static IHalHttpClientFactory Factory
        {
            get
            {
                if (factory == null)
                    factory = new HalHttpClientFactory(Parser);
                return factory;
            }

            set
            {
                factory = value;
            }
        }

        protected abstract string MyRelationEmbeeded();
        protected abstract string MySpecificUrl();

        protected abstract List<VM> FillCollection(IRootResourceObject list);
        protected abstract VM Fill(IRootResourceObject resource);

        public virtual VM Get(Int64 id, string cookievalue = "")
        {
            using (var client = Factory.CreateClient())
            {
                client.HttpClient.DefaultRequestHeaders.Clear();
                client.HttpClient.DefaultRequestHeaders.Add("Accept", "application/hal+json");
                 if (!String.IsNullOrEmpty(cookievalue))
                    client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cookievalue);
                var response = Task.Run(() => client.GetAsync(new Uri(Myurl + "/" + id))).Result;
                if (response.IsHalResponse)
                {
                    if (response.Message.IsSuccessStatusCode)
                        return this.Fill(response.Resource);
                    else
                        JsonHalExceptionClientHandler.HandleError(response.Message);

                }
                throw new Exception();
            }
        }

        public virtual async Task<List<VM>> GetAll(string filters, string cookievalue = "")
        {
            using (var client = Factory.CreateClient())
            {
                client.HttpClient.DefaultRequestHeaders.Clear();
                client.HttpClient.DefaultRequestHeaders.Add("Accept", "application/hal+json");
                if (!String.IsNullOrEmpty(cookievalue))
                    client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cookievalue);
                var response = Task.Run(() => client.GetAsync(new Uri(Myurl + filters))).Result;
                if (response.IsHalResponse)
                {
                    if (response.Message.IsSuccessStatusCode)
                    {
                        // get the self link of the root resource
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
                        var listdto = FillCollection(response.Resource);
                        return listdto;
                    }
                    else
                    {
                        JsonHalExceptionClientHandler.HandleError(response.Message);

                    }
                }
                throw new Exception();
            }
        }

        public virtual void Create(VM model, string cookievalue = "")
        {
            using (var client = Factory.CreateClient())
            {
                client.HttpClient.DefaultRequestHeaders.Clear();
                client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));
                if (!String.IsNullOrEmpty(cookievalue))
                    client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cookievalue);
                string postBody = JsonConvert.SerializeObject(model);
                Task taskDownload = client.HttpClient.PostAsync((Myurl), new StringContent(postBody, Encoding.UTF8, "application/json"))
                    .ContinueWith(task =>
                    {
                        if (task.Status == TaskStatus.RanToCompletion)
                        {
                            var response = task.Result;

                            if (response.IsSuccessStatusCode)
                                return;
                            else
                                JsonHalExceptionClientHandler.HandleError(response);
                        }
                    });
                taskDownload.Wait();

            }
            
        }

        public virtual void Update(VM model, string cookievalue = "")
        {
            using (var client = Factory.CreateClient())
            {
                client.HttpClient.DefaultRequestHeaders.Clear();
                client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));
                if (!String.IsNullOrEmpty(cookievalue))
                    client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cookievalue);

                string postBody = JsonConvert.SerializeObject(model);
                Task taskDownload = client.HttpClient.PutAsync((Myurl + "/" + model.Id), new StringContent(postBody, Encoding.UTF8, "application/json"))
                    .ContinueWith(task =>
                    {
                        if (task.Status == TaskStatus.RanToCompletion)
                        {
                            var response = task.Result;

                            if (response.IsSuccessStatusCode)
                                return;
                            else
                                JsonHalExceptionClientHandler.HandleError(response);
                        }
                    });
                taskDownload.Wait();

            }
                
        }

        public virtual void Delete(VM model, string cookievalue = "")
        {
            using (var client = Factory.CreateClient())
            {
                client.HttpClient.DefaultRequestHeaders.Clear();
                client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));
                if (!String.IsNullOrEmpty(cookievalue))
                    client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cookievalue);
                string postBody = JsonConvert.SerializeObject(model);
                Task taskDownload = client.HttpClient.DeleteAsync((Myurl + "/" + model.Id))
                    .ContinueWith(task =>
                    {
                        if (task.Status == TaskStatus.RanToCompletion)
                        {
                            var response = task.Result;

                            if (response.IsSuccessStatusCode)
                                return;
                            else
                                JsonHalExceptionClientHandler.HandleError(response);
                        }
                    });
                taskDownload.Wait();

            }
                
        }
    }
}