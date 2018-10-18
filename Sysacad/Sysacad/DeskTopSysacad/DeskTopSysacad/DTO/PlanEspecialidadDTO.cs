using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskTopSysacad.DTO
{
	public class PlanEspecialidadDTO : BaseSysacadDTO
	{
		private Int32 _idplanespecialidad;
		private Int32 _idplan;
		private Int32 _idespecialidad;
		private Int32 _estado;


		private PlanDTO _plan;
		private EspecialidadDTO _especialidad;

		public int idplanespecialidad { get => _idplanespecialidad; set => _idplanespecialidad = value; }
		public int idplan { get => _idplan; set => _idplan = value; }
		public int idespecialidad { get => _idespecialidad; set => _idespecialidad = value; }

		public PlanDTO plan { get => _plan; set => _plan = value; }
		public EspecialidadDTO especialidad { get => _especialidad; set => _especialidad = value; }
		public int estado { get => _estado; set => _estado = value; }
	}
}
