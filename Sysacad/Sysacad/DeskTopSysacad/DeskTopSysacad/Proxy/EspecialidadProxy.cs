using DeskTopSysacad.DTO;
using DeskTopSysacad.Proxy;
using HalClient.Net.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskTopSysacad.Properties
{
	public class EspecialidadProxy : BaseSysacadProxy<EspecialidadDTO>
	{	
		public EspecialidadProxy Myproxy()
		{
			return new EspecialidadProxy();
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
