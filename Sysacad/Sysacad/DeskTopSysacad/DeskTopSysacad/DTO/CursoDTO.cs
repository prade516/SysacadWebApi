using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskTopSysacad.DTO
{
	public class CursoDTO : BaseSysacadDTO
	{
		private Int32 _id_curso;
		private Int32 _id_materia;
		private Int32 _id_comision;
		private Int32 _anio_calendario;
		private Int32 _cupo;
		private String _accion;
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
		public string accion { get => _accion; set => _accion = value; }
	}
}
