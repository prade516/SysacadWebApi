using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models.Hypermedia;
using WebApi.Models.Representacion;

namespace WebApi.Models.DTOs
{
	public class Modulos_UsuarioDTO : BaseRepresentation
	{
		#region Constructor
		public Modulos_UsuarioDTO()
		{
			Rel = Mytemplate.GetMyRelationReference().Rel;
		}
		#endregion

		private Int32 _id_modulo_usuario;
		private Int32 _id_modulo;
		private Int32 _id_usuario;
		private Boolean _alta;
		private Boolean _baja;
		private Boolean _modificacion;
		private Boolean _consulta;
		private Int32 _estado;

		private ModuloDTO _modulo;
		private UsuarioDTO _usuario;


		public int id_modulo_usuario { get => _id_modulo_usuario; set => _id_modulo_usuario = value; }
		public int id_modulo { get => _id_modulo; set => _id_modulo = value; }
		public int id_usuario { get => _id_usuario; set => _id_usuario = value; }
		public bool alta { get => _alta; set => _alta = value; }
		public bool baja { get => _baja; set => _baja = value; }
		public bool modificacion { get => _modificacion; set => _modificacion = value; }
		public bool consulta { get => _consulta; set => _consulta = value; }
		public int estado { get => _estado; set => _estado = value; }
		public ModuloDTO modulo { get => _modulo; set => _modulo = value; }
		public UsuarioDTO usuario { get => _usuario; set => _usuario = value; }

		public override BaseHypermedia Mytemplate
		{
			get
			{
				if (_mytemplate == null)
					_mytemplate = ModuloUsuariodHypermedia.GetInstance();
				return _mytemplate;
			}

			set
			{
				_mytemplate = value;
			}
		}

		public override long IDRepresentation()
		{
			return id_modulo_usuario;
		}
		public void GetMyModuloUsuario()
		{
			Href = ModuloUsuariodHypermedia.GetModuloUsuarios.CreateLink(new { id = id_modulo_usuario }).Href;
		}
		protected override void CreateHypermedia()
		{
			Href = ModuloUsuariodHypermedia.ModuloUsuario.CreateLink(new { id = id_modulo_usuario }).Href;
		}
	}
}