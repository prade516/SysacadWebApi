
using DataModel;
using DataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Seguridad
{
	public class SeguridadDependencia : ISeguridad
	{
		private readonly UnitOfWork _punte;

		public SeguridadDependencia(UnitOfWork punte)
		{
			_punte = punte;
		}

		public SysacadContext Create()
		{
			return _punte.GetNewContext();
		}
	}
}
