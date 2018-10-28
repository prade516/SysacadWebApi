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
		public PlanBE CreateBusiness(DataModel.planes entity)
		{
			PlanBE be = new PlanBE()
			{
				id_plan = entity.id_plan,
                id_especialidad = entity.id_especialidad,
				desc_plan = entity.desc_plan,
				estado = entity.estado
			};			
			return be;
		}		
		#endregion

		#region Entity
		public DataModel.planes CreateEntity(PlanBE be)
		{
            DataModel.planes entity = new DataModel.planes()
			{
				id_plan = be.id_plan,
                id_especialidad = be.id_especialidad,
				desc_plan = be.desc_plan,
				estado = be.estado
			};			
			return entity;
		}
		
		#endregion
	}
}
