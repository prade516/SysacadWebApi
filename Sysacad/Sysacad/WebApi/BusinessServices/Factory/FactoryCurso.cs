using BusinessEntities;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Factory
{
	public class FactoryCurso
	{
		private static FactoryCurso _factory;
		public static FactoryCurso GetInstance()
		{
			if (_factory == null)
				_factory = new FactoryCurso();
			return _factory;
		}
		#region Business
		public CursoBE CreateBusiness(cursos entity)
		{
			CursoBE be;
			if (entity!=null)
			{
				be = new CursoBE()
				{
					id_curso=entity.id_curso,
					id_comision=entity.id_comision,
					id_materia=entity.id_materia,
					anio_calendario=entity.anio_calendario,
					cupo=entity.cupo,
					estado=entity.estado
				};
				be.Docente_curso = new List<Docente_CursoBE>();
				if (entity.Docente_curso!=null)
				{
					foreach (var item in entity.Docente_curso)
					{
						be.Docente_curso.Add(FactoryDocente_Curso.GetInstance().CreateBusiness(item));
					}
				}
				return be;
			}
			return be = new CursoBE();
		}
		#endregion
		#region Entity
		public cursos CreateEntity(CursoBE be)
		{
			cursos entity;
			if (be != null)
			{
				entity = new cursos()
				{
					id_curso = be.id_curso,
					id_comision = be.id_comision,
					id_materia = be.id_materia,
					anio_calendario = be.anio_calendario,
					cupo = be.cupo,
					estado = be.estado
				};
				entity.Docente_curso = new List<docentes_cursos>();
				if (be.Docente_curso!=null)
				{
					foreach (var item in be.Docente_curso)
					{
						entity.Docente_curso.Add(FactoryDocente_Curso.GetInstance().CreateEntity(item));
					}
				}
				return entity;
				
			}
			return entity = new cursos();
		}
		#endregion
	}
}
