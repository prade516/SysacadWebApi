using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Hal;

namespace WebApi.Models.Hypermedia
{
	public class PlanmateriaHypermedia : BaseHypermedia
	{
		private static PlanmateriaHypermedia _mytemplate;
		private PlanmateriaHypermedia() { }
		public static PlanmateriaHypermedia GetInstance()
		{
			if (_mytemplate == null)
				_mytemplate = new PlanmateriaHypermedia();
			return _mytemplate;
		}
		public override Link GetMyCollectionPagination()
		{
			return GetPagination.CreateLink();
		}

		public override Link GetMyCollectionReference()
		{
			return GetPlanmaterias.CreateLink();
		}

		public override Link GetMyDeleteLink(long ID)
		{
			return DeletePlanmateria.CreateLink(new { id = ID });
		}

		public override Link GetMyOwnReference(long ID)
		{
			return Planmateria.CreateLink(new { id = ID });
		}

		public override Link GetMyRelationReference()
		{
			return PlanmateriaRelation;
		}

		public override Link GetMyUpdateLink(long ID)
		{
			return UpdatePlanmateria.CreateLink(new { id = ID });
		}

		public static Link GetPlanmaterias { get { return new Link("ref", baseaddress + "/planmaterias"); } }
		public static Link Planmateria { get { return new Link("self", baseaddress + "/planmaterias/{id}"); } }
		public static Link PlanmateriaRelation { get { return new Link("planmaterias", baseaddress + "/planmaterias/{id}"); } }
		public static Link UpdatePlanmateria { get { return new Link("update", baseaddress + "/planmaterias/{id}"); } }
		public static Link DeletePlanmateria { get { return new Link("delete", baseaddress + "/planmaterias/{id}"); } }
		public static Link GetPagination { get { return new Link("planmaterias", baseaddress + "/planmaterias/{?page}"); } }
	}
}