using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskTopSysacad.DTO
{
	public class MateriaDTO : BaseSysacadDTO
	{
		private Int32 _id_materia;
		private String _desc_materia;
		private Int32 _hs_semanales;
		private Int32 _hs_totales;
		private Int32 _estado;

		private List<PlanMateriaDTO> _planmateria;

		public int id_materia { get => _id_materia; set => _id_materia = value; }
		public string desc_materia { get => _desc_materia; set => _desc_materia = value; }
		public int hs_semanales { get => _hs_semanales; set => _hs_semanales = value; }
		public int hs_totales { get => _hs_totales; set => _hs_totales = value; }
		public int estado { get => _estado; set => _estado = value; }
		public List<PlanMateriaDTO> Planmateria { get => _planmateria; set => _planmateria = value; }
	}
}
