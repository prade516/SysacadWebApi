using BusinessEntities;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessServices.Factory
{
	public static class FactoryEspecialidad
	{
		public static DataModel.especialidades CreateEntity(EspecialidadBE be)
		{
			return new DataModel.especialidades()
			{
				id_especialidad = be.id_especialidad,
				desc_especialidad = be.desc_especialidad,
				estado = be.estado
			};
		}

		public static EspecialidadBE CreateBusiness(DataModel.especialidades entity)
		{
			EspecialidadBE be;
			if (entity!=null)
			{
				be= new EspecialidadBE()
				{
                    id_especialidad = entity.id_especialidad,
					desc_especialidad = entity.desc_especialidad,
					estado = entity.estado
				};
				return be;
			}
			return be = new EspecialidadBE();
		}
	}
}
