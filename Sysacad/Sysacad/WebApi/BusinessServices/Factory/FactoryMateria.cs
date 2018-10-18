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
		public MateriaBE CreateBusiness(materias entity)
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
				be.Planmateria = new List<PlanMateriaBE>();
				if (entity.Planmateria!=null)
				{
					foreach (var item in entity.Planmateria)
					{
						be.Planmateria.Add(CreatePlanMateriaBusiness(item));
					}
				}
				return be;
			}
			return be = new MateriaBE();
		}
		public PlanMateriaBE CreatePlanMateriaBusiness(planmaterias entity)
		{
			PlanMateriaBE be;
			if (entity!=null)
			{
				be = new PlanMateriaBE()
				{
					idplanmateria= entity.idplanmateria,
					idmateria=entity.idmateria,
					idplan=entity.idplan,
					estado=entity.estado
				};
				return be;
			}
			return be = new PlanMateriaBE();
		}
		#endregion
		#region Entity
		public materias  CreateEntity(MateriaBE be)
		{
			materias entity;
			if (be != null)
			{
				entity = new materias()
				{
					id_materia = be.id_materia,
					desc_materia = be.desc_materia,
					hs_semanales = be.hs_semanales,
					hs_totales = be.hs_totales,
					estado = be.estado
				};
				entity.Planmateria = new List<planmaterias>();
				if (be.Planmateria != null)
				{
					foreach (var item in be.Planmateria)
					{
						entity.Planmateria.Add(CreatePlanMateriaEntity(item));
					}
				}
				return entity;
			}
			return entity = new materias();
		}
		public planmaterias CreatePlanMateriaEntity(PlanMateriaBE be)
		{
			planmaterias entity;
			if (be != null)
			{
				entity = new planmaterias()
				{
					idplanmateria = be.idplanmateria,
					idmateria = be.idmateria,
					idplan = be.idplan,
					estado = be.estado
				};
				return entity;
			}
			return entity = new planmaterias();
		}
		#endregion
	}
}
