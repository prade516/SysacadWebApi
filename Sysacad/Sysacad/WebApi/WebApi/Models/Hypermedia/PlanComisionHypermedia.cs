using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Hal;

namespace WebApi.Models.Hypermedia
{
	public class PlanComisionHypermedia : BaseHypermedia
	{
		private static PlanComisionHypermedia _mytemplate;
		private PlanComisionHypermedia() { }
		public static PlanComisionHypermedia GetInstance()
		{
			if (_mytemplate == null)
				_mytemplate = new PlanComisionHypermedia();
			return _mytemplate;
		}
		public override Link GetMyCollectionPagination()
		{
			return GetPagination.CreateLink();
		}

		public override Link GetMyCollectionReference()
		{
			return GetPlanComisiones.CreateLink();
		}

		public override Link GetMyDeleteLink(long ID)
		{
			return DeletePlanComision.CreateLink(new { id = ID });
		}

		public override Link GetMyOwnReference(long ID)
		{
			return PlanComision.CreateLink(new { id = ID });
		}

		public override Link GetMyRelationReference()
		{
			return PlanComisionRelation;
		}

		public override Link GetMyUpdateLink(long ID)
		{
			return UpdatePlanComision.CreateLink(new { id = ID });
		}

		public static Link GetPlanComisiones { get { return new Link("ref", baseaddress + "/plancomisiones"); } }
		public static Link PlanComision { get { return new Link("self", baseaddress + "/plancomisiones/{id}"); } }
		public static Link PlanComisionRelation { get { return new Link("plancomisiones", baseaddress + "/plancomisiones/{id}"); } }
		public static Link UpdatePlanComision { get { return new Link("update", baseaddress + "/plancomisiones/{id}"); } }
		public static Link DeletePlanComision { get { return new Link("delete", baseaddress + "/plancomisiones/{id}"); } }
		public static Link GetPagination { get { return new Link("plancomisiones", baseaddress + "/plancomisiones/{?page}"); } }
	}
}