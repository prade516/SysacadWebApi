using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Hal;

namespace WebApi.Models.Hypermedia
{
	public class PlanHypermedia : BaseHypermedia
	{
		private static PlanHypermedia _mytemplate;
		private PlanHypermedia() { }
		public static PlanHypermedia GetInstance()
		{
			if (_mytemplate == null)
				_mytemplate = new PlanHypermedia();
			return _mytemplate;
		}
		public override Link GetMyCollectionPagination()
		{
			return GetPagination.CreateLink();
		}

		public override Link GetMyCollectionReference()
		{
			return GetPlanes.CreateLink();
		}

		public override Link GetMyDeleteLink(long ID)
		{
			return DeletePlan.CreateLink(new { id = ID });
		}

		public override Link GetMyOwnReference(long ID)
		{
			return Plan.CreateLink(new { id = ID });
		}

		public override Link GetMyRelationReference()
		{
			return PlanRelation;
		}

		public override Link GetMyUpdateLink(long ID)
		{
			return UpdatePlan.CreateLink(new { id = ID });
		}

		public static Link GetPlanes { get { return new Link("ref", baseaddress + "/planes"); } }
		public static Link Plan { get { return new Link("self", baseaddress + "/planes/{id}"); } }
		public static Link PlanRelation { get { return new Link("planes", baseaddress + "/planes/{id}"); } }
		public static Link UpdatePlan { get { return new Link("update", baseaddress + "/planes/{id}"); } }
		public static Link DeletePlan { get { return new Link("delete", baseaddress + "/planes/{id}"); } }
		public static Link GetPagination { get { return new Link("planes", baseaddress + "/planes/{?page}"); } }

		public static Link GetPlanEspecialidad { get { return new Link("planespecialidades", baseaddress + "/planespecialidades/{id}"); } }
		public static Link GetMyPlanEspecialidad { get { return new Link("planespecialidades", baseaddress + "/planes/{id}" + "/planespecialidades/{id2}"); } }
		public static Link GetMyPlanEspecialidades { get { return new Link("planespecialidades", baseaddress + "/planes/{id}" + "/planespecialidades"); } }
	}
}