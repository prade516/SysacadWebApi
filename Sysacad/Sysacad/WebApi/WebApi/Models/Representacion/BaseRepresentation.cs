using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Hal;
using WebApi.Models.Hypermedia;

namespace WebApi.Models.Representacion
{
	public abstract class BaseRepresentation : Representation
	{
		public abstract Int64 IDRepresentation();
		[JsonIgnore]
		public BaseHypermedia _mytemplate;
		[JsonIgnore]
		public abstract BaseHypermedia Mytemplate { get; set; }

		public virtual void CreatesMySelfLinks()
		{
			Link mylink = Mytemplate.GetMyOwnReference(IDRepresentation());
			Links.Add(mylink);
		}

		public virtual void CreateUpdateLink()
		{
			Link mylink = Mytemplate.GetMyUpdateLink(IDRepresentation());
			Links.Add(mylink);
		}

		public virtual void CreateDeleteLink()
		{
			Link mylink = Mytemplate.GetMyDeleteLink(IDRepresentation());
			Links.Add(mylink);
		}
	}
}