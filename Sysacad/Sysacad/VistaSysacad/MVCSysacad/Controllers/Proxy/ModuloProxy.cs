using MVCSysacad.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HalClient.Net.Parser;

namespace MVCSysacad.Controllers.Proxy
{
	public class ModuloProxy : BaseProxy<ModuloVM>
	{
		protected override ModuloVM Fill(IRootResourceObject resource)
		{
			throw new NotImplementedException();
		}

		protected override List<ModuloVM> FillCollection(IRootResourceObject list)
		{
			throw new NotImplementedException();
		}

		protected override string MyRelationEmbeeded()
		{
			throw new NotImplementedException();
		}

		protected override string MySpecificUrl()
		{
			return "/api/modulos";
		}
	}
}