using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Hal;

namespace WebApi.Models.Hypermedia
{
	public class CursoHypermedia : BaseHypermedia
	{
		private static CursoHypermedia _mytemplate;
		private CursoHypermedia() { }
		public static CursoHypermedia GetInstance()
		{
			if (_mytemplate == null)
				_mytemplate = new CursoHypermedia();
			return _mytemplate;
		}
		public override Link GetMyCollectionPagination()
		{
			return GetPagination.CreateLink();
		}

		public override Link GetMyCollectionReference()
		{
			return GetCursos.CreateLink();
		}

		public override Link GetMyDeleteLink(long ID)
		{
			return DeleteCurso.CreateLink(new { id = ID });
		}

		public override Link GetMyOwnReference(long ID)
		{
			return Curso.CreateLink(new { id = ID });
		}

		public override Link GetMyRelationReference()
		{
			return CursoRelation;
		}

		public override Link GetMyUpdateLink(long ID)
		{
			return UpdateCurso.CreateLink(new { id = ID });
		}

		public static Link GetCursos { get { return new Link("ref", baseaddress + "/cursos"); } }
		public static Link Curso { get { return new Link("self", baseaddress + "/cursos/{id}"); } }
		public static Link CursoRelation { get { return new Link("cursos", baseaddress + "/cursos/{id}"); } }
		public static Link UpdateCurso { get { return new Link("update", baseaddress + "/cursos/{id}"); } }
		public static Link DeleteCurso { get { return new Link("delete", baseaddress + "/cursos/{id}"); } }
		public static Link GetPagination { get { return new Link("cursos", baseaddress + "/cursos/{?page}"); } }

		public static Link GetDocente_Curso { get { return new Link("docente_cursos", baseaddress + "/docente_cursos/{id}"); } }
		public static Link GetMyDocente_Curso { get { return new Link("docente_cursos", baseaddress + "/cursos/{id}" + "/docente_cursos/{id2}"); } }
		public static Link GetMyDocente_Cursos { get { return new Link("docente_cursos", baseaddress + "/cursos/{id}" + "/docente_cursos"); } }
	}
}