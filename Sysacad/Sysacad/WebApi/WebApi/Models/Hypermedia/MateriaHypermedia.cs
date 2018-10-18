using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Hal;

namespace WebApi.Models.Hypermedia
{
	public class MateriaHypermedia : BaseHypermedia
	{
		private static MateriaHypermedia _mytemplate;
		private MateriaHypermedia() { }
		public static MateriaHypermedia GetInstance()
		{
			if (_mytemplate == null)
				_mytemplate = new MateriaHypermedia();
			return _mytemplate;
		}
		public override Link GetMyCollectionPagination()
		{
			return GetPagination.CreateLink();
		}

		public override Link GetMyCollectionReference()
		{
			return GetMaterias.CreateLink();
		}

		public override Link GetMyDeleteLink(long ID)
		{
			return DeleteMateria.CreateLink(new { id = ID });
		}

		public override Link GetMyOwnReference(long ID)
		{
			return Materia.CreateLink(new { id = ID });
		}

		public override Link GetMyRelationReference()
		{
			return MateriaRelation;
		}

		public override Link GetMyUpdateLink(long ID)
		{
			return UpdateMateria.CreateLink(new { id = ID });
		}

		public static Link GetMaterias { get { return new Link("ref", baseaddress + "/materias"); } }
		public static Link Materia { get { return new Link("self", baseaddress + "/materias/{id}"); } }
		public static Link MateriaRelation { get { return new Link("materias", baseaddress + "/materias/{id}"); } }
		public static Link UpdateMateria { get { return new Link("update", baseaddress + "/materias/{id}"); } }
		public static Link DeleteMateria { get { return new Link("delete", baseaddress + "/materias/{id}"); } }
		public static Link GetPagination { get { return new Link("materias", baseaddress + "/materias/{?page}"); } }

		public static Link GetPlanMateria { get { return new Link("planmaterias", baseaddress + "/planmaterias/{id}"); } }
		public static Link GetMyPlanMateria { get { return new Link("planmaterias", baseaddress + "/materias/{id}" + "/planmaterias/{id2}"); } }
		public static Link GetMyPlanMaterias { get { return new Link("planmaterias", baseaddress + "/materias/{id}" + "/planmaterias"); } }
	}
}