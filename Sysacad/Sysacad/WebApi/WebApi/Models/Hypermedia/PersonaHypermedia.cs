using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Hal;

namespace WebApi.Models.Hypermedia
{
	public class PersonaHypermedia : BaseHypermedia
	{
		private static PersonaHypermedia _mytemplate;
		private PersonaHypermedia() { }
		public static PersonaHypermedia GetInstance()
		{
			if (_mytemplate == null)
				_mytemplate = new PersonaHypermedia();
			return _mytemplate;
		}
		public override Link GetMyCollectionPagination()
		{
			return GetPagination.CreateLink();
		}

		public override Link GetMyCollectionReference()
		{
			return GetPersonas.CreateLink();
		}

		public override Link GetMyDeleteLink(long ID)
		{
			return DeletePersona.CreateLink(new { id = ID });
		}

		public override Link GetMyOwnReference(long ID)
		{
			return Persona.CreateLink(new { id = ID });
		}

		public override Link GetMyRelationReference()
		{
			return PersonaRelation;
		}

		public override Link GetMyUpdateLink(long ID)
		{
			return UpdatePersona.CreateLink(new { id = ID });
		}

		public static Link GetPersonas { get { return new Link("ref", baseaddress + "/personas"); } }
		public static Link Persona { get { return new Link("self", baseaddress + "/personas/{id}"); } }
		public static Link PersonaRelation { get { return new Link("personas", baseaddress + "/personas/{id}"); } }
		public static Link UpdatePersona { get { return new Link("update", baseaddress + "/personas/{id}"); } }
		public static Link DeletePersona { get { return new Link("delete", baseaddress + "/personas/{id}"); } }
		public static Link GetPagination { get { return new Link("personas", baseaddress + "/personas/{?page}"); } }

		public static Link GetUsuario { get { return new Link("usuarios", baseaddress + "/usuarios/{id}"); } }
		public static Link GetMyUsuario { get { return new Link("usuarios", baseaddress + "/personas/{id}" + "/usuarios/{id2}"); } }
		public static Link GetMyUsuarios { get { return new Link("usuarios", baseaddress + "/personas/{id}" + "/usuarios"); } }

	}
}