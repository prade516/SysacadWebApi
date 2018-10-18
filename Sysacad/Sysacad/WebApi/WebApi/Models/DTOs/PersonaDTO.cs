using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models.Hypermedia;
using WebApi.Models.Representacion;

namespace WebApi.Models.DTOs
{
	public class PersonaDTO : BaseRepresentation
	{
		#region Constructor
		public PersonaDTO()
		{
			Rel = Mytemplate.GetMyRelationReference().Rel;
		}
		#endregion

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
		private List<UsuarioDTO> _usuarios;
		private PlanDTO _plan;


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
		public List<UsuarioDTO> Usuarios { get => _usuarios; set => _usuarios = value; }
		public PlanDTO plan { get => _plan; set => _plan = value; }

		#region Method Override
		public override BaseHypermedia Mytemplate
		{
			get
			{
				if (_mytemplate == null)
					_mytemplate = PersonaHypermedia.GetInstance();
				return _mytemplate;
			}

			set
			{
				_mytemplate = value;
			}
		}
		public override long IDRepresentation()
		{
			return id_persona;
		}
		public void MyUsuario()
		{
			Href = PersonaHypermedia.GetPersonas.CreateLink(new { id = id_persona }).Href;
		}
		protected override void CreateHypermedia()
		{
			Href = PersonaHypermedia.Persona.CreateLink(new { id = id_persona }).Href;
		}
		public void MyUsuarioRelations()
		{
			Links.Add(PersonaHypermedia.GetMyUsuarios.CreateLink(new { id = id_persona }));
		}
		#endregion
	}
}