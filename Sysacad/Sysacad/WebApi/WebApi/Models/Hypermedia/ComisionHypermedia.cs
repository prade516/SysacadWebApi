using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Hal;

namespace WebApi.Models.Hypermedia
{
	public class ComisionHypermedia : BaseHypermedia
	{
		private static ComisionHypermedia _mytemplate;
		private ComisionHypermedia() { }
		public static ComisionHypermedia GetInstance()
		{
			if (_mytemplate == null)
				_mytemplate = new ComisionHypermedia();
			return _mytemplate;
		}
		public override Link GetMyCollectionPagination()
		{
			return GetPagination.CreateLink();
		}

		public override Link GetMyCollectionReference()
		{
			return GetComisiones.CreateLink();
		}

		public override Link GetMyDeleteLink(long ID)
		{
			return DeleteComision.CreateLink(new { id = ID });
		}

		public override Link GetMyOwnReference(long ID)
		{
			return Comision.CreateLink(new { id = ID });
		}

		public override Link GetMyRelationReference()
		{
			return ComisionRelation;
		}

		public override Link GetMyUpdateLink(long ID)
		{
			return UpdateComision.CreateLink(new { id = ID });
		}

		public static Link GetComisiones { get { return new Link("ref", baseaddress + "/comisiones"); } }
		public static Link Comision { get { return new Link("self", baseaddress + "/comisiones/{id}"); } }
		public static Link ComisionRelation { get { return new Link("comisiones", baseaddress + "/comisiones/{id}"); } }
		public static Link UpdateComision { get { return new Link("update", baseaddress + "/comisiones/{id}"); } }
		public static Link DeleteComision { get { return new Link("delete", baseaddress + "/comisiones/{id}"); } }
		public static Link GetPagination { get { return new Link("comisiones", baseaddress + "/comisiones/{?page}"); } }

		public static Link GetPlanComision { get { return new Link("plancomisiones", baseaddress + "/plancomisiones/{id}"); } }
		public static Link GetMyPlanComision { get { return new Link("plancomisiones", baseaddress + "/comisiones/{id}" + "/plancomisiones/{id2}"); } }
		public static Link GetMyPlanComisiones { get { return new Link("plancomisiones", baseaddress + "/comisiones/{id}" + "/plancomisiones"); } }
	}
}