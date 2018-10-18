using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskTopSysacad.DTO
{
	public class PlanDTO : BaseSysacadDTO
	{
		private Int32 _idplan;
		private String _plan;
		private Int32 _estado;

		private List<EspecialidadDTO> _especialidad;
		private List<PlanEspecialidadDTO> _planespecialidad;

		public int id_plan { get => _idplan; set => _idplan = value; }
		public String desc_plan { get => _plan; set => _plan = value; }
		public int Estado { get => _estado; set => _estado = value; }
		public List<EspecialidadDTO> Especialidad { get => _especialidad; set => _especialidad = value; }
		public List<PlanEspecialidadDTO> Planespecialidad { get => _planespecialidad; set => _planespecialidad = value; }
	}
}
