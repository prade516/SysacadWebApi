using DataModel.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Repository
{
	public class Docentes_CursosRepository : GenericRepository.GenericRepository<docentes_cursos>, IDocentes_CursosRepository
	{
		public Docentes_CursosRepository(SysacadContext context) : base(context)
		{
		}
		public override void Update(docentes_cursos entity, List<string> modifiedfields)
		{
			var doc_curso = dbcontext.docentes_cursos.Find(entity.id_dictado);
			doc_curso.estado = entity.estado;
			doc_curso.id_docente = entity.id_docente;
			doc_curso.id_curso = entity.id_curso;
			doc_curso.cargo = entity.cargo;
			dbcontext.docentes_cursos.Attach(doc_curso);
			base.Update(doc_curso, modifiedfields);
		}
	}
}
