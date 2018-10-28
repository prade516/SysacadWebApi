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
		public ComisionBE CreateBusiness(DataModel.comisiones entity)
		{
			ComisionBE be;
			if (entity!=null)
			{
				be = new ComisionBE()
				{
					id_comision=entity.id_comision,
					desc_comision=entity.desc_comision,
					anio_especialidad=entity.anio_especialidad,
					estado= entity.estado
				};
				
				return be;
			}
			
			return be = new ComisionBE();
		}		
		#endregion
		#region Entity
		public DataModel.comisiones CreateEntity(ComisionBE be)
		{
            DataModel.comisiones entity;
			if (be != null)
			{
				entity = new DataModel.comisiones()
				{
					id_comision = be.id_comision,
					desc_comision = be.desc_comision,
					anio_especialidad = be.anio_especialidad,
					estado = be.estado
				};
				
				return entity;
			}

			return entity = new DataModel.comisiones();
		}
		
		#endregion
	}
}
