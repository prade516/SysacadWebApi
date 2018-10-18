using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCSysacad.Models.ViewModel
{
	public class Modulos_UsuarioVM
	{
		private Int32 _id_modulo_usuario;
		private Int32 _id_modulo;
		private Int32 _id_usuario;
		private Boolean _alta;
		private Boolean _baja;
		private Boolean _modificacion;
		private Boolean _consulta;
		private Int32 _estado;

		private ModuloVM _modulo;
		private UsuarioVM _usuario;

		[Display(Name = "Codigo Modulo Usuario")]
		public int id_modulo_usuario { get => _id_modulo_usuario; set => _id_modulo_usuario = value; }
		[Display(Name = "Codigo Modulo")]
		public int id_modulo { get => _id_modulo; set => _id_modulo = value; }
		[Display(Name = "Codigo Usuario")]
		public int id_usuario { get => _id_usuario; set => _id_usuario = value; }
		[Display(Name = "Alta")]
		public bool alta { get => _alta; set => _alta = value; }
		[Display(Name = "Baja")]
		public bool baja { get => _baja; set => _baja = value; }
		[Display(Name = "Modificar")]
		public bool modificacion { get => _modificacion; set => _modificacion = value; }
		[Display(Name = "Consulta")]
		public bool consulta { get => _consulta; set => _consulta = value; }
		public int estado { get => _estado; set => _estado = value; }
		public ModuloVM modulo { get => _modulo; set => _modulo = value; }
		public UsuarioVM usuario { get => _usuario; set => _usuario = value; }
	}
}