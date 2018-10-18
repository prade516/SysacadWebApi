using BusinessEntities;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Factory
{
	public class FactoryPlan
	{
		private static FactoryPlan _factory;
		public static FactoryPlan GetInstance()
		{
			if (_factory == null)
				_factory = new FactoryPlan();
			return _factory;
		}

		#region Business
		public PlanBE CreateBusiness(planes entity)
		{
			PlanBE be = new PlanBE()
			{
				id_plan = entity.id_plan,
				desc_plan = entity.desc_plan,
				estado = entity.estado
			};			
			return be;
		}
		public PlanEspecialidadBE CreateBusinessPlanEspecialidad(planespecialidades entity)
		{
			PlanEspecialidadBE be;
			if (entity != null)
			{
				 be = new PlanEspecialidadBE()
				 {
					idplanespecialidad = entity.idplanespecialidad,
					idplan = entity.idplan,
					idespecialidad = entity.idespecialidad,
					estado=entity.estado,
					Especialidad = entity != null? FactoryEspecialidad.CreateBusiness(entity.Especialidad):null
				 };
				return be;
			}
			return be = new PlanEspecialidadBE();
		}
		#endregion

		#region Entity
		public planes CreateEntity(PlanBE be)
		{
			planes entity = new planes()
			{
				id_plan = be.id_plan,
				desc_plan = be.desc_plan,
				estado = be.estado
			};			
			return entity;
		}
		
		#endregion
	}
}
