using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Hal;

namespace WebApi.Models.Hypermedia
{
	public class ModuloHypermedia : BaseHypermedia
	{
		private static ModuloHypermedia _mytemplate;
		private ModuloHypermedia() { }
		public static ModuloHypermedia GetInstance()
		{
			if (_mytemplate == null)
				_mytemplate = new ModuloHypermedia();
			return _mytemplate;
		}
		public override Link GetMyCollectionPagination()
		{
			return GetPagination.CreateLink();
		}

		public override Link GetMyCollectionReference()
		{
			return GetModulos.CreateLink();
		}

		public override Link GetMyDeleteLink(long ID)
		{
			return DeleteModulo.CreateLink(new { id = ID });
		}

		public override Link GetMyOwnReference(long ID)
		{
			return Modulo.CreateLink(new { id = ID });
		}

		public override Link GetMyRelationReference()
		{
			return ModuloRelation;
		}

		public override Link GetMyUpdateLink(long ID)
		{
			return UpdateModulo.CreateLink(new { id = ID });
		}

		public static Link GetModulos { get { return new Link("ref", baseaddress + "/modulos"); } }
		public static Link Modulo { get { return new Link("self", baseaddress + "/modulos/{id}"); } }
		public static Link ModuloRelation { get { return new Link("modulos", baseaddress + "/modulos/{id}"); } }
		public static Link UpdateModulo { get { return new Link("update", baseaddress + "/modulos/{id}"); } }
		public static Link DeleteModulo { get { return new Link("delete", baseaddress + "/modulos/{id}"); } }
		public static Link GetPagination { get { return new Link("modulos", baseaddress + "/modulos/{?page}"); } }
	}
}