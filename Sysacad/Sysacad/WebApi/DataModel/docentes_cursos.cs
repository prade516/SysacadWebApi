using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
	public class docentes_cursos
	{
		private Int32 _id_dictado;
		private int _id_curso;
		private int _id_docente;
		private int _cargo;
		private int _estado;

		private personas _persona;
		private cursos _curso;

		[ForeignKey("id_curso")]
		public cursos Curso
		{
			get { return _curso; }
			set { _curso = value; }
		}

		[ForeignKey("id_docente")]
		public personas Persona
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


		public int id_curso
		{
			get { return _id_curso; }
			set { _id_curso = value; }
		}
		[Key]
		public int id_dictado
		{
			get { return _id_dictado; }
			set { _id_dictado = value; }
		}

	}
}
