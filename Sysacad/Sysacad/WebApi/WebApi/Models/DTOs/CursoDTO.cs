using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models.Hypermedia;
using WebApi.Models.Representacion;

namespace WebApi.Models.DTOs
{
	public class CursoDTO : BaseRepresentation
	{
		#region Constructor
		public CursoDTO()
		{
			Rel = Mytemplate.GetMyRelationReference().Rel;
		}
		#endregion

		private Int32 _id_curso;
		private Int32 _id_materia;
		private Int32 _id_comision;
		private Int32 _anio_calendario;
		private Int32 _cupo;
		private Int32 _estado;

		private MateriaDTO _materia;
		private ComisionDTO _comision;
		private List<Docente_CursoDTO> _docente_curso;


		public int id_curso { get => _id_curso; set => _id_curso = value; }
		public int id_materia { get => _id_materia; set => _id_materia = value; }
		public int id_comision { get => _id_comision; set => _id_comision = value; }
		public int anio_calendario { get => _anio_calendario; set => _anio_calendario = value; }
		public int cupo { get => _cupo; set => _cupo = value; }
		public int estado { get => _estado; set => _estado = value; }

		public MateriaDTO materia { get => _materia; set => _materia = value; }
		public ComisionDTO comision { get => _comision; set => _comision = value; }
		public List<Docente_CursoDTO> Docente_curso { get => _docente_curso; set => _docente_curso = value; }

		#region Method Override
		public override BaseHypermedia Mytemplate
		{
			get
			{
				if (_mytemplate == null)
					_mytemplate = CursoHypermedia.GetInstance();
				return _mytemplate;
			}

			set
			{
				_mytemplate = value;
			}
		}	

		public override long IDRepresentation()
		{
			return _id_curso;
		}
		public void GetMyCurso()
		{
			Href = CursoHypermedia.GetCursos.CreateLink(new { id = _id_curso }).Href;
		}
		protected override void CreateHypermedia()
		{
			Href = CursoHypermedia.Curso.CreateLink(new { id = _id_curso }).Href;
		}
		public void MyPlanEspecialidadRelations()
		{
			Links.Add(CursoHypermedia.GetMyDocente_Cursos.CreateLink(new { id = id_curso }));
		}
		#endregion
	}
}