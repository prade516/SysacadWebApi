using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Hal;

namespace WebApi.Models.Hypermedia
{
	public abstract class BaseHypermedia
	{
		public abstract Link GetMyOwnReference(long ID);
		public abstract Link GetMyRelationReference();
		public abstract Link GetMyCollectionReference();
		public abstract Link GetMyCollectionPagination();

		public abstract Link GetMyUpdateLink(long ID);
		public abstract Link GetMyDeleteLink(long ID);


		public static readonly string baseaddress = "/api";
	}
}