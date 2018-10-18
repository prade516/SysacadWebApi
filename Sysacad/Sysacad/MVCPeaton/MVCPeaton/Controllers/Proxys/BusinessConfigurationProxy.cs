using MVCPeaton.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HalClient.Net.Parser;
using MVCPeaton.Models.ModelBuilders;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using MVCPeaton.Tools.Exceptions.Handlers;

namespace MVCPeaton.Controllers.Proxys
{
    public class BusinessConfigurationProxy : BaseProxy<BusinessConfigurationVM>
    {
        protected override BusinessConfigurationVM Fill(IRootResourceObject resource)
        {
            return BusinessConfigurationBuilder.Fill(resource);
        }

        protected override List<BusinessConfigurationVM> FillCollection(IRootResourceObject list)
        {
            return BusinessConfigurationBuilder.FillCollection(list);
        }

        protected override string MyRelationEmbeeded()
        {
            return "businessconfigurations";
        }

        protected override string MySpecificUrl()
        {
            return "/api/businessconfigurations";
        }

        //
        public virtual async Task<List<BusinessConfigurationTagVM>> GetTagsById(string filters, string cookievalue = "")
        {
            using (var client = Factory.CreateClient())
            {
                client.HttpClient.DefaultRequestHeaders.Clear();
                client.HttpClient.DefaultRequestHeaders.Add("Accept", "application/hal+json");
                if (!String.IsNullOrEmpty(cookievalue))
                    client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cookievalue);
                var response = Task.Run(() => client.GetAsync(new Uri(Myurl + "/0/tags/" + filters))).Result;
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
                        var listdto = BusinessConfigurationBuilder.listBusinessConfigurationTags(response.Resource);
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
        //
    }
}