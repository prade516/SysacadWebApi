using BusinessEntities;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Factory
{
	public class FactoryMateria
	{
		private static FactoryMateria _factory;
		public static FactoryMateria GetInstance()
		{
			if (_factory == null)
				_factory = new FactoryMateria();
			return _factory;
		}
		#region Business
		public MateriaBE CreateBusiness(DataModel.materias entity)
		{
			MateriaBE be;
			if (entity!=null)
			{
				be = new MateriaBE()
				{
					id_materia=entity.id_materia,
					desc_materia=entity.desc_materia,
					hs_semanales=entity.hs_semanales,
					hs_totales=entity.hs_totales,
					estado=entity.estado
				};
				
				return be;
			}
			return be = new MateriaBE();
		}		
		#endregion
		#region Entity
		public DataModel.materias  CreateEntity(MateriaBE be)
		{
            DataModel.materias entity;
			if (be != null)
			{
				entity = new DataModel.materias()
				{
					id_materia = be.id_materia,
					desc_materia = be.desc_materia,
					hs_semanales = be.hs_semanales,
					hs_totales = be.hs_totales,
					estado = be.estado
				};
				
				return entity;
			}
			return entity = new DataModel.materias();
		}		
		#endregion
	}
}
