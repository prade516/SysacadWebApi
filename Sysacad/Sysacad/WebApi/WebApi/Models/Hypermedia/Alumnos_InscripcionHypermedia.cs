using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Hal;

namespace WebApi.Models.Hypermedia
{
	public class Alumnos_InscripcionHypermedia : BaseHypermedia
	{
		private static Alumnos_InscripcionHypermedia _mytemplate;
		private Alumnos_InscripcionHypermedia() { }
		public static Alumnos_InscripcionHypermedia GetInstance()
		{
			if (_mytemplate == null)
				_mytemplate = new Alumnos_InscripcionHypermedia();
			return _mytemplate;
		}
		public override Link GetMyCollectionPagination()
		{
			return GetPagination.CreateLink();
		}

		public override Link GetMyCollectionReference()
		{
			return GetAlumno_Inscripciones.CreateLink();
		}

		public override Link GetMyDeleteLink(long ID)
		{
			return DeleteAlumno_Inscripcion.CreateLink(new { id = ID });
		}

		public override Link GetMyOwnReference(long ID)
		{
			return Alumno_Inscripcion.CreateLink(new { id = ID });
		}

		public override Link GetMyRelationReference()
		{
			return Alumno_InscripcionRelation;
		}

		public override Link GetMyUpdateLink(long ID)
		{
			return UpdateAlumno_Inscripcion.CreateLink(new { id = ID });
		}

		public static Link GetAlumno_Inscripciones { get { return new Link("ref", baseaddress + "/alumno_Inscripciones"); } }
		public static Link Alumno_Inscripcion { get { return new Link("self", baseaddress + "/alumno_Inscripciones/{id}"); } }
		public static Link Alumno_InscripcionRelation { get { return new Link("alumno_Inscripciones", baseaddress + "/alumno_Inscripciones/{id}"); } }
		public static Link UpdateAlumno_Inscripcion { get { return new Link("update", baseaddress + "/alumno_Inscripciones/{id}"); } }
		public static Link DeleteAlumno_Inscripcion { get { return new Link("delete", baseaddress + "/alumno_Inscripciones/{id}"); } }
		public static Link GetPagination { get { return new Link("alumno_Inscripciones", baseaddress + "/alumno_Inscripciones/{?page}"); } }

		public static Link GetUsuario { get { return new Link("usuarios", baseaddress + "/usuarios/{id}"); } }
		public static Link GetMyUsuario { get { return new Link("usuarios", baseaddress + "/alumno_Inscripciones/{id}" + "/usuarios/{id2}"); } }
		public static Link GetMyUsuarios { get { return new Link("usuarios", baseaddress + "/alumno_Inscripciones/{id}" + "/usuarios"); } }

		public static Link GetPersona { get { return new Link("personas", baseaddress + "/personas/{id}"); } }
		public static Link GetMyPersona { get { return new Link("personas", baseaddress + "/alumno_Inscripciones/{id}" + "/personas/{id2}"); } }
		public static Link GetMyPersonas { get { return new Link("personas", baseaddress + "/alumno_Inscripciones/{id}" + "/personas"); } }
	}
}