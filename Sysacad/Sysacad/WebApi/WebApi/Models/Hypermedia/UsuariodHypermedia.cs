using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Hal;

namespace WebApi.Models.Hypermedia
{
	public class UsuariodHypermedia : BaseHypermedia
	{
		private static UsuariodHypermedia _mytemplate;
		private UsuariodHypermedia() { }
		public static UsuariodHypermedia GetInstance()
		{
			if (_mytemplate == null)
				_mytemplate = new UsuariodHypermedia();
			return _mytemplate;
		}
		public override Link GetMyCollectionPagination()
		{
			return GetPagination.CreateLink();
		}

		public override Link GetMyCollectionReference()
		{
			return GetUsuarios.CreateLink();
		}

		public override Link GetMyDeleteLink(long ID)
		{
			return DeleteUsuario.CreateLink(new { id = ID });
		}

		public override Link GetMyOwnReference(long ID)
		{
			return Usuario.CreateLink(new { id = ID });
		}

		public override Link GetMyRelationReference()
		{
			return UsuarioRelation;
		}

		public override Link GetMyUpdateLink(long ID)
		{
			return UpdateUsuario.CreateLink(new { id = ID });
		}

		public static Link GetUsuarios { get { return new Link("ref", baseaddress + "/usuarios"); } }
		public static Link Usuario { get { return new Link("self", baseaddress + "/usuarios/{id}"); } }
		public static Link UsuarioRelation { get { return new Link("usuarios", baseaddress + "/usuarios/{id}"); } }
		public static Link UpdateUsuario { get { return new Link("update", baseaddress + "/usuarios/{id}"); } }
		public static Link DeleteUsuario { get { return new Link("delete", baseaddress + "/usuarios/{id}"); } }
		public static Link GetPagination { get { return new Link("usuarios", baseaddress + "/usuarios/{?page}"); } }

		public static Link GetModuloUsuario { get { return new Link("modulousuarios", baseaddress + "/modulousuarios/{id}"); } }
		public static Link GetMyModuloUsuario { get { return new Link("modulousuarios", baseaddress + "/usuarios/{id}" + "/modulousuarios/{id2}"); } }
		public static Link GetMyModuloUsuarios { get { return new Link("modulousuarios", baseaddress + "/usuarios/{id}" + "/modulousuarios"); } }

	}
}