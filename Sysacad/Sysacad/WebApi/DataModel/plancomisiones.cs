using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
	public class plancomisiones
	{
		private Int32 _id_plancomision;
		private Int32 _id_plan;
		private Int32 _id_comision;
		private Int32 _estado;

		private planes _plan;
		private comisiones _comision;

		[Key]
		public int id_plancomision { get => _id_plancomision; set => _id_plancomision = value; }
		public int id_plan { get => _id_plan; set => _id_plan = value; }
		public int id_comision { get => _id_comision; set => _id_comision = value; }
		public int estado { get => _estado; set => _estado = value; }

		[ForeignKey("id_plan")]
		public planes Plan { get => _plan; set => _plan = value; }
		[ForeignKey("id_comision")]
		public comisiones comision { get => _comision; set => _comision = value; }
	}
}
