using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Hal;

namespace WebApi.Models.Hypermedia
{
	public class EspecialidadHypermedia : BaseHypermedia
	{
		private static EspecialidadHypermedia _mytemplate;
		private EspecialidadHypermedia() { }
		public static EspecialidadHypermedia GetInstance()
		{
			if (_mytemplate == null)
				_mytemplate = new EspecialidadHypermedia();
			return _mytemplate;
		}
		public override Link GetMyCollectionPagination()
		{
			return GetPagination.CreateLink();
		}

		public override Link GetMyCollectionReference()
		{
			return GetEspecialidades.CreateLink();
		}

		public override Link GetMyDeleteLink(long ID)
		{
			return DeleteEspecialidad.CreateLink(new { id = ID });
		}

		public override Link GetMyOwnReference(long ID)
		{
			return Especialidad.CreateLink(new { id = ID });
		}

		public override Link GetMyRelationReference()
		{
			return EspecialidadRelation;
		}

		public override Link GetMyUpdateLink(long ID)
		{
			return UpdateEspecialidad.CreateLink(new { id = ID });
		}

		public static Link GetEspecialidades { get { return new Link("ref", baseaddress + "/especialidades"); } }
		public static Link Especialidad { get { return new Link("self", baseaddress + "/especialidades/{id}"); } }
		public static Link EspecialidadRelation { get { return new Link("especialidades", baseaddress + "/especialidades/{id}"); } }
		public static Link UpdateEspecialidad { get { return new Link("update", baseaddress + "/especialidades/{id}"); } }
		public static Link DeleteEspecialidad { get { return new Link("delete", baseaddress + "/especialidades/{id}"); } }
		public static Link GetPagination { get { return new Link("especialidades", baseaddress + "/especialidades/{?page}"); } }
	}
}