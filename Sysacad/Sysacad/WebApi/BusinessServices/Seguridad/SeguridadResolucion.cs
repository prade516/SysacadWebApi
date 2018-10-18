using BusinessServices.Interface;
using BusinessServices.Services;
using SolveApi.Extention;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Seguridad
{
	[Export(typeof(System.ComponentModel.IComponent))]
	public class SeguridadResolucion:SolveApi.Extention.IComponent
	{
		public void SetUp(IRegisterComponent registerComponent)
		{
			registerComponent.RegisterType<IEspecialidadServices, EspecialidadService>();
			
		}
	}
}
