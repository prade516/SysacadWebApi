using MVCSysacad.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HalClient.Net.Parser;
using MVCSysacad.Models.ModelBuilder;

namespace MVCSysacad.Controllers.Proxy
{
	public class EspecialidadProxy : BaseProxy<EspecialidadVM>
	{
		protected override EspecialidadVM Fill(IRootResourceObject resource)
		{
			return EspecialidadBuilder.Fill(resource);
		}

		protected override List<EspecialidadVM> FillCollection(IRootResourceObject list)
		{
			return EspecialidadBuilder.FillCollection(list);
		}

		protected override string MyRelationEmbeeded()
		{
			throw new NotImplementedException();
		}

		protected override string MySpecificUrl()
		{
			return "/api/especialidades";
		}
	}
}