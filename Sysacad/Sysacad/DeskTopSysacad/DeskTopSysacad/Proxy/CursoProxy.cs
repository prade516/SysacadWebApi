﻿using DeskTopSysacad.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskTopSysacad.Proxy
{
	public class CursoProxy : BaseSysacadProxy<CursoDTO>
	{
		protected override string MyRelationEmbeeded()
		{
			throw new NotImplementedException();
		}

		protected override string MySpecificUrl()
		{
			return "/api/cursos";
		}
	}
}
