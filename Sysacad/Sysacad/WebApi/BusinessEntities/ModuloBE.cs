using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
	public class ModuloBE
	{
		private Int32 _id_modulo;
		private String _desc_modulo;
		private String _ejecuta;
		private Int32 _estado;
		private List<Modulos_UsuarioBE> _modulo_usuario;

	
		public int id_modulo { get => _id_modulo; set => _id_modulo = value; }
		public string desc_modulo { get => _desc_modulo; set => _desc_modulo = value; }
		public string ejecuta { get => _ejecuta; set => _ejecuta = value; }
		public int estado { get => _estado; set => _estado = value; }
		public List<Modulos_UsuarioBE> modulo_usuario { get => _modulo_usuario; set => _modulo_usuario = value; }
	}
}
