using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MVCSysacad.Enum
{
	public enum Role
	{
		[Description("Administrador")]
		Administrador = 1,
		[Description("Docente")]
		Docente = 2,
		[Description("Alumno")]
		Alumno = 3
	}
}