using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models.Hypermedia;
using WebApi.Models.Representacion;

namespace WebApi.Models.DTOs
{
	public class ModuloDTO : BaseRepresentation
	{
		#region Constructor
		public ModuloDTO()
		{
			Rel = Mytemplate.GetMyRelationReference().Rel;
		}
		#endregion
		public override BaseHypermedia Mytemplate
		{
			get
			{
				if (_mytemplate == null)
					_mytemplate = ModuloHypermedia.GetInstance();
				return _mytemplate;
			}

			set
			{
				_mytemplate = value;
			}
		}
		private Int32 _id_modulo;
		private String _desc_modulo;
		private String _ejecuta;
		private Int32 _estado;
		//private List<Modulos_UsuarioDTO> _modulo_usuario;


		public int id_modulo { get => _id_modulo; set => _id_modulo = value; }
		public string desc_modulo { get => _desc_modulo; set => _desc_modulo = value; }
		public string ejecuta { get => _ejecuta; set => _ejecuta = value; }
		public int estado { get => _estado; set => _estado = value; }
		//public List<Modulos_UsuarioDTO> modulo_usuario { get => _modulo_usuario; set => _modulo_usuario = value; }
				
		public override long IDRepresentation()
		{
			return id_modulo;
		}
		public void GetMyModulo()
		{
			Href = ModuloHypermedia.GetModulos.CreateLink(new { id = id_modulo }).Href;
		}
		protected override void CreateHypermedia()
		{
			Href = ModuloHypermedia.Modulo.CreateLink(new { id = id_modulo }).Href;
		}		
	}
}