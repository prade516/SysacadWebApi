
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HalClient.Net.Parser;
using MVCPeaton.Models.ViewModels;
using MVCPeaton.Controllers.Proxys;
using MVCPeaton.Models.ModelBuilders;

namespace MVCPeaton.Controllers.Proxys
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