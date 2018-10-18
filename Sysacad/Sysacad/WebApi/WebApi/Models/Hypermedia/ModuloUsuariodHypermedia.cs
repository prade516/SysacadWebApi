using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Hal;

namespace WebApi.Models.Hypermedia
{
	public class ModuloUsuariodHypermedia : BaseHypermedia
	{
		private static ModuloUsuariodHypermedia _mytemplate;
		private ModuloUsuariodHypermedia() { }
		public static ModuloUsuariodHypermedia GetInstance()
		{
			if (_mytemplate == null)
				_mytemplate = new ModuloUsuariodHypermedia();
			return _mytemplate;
		}
		public override Link GetMyCollectionPagination()
		{
			return GetPagination.CreateLink();
		}

		public override Link GetMyCollectionReference()
		{
			return GetModuloUsuarios.CreateLink();
		}

		public override Link GetMyDeleteLink(long ID)
		{
			return DeleteModuloUsuario.CreateLink(new { id = ID });
		}

		public override Link GetMyOwnReference(long ID)
		{
			return ModuloUsuario.CreateLink(new { id = ID });
		}

		public override Link GetMyRelationReference()
		{
			return ModuloUsuarioRelation;
		}

		public override Link GetMyUpdateLink(long ID)
		{
			return UpdateModuloUsuario.CreateLink(new { id = ID });
		}

		public static Link GetModuloUsuarios { get { return new Link("ref", baseaddress + "/modulousuarios"); } }
		public static Link ModuloUsuario { get { return new Link("self", baseaddress + "/modulousuarios/{id}"); } }
		public static Link ModuloUsuarioRelation { get { return new Link("modulousuarios", baseaddress + "/modulousuarios/{id}"); } }
		public static Link UpdateModuloUsuario { get { return new Link("update", baseaddress + "/modulousuarios/{id}"); } }
		public static Link DeleteModuloUsuario { get { return new Link("delete", baseaddress + "/modulousuarios/{id}"); } }
		public static Link GetPagination { get { return new Link("modulousuarios", baseaddress + "/modulousuarios/{?page}"); } }	

	}
}