using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
	public class modulos
	{
		private Int32 _id_modulo;
		private String _desc_modulo;
		private String _ejecuta;
		private Int32 _estado;
		private List<modulos_usuarios> _modulo_usuario;

		[Key]
		public int id_modulo { get => _id_modulo; set => _id_modulo = value; }
		public string desc_modulo { get => _desc_modulo; set => _desc_modulo = value; }
		public string ejecuta { get => _ejecuta; set => _ejecuta = value; }
		public int estado { get => _estado; set => _estado = value; }
		public List<modulos_usuarios> modulo_usuario { get => _modulo_usuario; set => _modulo_usuario = value; }
	}
}
