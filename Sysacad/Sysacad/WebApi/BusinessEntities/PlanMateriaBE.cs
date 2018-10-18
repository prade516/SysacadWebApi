using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
	public class PlanMateriaBE
	{
		private Int32 _idplanmateria;
		private Int32 _idplan;
		private Int32 _idmateria;
		private Int32 _estado;

		private MateriaBE _materia;
		private PlanBE _plan;

		public int idplanmateria { get => _idplanmateria; set => _idplanmateria = value; }
		public int idplan { get => _idplan; set => _idplan = value; }
		public int idmateria { get => _idmateria; set => _idmateria = value; }
		public int estado { get => _estado; set => _estado = value; }
	
		public MateriaBE materia { get => _materia; set => _materia = value; }
		public PlanBE plan { get => _plan; set => _plan = value; }
	}
}
