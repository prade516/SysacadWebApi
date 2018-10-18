using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
	public class PlanComisionBE
	{
		private Int32 _idplancomision;
		private Int32 _idplan;
		private Int32 _idcomision;
		private Int32 _estado;

		private PlanBE _plan;
		private ComisionBE _comision;

		public int idplancomision { get => _idplancomision; set => _idplancomision = value; }
		public int idplan { get => _idplan; set => _idplan = value; }
		public int idcomision { get => _idcomision; set => _idcomision = value; }
		public int estado { get => _estado; set => _estado = value; }
		public PlanBE Plan { get => _plan; set => _plan = value; }
		public ComisionBE comision { get => _comision; set => _comision = value; }
	}
}
