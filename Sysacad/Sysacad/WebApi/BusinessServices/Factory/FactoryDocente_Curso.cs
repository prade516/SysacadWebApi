using BusinessEntities;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Factory
{
	public class FactoryDocente_Curso
	{
		private static FactoryDocente_Curso _factory;
		public static FactoryDocente_Curso GetInstance()
		{
			if (_factory == null)
				_factory = new FactoryDocente_Curso();
			return _factory;
		}
		#region Business
		public Docente_CursoBE CreateBusiness(DataModel.docentes_cursos entity)
		{
			Docente_CursoBE be;
			if (entity!=null)
			{
				be = new Docente_CursoBE()
				{
					id_curso=entity.id_curso,
					id_dictado=entity.id_dictado,
					id_docente=entity.id_docente,
					cargo=entity.cargo,
					estado=entity.estado
				};				
				return be;
				
			}
			return be = new Docente_CursoBE();
		}
		#endregion
		#region Entity
		public DataModel.docentes_cursos CreateEntity(Docente_CursoBE be)
		{
            DataModel.docentes_cursos entity;
			if (be!=null)
			{
				entity = new DataModel.docentes_cursos()
				{
					id_curso=be.id_curso,
					id_dictado=be.id_dictado,
					id_docente=be.id_docente,
					cargo=be.cargo,
					estado=be.estado
				};
				return entity;
			}
			return entity = new DataModel.docentes_cursos();
		}
		#endregion
	}
}
