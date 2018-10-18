using MVCSysacad.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HalClient.Net.Parser;

namespace MVCSysacad.Controllers.Proxy
{
	public class PersonaProxy : BaseProxy<PersonaVM>
	{
		protected override PersonaVM Fill(IRootResourceObject resource)
		{
			throw new NotImplementedException();
		}

		protected override List<PersonaVM> FillCollection(IRootResourceObject list)
		{
			throw new NotImplementedException();
		}

		protected override string MyRelationEmbeeded()
		{
			throw new NotImplementedException();
		}

		protected override string MySpecificUrl()
		{
			return "/api/personas";
		}
	}
}