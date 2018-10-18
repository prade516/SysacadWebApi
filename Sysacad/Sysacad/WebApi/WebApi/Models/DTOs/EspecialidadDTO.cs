using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models.Hypermedia;
using WebApi.Models.Representacion;

namespace WebApi.Models.DTOs
{
	public class EspecialidadDTO : BaseRepresentation
	{
		#region Constructor
		public EspecialidadDTO()
		{
			Rel = Mytemplate.GetMyRelationReference().Rel;
		}
		#endregion
		#region Members
		private Int32 _idespecilidad;
		private String _desc_especialidad;
		private Int32 _estado;
		#endregion
		#region Properties
		public int id_especialidad
		{
			get
			{
				return _idespecilidad;
			}

			set
			{
				_idespecilidad = value;
			}
		}

		public string desc_especialidad
		{
			get
			{
				return _desc_especialidad;
			}

			set
			{
				_desc_especialidad = value;
			}
		}

		public Int32 estado
		{
			get
			{
				return _estado;
			}

			set
			{
				_estado = value;
			}
		}
		#endregion
		#region Method Override
		public override BaseHypermedia Mytemplate
		{
			get
			{
				if (_mytemplate == null)
					_mytemplate = EspecialidadHypermedia.GetInstance();
				return _mytemplate;
			}

			set
			{
				_mytemplate = value;
			}
		}


		public override long IDRepresentation()
		{
			return id_especialidad;
		}
		public void GetMyEspecialidad()
		{			
			Href = EspecialidadHypermedia.GetEspecialidades.CreateLink(new { id = id_especialidad }).Href;
		}
		protected override void CreateHypermedia()
		{
			Href = EspecialidadHypermedia.Especialidad.CreateLink(new { id = id_especialidad }).Href;
		}
		#endregion

	}
}