﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace DeskTopSysacad.Exceptions
{
	public class JsonError
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
	}
}