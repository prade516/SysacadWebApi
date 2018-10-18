﻿using DeskTopSysacad.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskTopSysacad.Proxy
{
	public class ModuloProxy : BaseSysacadProxy<ModuloDTO>
	{	
		public ModuloProxy Myproxy()
		{
			return new ModuloProxy();
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
