using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
	public class comisiones
	{
		private Int32 _id_comision;
		private String _desc_comision;
		private Int32 _anio_especialidad;
		private Int32 _estado;
		private List<plancomisiones> _plancomision;

		[Key]
		public int id_comision { get => _id_comision; set => _id_comision = value; }
		public string desc_comision { get => _desc_comision; set => _desc_comision = value; }
		public int anio_especialidad { get => _anio_especialidad; set => _anio_especialidad = value; }
		public int estado { get => _estado; set => _estado = value; }
		public List<plancomisiones> Plancomision { get => _plancomision; set => _plancomision = value; }
	}
}
