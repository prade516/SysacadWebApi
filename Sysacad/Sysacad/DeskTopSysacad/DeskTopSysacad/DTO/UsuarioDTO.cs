﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskTopSysacad.DTO
{
	public class UsuarioDTO:BaseSysacadDTO
	{
		private Int32 _id_usuario;
		private String _nombre_usuario;
		private String _clave;
		private Boolean _habilitado;
		private String _email;
		private Boolean _cambia_clave;
		private Int32 _id_persona;
		private Int32 _estado;
		private PersonaDTO _personas;
		private List<Modulos_UsuarioDTO> _modulo_usuario;


		public int id_usuario { get => _id_usuario; set => _id_usuario = value; }
		public string nombre_usuario { get => _nombre_usuario; set => _nombre_usuario = value; }
		public string clave { get => _clave; set => _clave = value; }
		public bool habilitado { get => _habilitado; set => _habilitado = value; }
		public string email { get => _email; set => _email = value; }
		public bool cambia_clave { get => _cambia_clave; set => _cambia_clave = value; }
		public int id_persona { get => _id_persona; set => _id_persona = value; }
		public int estado { get => _estado; set => _estado = value; }
		public PersonaDTO personas { get => _personas; set => _personas = value; }
		public List<Modulos_UsuarioDTO> modulo_usuario { get => _modulo_usuario; set => _modulo_usuario = value; }
	}
}
