using BusinessEntities;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Factory
{
	class FactoryAlumnos_Inscripcion
	{
		private static FactoryAlumnos_Inscripcion _factory;
		public static FactoryAlumnos_Inscripcion GetInstance()
		{
			if (_factory == null)
				_factory = new FactoryAlumnos_Inscripcion();
			return _factory;
		}
		#region Business
		public Alumnos_InscripcionBE CreateBusiness(DataModel.alumnos_inscripciones entity)
		{
			Alumnos_InscripcionBE be;
			if (entity!=null)
			{
				be = new Alumnos_InscripcionBE()
				{
					id_inscripcion=entity.id_inscripcion,
					id_curso=entity.id_curso,
					id_alumno=entity.id_alumno,
					condicion=entity.condicion,
					nota=entity.nota,
					estado=entity.estado
				};
				be.cursos = new CursoBE();
				if (entity.cursos!=null)
				{
					be.cursos = FactoryCurso.GetInstance().CreateBusiness(entity.cursos);
				}
				be.personas = new PersonaBE();
				if (entity.personas!=null)
				{
					be.personas = FactoryPersona.GetInstance().CreateBusiness(entity.personas);
				}
				return be;
			}
			return be = new Alumnos_InscripcionBE();
		}
		#endregion
		#region Entity
		public DataModel.alumnos_inscripciones  CreateEntity(Alumnos_InscripcionBE be)
		{
            DataModel.alumnos_inscripciones entity;
			if (be != null)
			{
				entity = new DataModel.alumnos_inscripciones()
				{
					id_inscripcion = be.id_inscripcion,
					id_curso = be.id_curso,
					id_alumno=be.id_alumno,
					condicion = be.condicion,
					nota = be.nota,
					estado = be.estado
				};
				return entity;
			}
			return entity = new DataModel.alumnos_inscripciones();
		}
		#endregion
	}
}
