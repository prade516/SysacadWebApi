using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models.Hypermedia;
using WebApi.Models.Representacion;

namespace WebApi.Models.DTOs
{
	public class PlanComisionDTO : BaseRepresentation
	{
		#region Constructor
		public PlanComisionDTO()
		{
			Rel = Mytemplate.GetMyRelationReference().Rel;
		}
		#endregion
		private Int32 _idplancomision;
		private Int32 _idplan;
		private Int32 _idcomision;
		private Int32 _estado;

		private PlanDTO _plan;
		private ComisionDTO _comision;

		public int idplancomision { get => _idplancomision; set => _idplancomision = value; }
		public int idplan { get => _idplan; set => _idplan = value; }
		public int idcomision { get => _idcomision; set => _idcomision = value; }
		public int estado { get => _estado; set => _estado = value; }
		public PlanDTO Plan { get => _plan; set => _plan = value; }
		public ComisionDTO comision { get => _comision; set => _comision = value; }

		#region Method Override
		public override BaseHypermedia Mytemplate
		{
			get
			{
				if (_mytemplate == null)
					_mytemplate = PlanComisionHypermedia.GetInstance();
				return _mytemplate;
			}

			set
			{
				_mytemplate = value;
			}
		}


		public override long IDRepresentation()
		{
			return idplancomision;
		}
		public void GetMyPlanComision()
		{
			Href = PlanComisionHypermedia.GetPlanComisiones.CreateLink(new { id = idplancomision }).Href;
		}
		protected override void CreateHypermedia()
		{
			Href = PlanComisionHypermedia.PlanComision.CreateLink(new { id = idplancomision }).Href;
		}
		#endregion
	}
}