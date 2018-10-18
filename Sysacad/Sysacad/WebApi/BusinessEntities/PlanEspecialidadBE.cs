using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
	public class PlanEspecialidadBE
	{
		private Int32 _idplanespecialidad;
		private Int32 _idplan;
		private Int32 _idespecialidad;
		private Int32 _estado;

		private PlanBE _plan;
		private EspecialidadBE _especialidad;

		
		public int idplanespecialidad { get => _idplanespecialidad; set => _idplanespecialidad = value; }
		public int idplan { get => _idplan; set => _idplan = value; }
		public int idespecialidad { get => _idespecialidad; set => _idespecialidad = value; }
		public int estado { get => _estado; set => _estado = value; }
		[ForeignKey(name: "id_plan")]
		public PlanBE Plan { get => _plan; set => _plan = value; }
		[ForeignKey(name: "idespecialidad")]
		public EspecialidadBE Especialidad { get => _especialidad; set => _especialidad = value; }
	}
}
