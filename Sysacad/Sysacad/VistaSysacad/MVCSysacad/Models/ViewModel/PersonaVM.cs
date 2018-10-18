using MVCSysacad.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCSysacad.Models.ViewModel
{
	public class PersonaVM:BaseSysacadVM
	{
		private Int32 _id_persona;
		private Int32 _id_plan;
		private String _nombre;
		private String _apellido;
		private String _direccion;
		private String _telefono;
		private DateTime _fecha_nac;
		private Int32 _legajo;
		private Int32 _tipo_persona;
		private Int32 _estado;
		private List<UsuarioVM> _usuarios;
		private UsuarioVM _usuariossingle;
		private List<ModuloVM> _modulo;
		private List<PlanVM> _plan;
		private Role _role;


		[Display(Name = "Codigo")]
		public int id_persona { get => _id_persona; set => _id_persona = value; }
		[Display(Name = "Codigo Plan")]
		public int id_plan { get => _id_plan; set => _id_plan = value; }
		[Display(Name = "Nombre")]
		public string nombre { get => _nombre; set => _nombre = value; }
		[Display(Name = "Apellido")]
		public string apellido { get => _apellido; set => _apellido = value; }
		[Display(Name = "Direccion")]
		public string direccion { get => _direccion; set => _direccion = value; }
		[Display(Name = "Telefono")]
		public string telefono { get => _telefono; set => _telefono = value; }
		[Display(Name = "Fecha Nac")]
		public DateTime fecha_nac { get => _fecha_nac; set => _fecha_nac = value; }
		[Display(Name = "Legajo")]
		public int legajo { get => _legajo; set => _legajo = value; }
		[Display(Name = "Role")]
		public int tipo_persona { get => _tipo_persona; set => _tipo_persona = value; }
		[Display(Name = "Estado")]
		public int estado { get => _estado; set => _estado = value; }
		public List<UsuarioVM> Usuarios { get => _usuarios; set => _usuarios = value; }
		public List<PlanVM >plan { get => _plan; set => _plan = value; }
		public List<ModuloVM> modulo { get => _modulo; set => _modulo = value; }
		public Role role { get => _role; set => _role = value; }
		public UsuarioVM usuariossingle { get => _usuariossingle; set => _usuariossingle = value; }
	}
}