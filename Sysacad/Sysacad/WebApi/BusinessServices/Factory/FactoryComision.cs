using BusinessEntities;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Factory
{
	public class FactoryComision
	{
		private static FactoryComision _factory;
		public static FactoryComision GetInstance()
		{
			if (_factory == null)
				_factory = new FactoryComision();
			return _factory;
		}
		#region Business
		public ComisionBE CreateBusiness(comisiones entity)
		{
			ComisionBE be;
			if (entity!=null)
			{
				be = new ComisionBE()
				{
					idcomision=entity.id_comision,
					desc_comision=entity.desc_comision,
					anio_especialidad=entity.anio_especialidad,
					estado= entity.estado
				};
				be.Plancomision = new List<PlanComisionBE>();
				foreach (var item in entity.Plancomision)
				{
					be.Plancomision.Add(CreatePlanComisionBusiness(item));
				}
				return be;
			}
			
			return be = new ComisionBE();
		}
		public PlanComisionBE CreatePlanComisionBusiness(plancomisiones entity)
		{
			PlanComisionBE be;
			if (entity!=null)
			{
				be = new PlanComisionBE()
				{
					idplancomision = entity.id_plancomision,
					idcomision = entity.id_comision,
					idplan = entity.id_plan,
					estado = entity.estado
				};
				return be;
			}
			return be = new PlanComisionBE();
		}
		#endregion
		#region Entity
		public comisiones CreateEntity(ComisionBE be)
		{
			comisiones entity;
			if (be != null)
			{
				entity = new comisiones()
				{
					id_comision = be.idcomision,
					desc_comision = be.desc_comision,
					anio_especialidad = be.anio_especialidad,
					estado = be.estado
				};
				entity.Plancomision = new List<plancomisiones>();
				foreach (var item in be.Plancomision)
				{
					entity.Plancomision.Add(CreatePlanComisionEntity(item));
				}
				return entity;
			}

			return entity = new comisiones();
		}
		public plancomisiones CreatePlanComisionEntity(PlanComisionBE be)
		{
			plancomisiones entity;
			if (be != null)
			{
				entity = new plancomisiones()
				{
					id_plancomision = be.idplancomision,
					id_comision = be.idcomision,
					id_plan = be.idplan,
					estado = be.estado
				};
				return entity;
			}
			return entity = new plancomisiones();
		}
		#endregion
	}
}
