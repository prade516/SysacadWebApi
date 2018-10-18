using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
	public class Alumnos_InscripcionBE
	{
		private Int32 _id_curso;
		private Int32 _id_alumno;
		private Int32 _id_inscripcion;
		private Int32 _nota;
		private Int32 _estado;
		private String _condicion;

		private CursoBE _curso;
		private PersonaBE _persona;
	
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
		
		public PersonaBE persona
		{
			get { return _persona; }
			set { _persona = value; }
		}
	
		public CursoBE curso
		{
			get { return _curso; }
			set { _curso = value; }
		}
	}
}
