using DeskTopSysacad.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskTopSysacad.Proxy
{
	public class Alumnos_InscripcionProxy : BaseSysacadProxy<Alumnos_InscripcionDTO>
	{
		protected override string MyRelationEmbeeded()
		{
			throw new NotImplementedException();
		}

		protected override string MySpecificUrl()
		{
			return "/api/alumnos_inscripciones";
		}
	}
}
