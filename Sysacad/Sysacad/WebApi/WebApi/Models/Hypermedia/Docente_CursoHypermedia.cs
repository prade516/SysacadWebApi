using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Hal;

namespace WebApi.Models.Hypermedia
{
	public class Docente_CursoHypermedia : BaseHypermedia
	{
		private static Docente_CursoHypermedia _mytemplate;
		private Docente_CursoHypermedia() { }
		public static Docente_CursoHypermedia GetInstance()
		{
			if (_mytemplate == null)
				_mytemplate = new Docente_CursoHypermedia();
			return _mytemplate;
		}
		public override Link GetMyCollectionPagination()
		{
			return GetPagination.CreateLink();
		}

		public override Link GetMyCollectionReference()
		{
			return GetDocente_Cursos.CreateLink();
		}

		public override Link GetMyDeleteLink(long ID)
		{
			return DeleteDocente_Curso.CreateLink(new { id = ID });
		}

		public override Link GetMyOwnReference(long ID)
		{
			return Docente_Curso.CreateLink(new { id = ID });
		}

		public override Link GetMyRelationReference()
		{
			return Docente_CursoRelation;
		}

		public override Link GetMyUpdateLink(long ID)
		{
			return UpdateDocente_Curso.CreateLink(new { id = ID });
		}

		public static Link GetDocente_Cursos { get { return new Link("ref", baseaddress + "/docente_Cursos"); } }
		public static Link Docente_Curso { get { return new Link("self", baseaddress + "/docente_Cursos/{id}"); } }
		public static Link Docente_CursoRelation { get { return new Link("docente_Cursos", baseaddress + "/docente_Cursos/{id}"); } }
		public static Link UpdateDocente_Curso { get { return new Link("update", baseaddress + "/docente_Cursos/{id}"); } }
		public static Link DeleteDocente_Curso { get { return new Link("delete", baseaddress + "/docente_Cursos/{id}"); } }
		public static Link GetPagination { get { return new Link("docente_Cursos", baseaddress + "/docente_Cursos/{?page}"); } }
	}
}