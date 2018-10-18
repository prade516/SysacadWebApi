using DataModel.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Repository
{
	public class Alumnos_InscripcionesRepository : GenericRepository.GenericRepository<alumnos_inscripciones>, IAlumnos_InscripcionesRepository
	{
		public Alumnos_InscripcionesRepository(SysacadContext context) : base(context)
		{
		}
		public override void Delete(alumnos_inscripciones entity, List<string> modifiedfields)
		{
			var inscripto = dbcontext.alumnos_inscripciones.Find(entity.id_inscripcion);
			inscripto.estado = entity.estado;
			inscripto.id_curso = entity.id_curso;
			inscripto.id_alumno = entity.id_alumno;
			inscripto.condicion = entity.condicion;
			inscripto.nota = entity.nota;
			dbcontext.alumnos_inscripciones.Attach(inscripto);
			base.Delete(inscripto, modifiedfields);
		}
	}
}
