using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models.Hypermedia;
using WebApi.Models.Representacion;

namespace WebApi.Models.DTOs
{
	public class Alumnos_InscripcionDTO : BaseRepresentation
	{
		#region Constructor
		public Alumnos_InscripcionDTO()
		{
			Rel = Mytemplate.GetMyRelationReference().Rel;
		}
		#endregion

		private Int32 _id_curso;
		private Int32 _id_alumno;
		private Int32 _id_inscripcion;
		private Int32 _nota;
		private Int32 _estado;
		private String _condicion;

		private CursoDTO _curso;
		private PersonaDTO _persona;

		public Int32 id_inscripcion
		{
			get { return _id_inscripcion; }
			set { _id_inscripcion = value; }
		}


		public Int32 id_alumno
		{
			get { return _id_alumno; }
			set { _id_alumno = value; }
		}


		public Int32 id_curso
		{
			get { return _id_curso; }
			set { _id_curso = value; }
		}

		public String condicion
		{
			get { return _condicion; }
			set { _condicion = value; }
		}

		public int nota
		{
			get { return _nota; }
			set { _nota = value; }
		}

		public Int32 estado
		{
			get { return _estado; }
			set { _estado = value; }
		}

		public PersonaDTO persona
		{
			get { return _persona; }
			set { _persona = value; }
		}

		public CursoDTO curso
		{
			get { return _curso; }
			set { _curso = value; }
		}

		#region Method Override
		public override BaseHypermedia Mytemplate
		{
			get
			{
				if (_mytemplate == null)
					_mytemplate = MateriaHypermedia.GetInstance();
				return _mytemplate;
			}

			set
			{
				_mytemplate = value;
			}
		}
		public override long IDRepresentation()
		{
			return id_alumno;
		}
		public void GetMyEspecialidad()
		{
			Href = Alumnos_InscripcionHypermedia.GetAlumno_Inscripciones.CreateLink(new { id = id_alumno }).Href;
		}
		protected override void CreateHypermedia()
		{
			Href = Alumnos_InscripcionHypermedia.Alumno_Inscripcion.CreateLink(new { id = id_alumno }).Href;
		}
		public void MyUsuariosRelations()
		{
			Links.Add(Alumnos_InscripcionHypermedia.GetMyUsuarios.CreateLink(new { id = id_alumno }));
		}
		public void MyPersonaRelations()
		{
			Links.Add(Alumnos_InscripcionHypermedia.GetMyPersonas.CreateLink(new { id = id_alumno }));
		}
		#endregion
	}
}