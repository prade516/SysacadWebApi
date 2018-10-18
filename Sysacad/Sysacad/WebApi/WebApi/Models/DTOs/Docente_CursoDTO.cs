using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models.Hypermedia;
using WebApi.Models.Representacion;

namespace WebApi.Models.DTOs
{
	public class Docente_CursoDTO : BaseRepresentation
	{
		#region Constructor
		public Docente_CursoDTO()
		{
			Rel = Mytemplate.GetMyRelationReference().Rel;
		}
		#endregion

		private Int32 _id_dictado;
		private int _id_curso;
		private int _id_docente;
		private int _cargo;
		private int _estado;

		private List<PersonaDTO> _persona;
		private List<CursoDTO> _curso;

		public List<CursoDTO> Curso
		{
			get { return _curso; }
			set { _curso = value; }
		}


		public List<PersonaDTO> Persona
		{
			get { return _persona; }
			set { _persona = value; }
		}


		public int estado
		{
			get { return _estado; }
			set { _estado = value; }
		}


		public int cargo
		{
			get { return _cargo; }
			set { _cargo = value; }
		}


		public int id_docente
		{
			get { return _id_docente; }
			set { _id_docente = value; }
		}


		public int id_cursos
		{
			get { return _id_curso; }
			set { _id_curso = value; }
		}

		public int id_dictado
		{
			get { return _id_dictado; }
			set { _id_dictado = value; }

		}
		#region Method Override
		public override BaseHypermedia Mytemplate
		{
			get
			{
				if (_mytemplate == null)
					_mytemplate = Docente_CursoHypermedia.GetInstance();
				return _mytemplate;
			}

			set
			{
				_mytemplate = value;
			}
		}
		public override long IDRepresentation()
		{
			return id_dictado;
		}
		public void GetMyCurso()
		{
			Href = Docente_CursoHypermedia.GetDocente_Cursos.CreateLink(new { id = id_dictado }).Href;
		}
		protected override void CreateHypermedia()
		{
			Href = Docente_CursoHypermedia.Docente_Curso.CreateLink(new { id = id_dictado }).Href;
		}
		#endregion
	}
}