using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
	public class CursoBE
	{
		private Int32 _id_curso;
		private Int32 _id_materia;
		private Int32 _id_comision;
		private Int32 _anio_calendario;
		private Int32 _cupo;
		private Int32 _estado;

		private MateriaBE _materia;
		private ComisionBE _comision;
		private List<Docente_CursoBE> _docente_curso;

		
		public int id_curso { get => _id_curso; set => _id_curso = value; }
		public int id_materia { get => _id_materia; set => _id_materia = value; }
		public int id_comision { get => _id_comision; set => _id_comision = value; }
		public int anio_calendario { get => _anio_calendario; set => _anio_calendario = value; }
		public int cupo { get => _cupo; set => _cupo = value; }
		public int estado { get => _estado; set => _estado = value; }
	
		public MateriaBE materia { get => _materia; set => _materia = value; }
		public ComisionBE comision { get => _comision; set => _comision = value; }
		public List<Docente_CursoBE> Docente_curso { get => _docente_curso; set => _docente_curso = value; }
	}
}
