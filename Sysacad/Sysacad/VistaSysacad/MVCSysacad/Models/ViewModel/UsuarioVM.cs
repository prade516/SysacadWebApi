using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCSysacad.Models.ViewModel
{
	public class UsuarioVM:BaseSysacadVM
	{
		private Int32 _id_usuario;
		private String _nombre_usuario;
		private String _clave;
		private String _nuevaclave;
		private String _confirmarclave;
		private Boolean _habilitado;
		private String _email;
		private Boolean _cambia_clave;
		private Int32 _id_persona;
		private Int32 _estado;
		private PersonaVM _personas;
		private List<Modulos_UsuarioVM> _modulo_usuario;
		private Modulos_UsuarioVM _modulo_usuariosingle;

		[Display(Name = "Codigo Usuario")]
		public int id_usuario { get => _id_usuario; set => _id_usuario = value; }
		[Display(Name = "Usuario")]
		public string nombre_usuario { get => _nombre_usuario; set => _nombre_usuario = value; }
		[Display(Name = "Contraseña")]
		[DataType(DataType.Password)]
		public string clave { get => _clave; set => _clave = value; }
		[Display(Name = "Confirmar Contraseña")]
		[DataType(DataType.Password)]
		public string confirmarclave { get => _confirmarclave; set => _confirmarclave = value; }
		public bool habilitado { get => _habilitado; set => _habilitado = value; }
		[Display(Name = "Correo")]
		public string email { get => _email; set => _email = value; }
		public bool cambia_clave { get => _cambia_clave; set => _cambia_clave = value; }
		public int id_persona { get => _id_persona; set => _id_persona = value; }
		public int estado { get => _estado; set => _estado = value; }
		public PersonaVM personas { get => _personas; set => _personas = value; }
		public List<Modulos_UsuarioVM> modulo_usuario { get => _modulo_usuario; set => _modulo_usuario = value; }
		public Modulos_UsuarioVM modulo_usuariosingle { get => _modulo_usuariosingle; set => _modulo_usuariosingle = value; }
		[Display(Name = "Nueva Contraseña")]
		[DataType(DataType.Password)]
		public string nuevaclave { get => _nuevaclave; set => _nuevaclave = value; }
	}
}