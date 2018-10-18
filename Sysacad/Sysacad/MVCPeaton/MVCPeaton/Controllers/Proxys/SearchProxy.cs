using HalClient.Net.Parser;
using MVCPeaton.Models.ModelBuilders;
using MVCPeaton.Models.ViewModels;
using MVCPeaton.Tools.Exceptions.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace MVCPeaton.Controllers.Proxys
{
    public class SearchProxy : BaseProxy<SearchVM>
    {
        protected override SearchVM Fill(IRootResourceObject resource)
        {
            return SearchBuilder.Fill(resource);
        }
        
        protected override List<SearchVM> FillCollection(IRootResourceObject list)
        {
            throw new NotImplementedException();
        }

        protected override string MyRelationEmbeeded()
        {
            throw new NotImplementedException();
        }

        protected override string MySpecificUrl()
        {
            return "/api/search";
        }

        public SearchVM GetAllNew(string filters, string cookievalue = "")
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

                        var dto = Fill(response.Resource);
                        return dto;
                    }
                    else
                    {
                        JsonHalExceptionClientHandler.HandleError(response.Message);

                    }
                }
                throw new Exception();
            }
        }
    
    }
}