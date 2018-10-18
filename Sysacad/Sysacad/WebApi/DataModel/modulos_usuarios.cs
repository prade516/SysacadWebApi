using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
	public class modulos_usuarios
	{
		private Int32 _id_modulo_usuario;
		private Int32 _id_modulo;
		private Int32 _id_usuario;
		private Boolean _alta;
		private Boolean _baja;
		private Boolean _modificacion;
		private Boolean _consulta;
		private Int32 _estado;

		private modulos _modulo;
		private usuarios _usuario;

		[Key]
		public int id_modulo_usuario { get => _id_modulo_usuario; set => _id_modulo_usuario = value; }
		public int id_modulo { get => _id_modulo; set => _id_modulo = value; }
		public int id_usuario { get => _id_usuario; set => _id_usuario = value; }
		public bool alta { get => _alta; set => _alta = value; }
		public bool baja { get => _baja; set => _baja = value; }
		public bool modificacion { get => _modificacion; set => _modificacion = value; }
		public bool consulta { get => _consulta; set => _consulta = value; }
		public int estado { get => _estado; set => _estado = value; }
		[ForeignKey(name: "id_modulo")]
		public modulos modulo { get => _modulo; set => _modulo = value; }
		[ForeignKey(name: "id_usuario")]
		public usuarios usuario { get => _usuario; set => _usuario = value; }
	}
}
