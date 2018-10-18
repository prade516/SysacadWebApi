using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
	public class ComisionBE
	{
		private Int32 _idcomision;
		private String _desc_comision;
		private Int32 _anio_especialidad;
		private Int32 _estado;
		private List<PlanComisionBE> _plancomision;

		public int idcomision { get => _idcomision; set => _idcomision = value; }
		public string desc_comision { get => _desc_comision; set => _desc_comision = value; }
		public int anio_especialidad { get => _anio_especialidad; set => _anio_especialidad = value; }
		public int estado { get => _estado; set => _estado = value; }
		public List<PlanComisionBE> Plancomision { get => _plancomision; set => _plancomision = value; }
	}
}
