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
		public CursoBE CreateBusiness(DataModel.cursos entity)
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
					estado=entity.estado,
                    comisiones = entity.comisiones !=null ? FactoryComision.GetInstance().CreateBusiness(entity.comisiones) : null,
                    materias = entity.materias != null ? FactoryMateria.GetInstance().CreateBusiness(entity.materias):null
                };
				be.docentes_cursos = new List<Docente_CursoBE>();
				if (entity.docentes_cursos!=null)
				{
					foreach (var item in entity.docentes_cursos)
					{
						be.docentes_cursos.Add(FactoryDocente_Curso.GetInstance().CreateBusiness(item));
					}
				}

                be.alumnos_inscripciones = new List<Alumnos_InscripcionBE>();
                if (entity.alumnos_inscripciones != null)
                {
                    foreach (var item in entity.alumnos_inscripciones)
                    {
                        be.alumnos_inscripciones.Add(FactoryAlumnos_Inscripcion.GetInstance().CreateBusiness(item));
                    }
                }
				return be;
			}
			return be = new CursoBE();
		}
		#endregion
		#region Entity
		public DataModel.cursos CreateEntity(CursoBE be)
		{
            DataModel.cursos entity;
			if (be != null)
			{
				entity = new DataModel.cursos()
				{
					id_curso = be.id_curso,
					id_comision = be.id_comision,
					id_materia = be.id_materia,
					anio_calendario = be.anio_calendario,
					cupo = be.cupo,
					estado = be.estado
				};
				entity.docentes_cursos = new List<DataModel.docentes_cursos>();
				if (be.docentes_cursos!=null)
				{
					foreach (var item in be.docentes_cursos)
					{
						entity.docentes_cursos.Add(FactoryDocente_Curso.GetInstance().CreateEntity(item));
					}
				}
				return entity;
				
			}
			return entity = new DataModel.cursos();
		}
		#endregion
	}
}
