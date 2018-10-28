using DeskTopSysacad.DTO;
using DeskTopSysacad.Exceptions;
using HalClient.Net;
using HalClient.Net.Parser;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeskTopSysacad.Proxy
{
	public abstract class BaseSysacadProxy<dto> where dto : BaseSysacadDTO
	{
		public readonly static string baseUrl = "http://localhost:40784";
		private static IHalJsonParser parser;
		private static IHalHttpClientFactory factory;
        String resp = "";

        //private string myurl;
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

		public  dto Get(Int32 id, string cookievalue = "")
		{
			var resultado = "";
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(Myurl);
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			HttpResponseMessage response = Task.Run(() => client.GetAsync(new Uri(Myurl + "/" + id))).Result;
			resultado = response.Content.ReadAsStringAsync().Result;
			if (response.IsSuccessStatusCode)
			{
				resultado = response.Content.ReadAsStringAsync().Result;
			}
			var especialidad = JsonConvert.DeserializeObject<dto>(resultado);
			return especialidad;
		}

		public List<dto> GetAll(string filters, string cookievalue = "")
		{
			var resultado = "";
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(Myurl);
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			HttpResponseMessage response = Task.Run(() => client.GetAsync(new Uri(Myurl + filters))).Result;
			resultado = response.Content.ReadAsStringAsync().Result;
			if (response.IsSuccessStatusCode)
			{
				resultado = response.Content.ReadAsStringAsync().Result;
			}
			var especialidad = JsonConvert.DeserializeObject<IEnumerable<dto>>(resultado);
			return especialidad.ToList();			
		}

		public virtual String Create(dto model, string cookievalue = "")
		{
            try
            {
                using (var client = Factory.CreateClient())
                {
                    client.HttpClient.DefaultRequestHeaders.Clear();
                    client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));
                    if (!String.IsNullOrEmpty(cookievalue))
                        client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cookievalue);
                    string postBody = JsonConvert.SerializeObject(model);
                    var response = client.HttpClient.PostAsync((Myurl), new StringContent(postBody, Encoding.UTF8, "application/json")).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        resp = "Ok";
                        return resp;
                    }
                    else {
                        JsonError ap = JsonConvert.DeserializeObject<JsonError>(response.Content.ReadAsStringAsync().Result);
                        resp = ap.Message;
                        return resp;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
			

		}

		public virtual String Update(dto model, string cookievalue = "")
		{
			using (var client = Factory.CreateClient())
			{
				client.HttpClient.DefaultRequestHeaders.Clear();
				client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));
				if (!String.IsNullOrEmpty(cookievalue))
					client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cookievalue);

				string postBody = JsonConvert.SerializeObject(model);

                var response = client.HttpClient.PutAsync((Myurl + "/" + model.Id), new StringContent(postBody, Encoding.UTF8, "application/json")).Result;
                if (response.IsSuccessStatusCode)
                {
                    resp = "Ok";
                    return resp;
                }
                else
                {
                    JsonError ap = JsonConvert.DeserializeObject<JsonError>(response.Content.ReadAsStringAsync().Result);
                    resp = ap.Message;
                    return resp;
                }     
            }

		}

		public virtual String Delete(dto model, string cookievalue = "")
		{
			using (var client = Factory.CreateClient())
			{
				client.HttpClient.DefaultRequestHeaders.Clear();
				client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));
				if (!String.IsNullOrEmpty(cookievalue))
					client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cookievalue);
				string postBody = JsonConvert.SerializeObject(model);
                var response = client.HttpClient.DeleteAsync((Myurl + "/" + model.Id)).Result;
                if (response.IsSuccessStatusCode)
                {
                    resp = "Ok";
                    return resp;
                }
                else
                {
                    JsonError ap = JsonConvert.DeserializeObject<JsonError>(response.Content.ReadAsStringAsync().Result);
                    resp = ap.Message;
                    return resp;
                }             

            }

		}
	}
}
