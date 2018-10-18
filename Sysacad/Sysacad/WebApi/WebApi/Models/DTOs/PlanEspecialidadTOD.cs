using System;
using WebApi.Models.Hypermedia;
using WebApi.Models.Representacion;

namespace WebApi.Models.DTOs
{
	public class PlanEspecialidadTOD : BaseRepresentation
	{
		private Int32 _idplanespecialidad;
		private Int32 _idplan;
		private Int32 _idespecialidad;
		private Int32 _estado;

		private PlanDTO _plan;
		private EspecialidadDTO _especialidad;


		public int idplanespecialidad { get => _idplanespecialidad; set => _idplanespecialidad = value; }
		public int idplan { get => _idplan; set => _idplan = value; }
		public int idespecialidad { get => _idespecialidad; set => _idespecialidad = value; }
		public int estado { get => _estado; set => _estado = value; }
		public PlanDTO Plan { get => _plan; set => _plan = value; }
		public EspecialidadDTO Especialidad { get => _especialidad; set => _especialidad = value; }

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
			return idplan;
		}
		public void GetMyEspecialidad()
		{
			Href = PlanHypermedia.GetPlanes.CreateLink(new { id = idplan }).Href;
		}
		protected override void CreateHypermedia()
		{
			Href = PlanHypermedia.Plan.CreateLink(new { id = idplan }).Href;
		}
		public void MyPlanEspecialidadRelations()
		{
			Links.Add(PlanHypermedia.GetMyPlanEspecialidades.CreateLink(new { id = idplan }));
		}
		#endregion
	}
}