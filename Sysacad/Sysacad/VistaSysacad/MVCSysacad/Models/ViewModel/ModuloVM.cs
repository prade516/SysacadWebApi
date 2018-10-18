using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCSysacad.Models.ViewModel
{
	public class ModuloVM:BaseSysacadVM
	{
		private Int32 _id_modulo;
		private String _desc_modulo;
		private String _ejecuta;
		private Int32 _estado;
		//private List<Modulos_UsuarioDTO> _modulo_usuario;

		[Display(Name = "Codigo")]
		public int id_modulo { get => _id_modulo; set => _id_modulo = value; }
		[Display(Name = "Descripcion")]
		[Required]
		public string desc_modulo { get => _desc_modulo; set => _desc_modulo = value; }
		[Display(Name = "Ejecuta")]
		[Required]
		public string ejecuta { get => _ejecuta; set => _ejecuta = value; }
		public int estado { get => _estado; set => _estado = value; }
		//public List<Modulos_UsuarioDTO> modulo_usuario { get => _modulo_usuario; set => _modulo_usuario = value; }
	}
}