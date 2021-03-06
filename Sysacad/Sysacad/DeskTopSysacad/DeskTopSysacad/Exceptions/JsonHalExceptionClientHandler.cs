﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace DeskTopSysacad.Exceptions
{
	public class JsonHalExceptionClientHandler : BaseExceptionClientHandler
	{
		[JsonProperty]
		public int ErrorCode { get; set; }
		[JsonProperty]
		public string ErrorDescription { get; set; }
        public string Message { get; set; }
        [JsonProperty]
		public HttpStatusCode HttpStatus { get; set; }

		string reasonPhrase;

		[JsonProperty]
		public string ReasonPhrase
		{
			get
			{
				return this.HttpStatus.ToString();
			}

			set { this.reasonPhrase = value; }
		}

		[JsonProperty]
		public string ReferenceLink { get; set; }


		public override CompositeFillErrors HandleExceptions(Exception ex)
		{
			if (ex.InnerException is JsonHalExceptionClientHandler)
				return Run(ex);
			return Mychainhandler.HandleExceptions(ex);
		}

		public override CompositeFillErrors Run(Exception ex)
		{
			int code;
			string message = "";
			JsonHalExceptionClientHandler myex = (JsonHalExceptionClientHandler)ex.InnerException;
			code = myex.ErrorCode;
			message = myex.ErrorDescription;
			KeyValuePair<int, string> rowerror = ClientCodeHandler.GetInstance().CodeExceptions.FirstOrDefault(t => t.Key.Equals(code));
			CompositeFillErrors cfe = new CompositeFillErrors() { Field = rowerror.Value, Message = message };
			return cfe;
		}

		public static void HandleError(HttpResponseMessage response)
		{            
            JsonError ap = JsonConvert.DeserializeObject<JsonError>(response.Content.ReadAsStringAsync().Result);
            throw new JsonHalExceptionClientHandler
            ()
            {               
                Message = ap.Message,
                ErrorDescription = ap.Message,
            };
		}
        public String Error(HttpResponseMessage response)
        {
            JsonError ap = JsonConvert.DeserializeObject<JsonError>(response.Content.ReadAsStringAsync().Result);
            throw new JsonHalExceptionClientHandler
            ()
            {
                Message = ap.Message,
                ErrorDescription = ap.Message,
            };
        }
        
        static JsonHalExceptionClientHandler _instance;
		private JsonHalExceptionClientHandler() { }
		public static JsonHalExceptionClientHandler GetInstance()
		{
			if (_instance == null)
				_instance = new JsonHalExceptionClientHandler();
			return _instance;
		}
	}
}