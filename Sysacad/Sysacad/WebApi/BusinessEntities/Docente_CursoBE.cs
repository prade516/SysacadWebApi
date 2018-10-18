using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
	public class Docente_CursoBE
	{
		private Int32 _id_dictado;
		private int _id_curso;
		private int _id_docente;
		private int _cargo;
		private int _estado;

		private List<PersonaBE> _persona;
		private List<CursoBE> _curso;

		public List<CursoBE> Curso
		{
			get { return _curso; }
			set { _curso = value; }
		}


		public List<PersonaBE> Persona
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
	}
	}
