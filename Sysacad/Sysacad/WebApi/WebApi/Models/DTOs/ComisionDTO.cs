using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models.Hypermedia;
using WebApi.Models.Representacion;

namespace WebApi.Models.DTOs
{
	public class ComisionDTO : BaseRepresentation
	{
		#region Constructor
		public ComisionDTO()
		{
			Rel = Mytemplate.GetMyRelationReference().Rel;
		}
		#endregion
		private Int32 _idcomision;
		private String _desc_comision;
		private Int32 _anio_especialidad;
		private Int32 _estado;
		private List<PlanComisionDTO> _plancomision;

		public int id_comision { get => _idcomision; set => _idcomision = value; }
		public string desc_comision { get => _desc_comision; set => _desc_comision = value; }
		public int anio_especialidad { get => _anio_especialidad; set => _anio_especialidad = value; }
		public int estado { get => _estado; set => _estado = value; }
		public List<PlanComisionDTO> Plancomision { get => _plancomision; set => _plancomision = value; }

		#region Method Override
		public override BaseHypermedia Mytemplate
		{
			get
			{
				if (_mytemplate == null)
					_mytemplate = ComisionHypermedia.GetInstance();
				return _mytemplate;
			}

			set
			{
				_mytemplate = value;
			}
		}


		public override long IDRepresentation()
		{
			return id_comision;
		}
		public void GetMyComision()
		{
			Href = ComisionHypermedia.GetComisiones.CreateLink(new { id = id_comision }).Href;
		}
		protected override void CreateHypermedia()
		{
			Href = ComisionHypermedia.Comision.CreateLink(new { id = id_comision }).Href;
		}
		public void MyPlanComisionRelations()
		{
			Links.Add(ComisionHypermedia.GetMyPlanComisiones.CreateLink(new { id = id_comision }));
		}
		#endregion
	}
}