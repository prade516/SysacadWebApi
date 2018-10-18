using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models.Hypermedia;
using WebApi.Models.Representacion;

namespace WebApi.Models.DTOs
{
	public class PlanDTO : BaseRepresentation
	{
		#region Constructor
		public PlanDTO()
		{
			Rel = Mytemplate.GetMyRelationReference().Rel;
		}
		#endregion		
		private Int32 _id_plan;
		private String _desc_plan;
		private Int32 _estado;

		private List<PlanEspecialidadTOD> _planespecialidad;


		public int id_plan { get => _id_plan; set => _id_plan = value; }
		public string desc_plan { get => _desc_plan; set => _desc_plan = value; }
		public int estado { get => _estado; set => _estado = value; }
		public List<PlanEspecialidadTOD> Planespecialidad { get => _planespecialidad; set => _planespecialidad = value; }

		#region Method Override
		public override BaseHypermedia Mytemplate
		{
			get
			{
				if (_mytemplate == null)
					_mytemplate = PlanHypermedia.GetInstance();
				return _mytemplate;
			}

			set
			{
				_mytemplate = value;
			}
		}
		public override long IDRepresentation()
		{
			return id_plan;
		}
		public void GetMyEspecialidad()
		{
			Href = PlanHypermedia.GetPlanes.CreateLink(new { id = id_plan }).Href;
		}
		protected override void CreateHypermedia()
		{
			Href = PlanHypermedia.Plan.CreateLink(new { id = id_plan }).Href;
		}
		public void MyPlanEspecialidadRelations()
		{
			Links.Add(PlanHypermedia.GetMyPlanEspecialidades.CreateLink(new { id = id_plan }));
		}
		#endregion
	}
}