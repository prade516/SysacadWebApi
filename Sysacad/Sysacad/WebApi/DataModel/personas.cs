using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
	public class personas
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
		private List<usuarios> _usuarios;
		private planes _plan;

		[Key]
		public int id_persona { get => _id_persona; set => _id_persona = value; }
		public int id_plan { get => _id_plan; set => _id_plan = value; }
		public string nombre { get => _nombre; set => _nombre = value; }
		public string apellido { get => _apellido; set => _apellido = value; }
		public string direccion { get => _direccion; set => _direccion = value; }
		public string telefono { get => _telefono; set => _telefono = value; }
		public DateTime fecha_nac { get => _fecha_nac; set => _fecha_nac = value; }
		public int legajo { get => _legajo; set => _legajo = value; }
		public int tipo_persona { get => _tipo_persona; set => _tipo_persona = value; }
		public int estado { get => _estado; set => _estado = value; }
		public List<usuarios> Usuarios { get => _usuarios; set => _usuarios = value; }
		[ForeignKey(name: "id_plan")]
		public planes plan { get => _plan; set => _plan = value; }
	}
}
