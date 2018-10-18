using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models.Hypermedia;
using WebApi.Models.Representacion;

namespace WebApi.Models.DTOs
{
	public class PlanMateriaDTO : BaseRepresentation
	{
		#region Constructor
		public PlanMateriaDTO()
		{
			Rel = Mytemplate.GetMyRelationReference().Rel;
		}
		#endregion

		private Int32 _idplanmateria;
		private Int32 _idplan;
		private Int32 _idmateria;
		private Int32 _estado;

		private MateriaDTO _materia;
		private PlanDTO _plan;

		public int idplanmateria { get => _idplanmateria; set => _idplanmateria = value; }
		public int idplan { get => _idplan; set => _idplan = value; }
		public int idmateria { get => _idmateria; set => _idmateria = value; }
		public int estado { get => _estado; set => _estado = value; }

		public MateriaDTO materia { get => _materia; set => _materia = value; }
		public PlanDTO plan { get => _plan; set => _plan = value; }

		#region Method Override
		public override BaseHypermedia Mytemplate
		{
			get
			{
				if (_mytemplate == null)
					_mytemplate = PlanmateriaHypermedia.GetInstance();
				return _mytemplate;
			}

			set
			{
				_mytemplate = value;
			}
		}


		public override long IDRepresentation()
		{
			return idplanmateria;
		}
		public void GetMyPlanComision()
		{
			Href = PlanmateriaHypermedia.GetPlanmaterias.CreateLink(new { id = idplanmateria }).Href;
		}
		protected override void CreateHypermedia()
		{
			Href = PlanmateriaHypermedia.Planmateria.CreateLink(new { id = idplanmateria }).Href;
		}
		#endregion
	}
}