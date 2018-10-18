using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
	public class PersonaBE
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
		private List<UsuarioBE> _usuarios;
		private PlanBE _plan;

		
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
		public List<UsuarioBE> Usuarios { get => _usuarios; set => _usuarios = value; }
		public PlanBE plan { get => _plan; set => _plan = value; }
	}
}
