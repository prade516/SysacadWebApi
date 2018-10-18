using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
	public class PlanBE
	{
		private Int32 _id_plan;
		private String _desc_plan;
		private Int32 _estado;

		private List<PlanEspecialidadBE> _planespecialidad;

		
		public int id_plan { get => _id_plan; set => _id_plan = value; }
		public string desc_plan { get => _desc_plan; set => _desc_plan = value; }
		public int estado { get => _estado; set => _estado = value; }
		public List<PlanEspecialidadBE> Planespecialidad { get => _planespecialidad; set => _planespecialidad = value; }
	}
}
