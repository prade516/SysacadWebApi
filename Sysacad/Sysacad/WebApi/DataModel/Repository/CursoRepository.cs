using DataModel.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Repository
{
	public class CursoRepository:GenericRepository.GenericRepository<cursos>, ICursoRepository
	{
		public CursoRepository(SysacadContext context) : base(context)
		{
		}
		public override void Delete(cursos entity, List<string> modifiedfields)
		{
			var curso = dbcontext.cursos.Find(entity.id_curso);
			curso.estado = entity.estado;
			curso.id_comision = entity.id_comision;
			curso.id_materia = entity.id_materia;
			curso.anio_calendario = entity.anio_calendario;
			curso.cupo = entity.cupo;
			dbcontext.cursos.Attach(curso);
			base.Delete(curso, modifiedfields);
		}
	}
}
