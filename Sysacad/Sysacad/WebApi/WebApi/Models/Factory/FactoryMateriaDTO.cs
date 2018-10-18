using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models.DTOs;

namespace WebApi.Models.Factory
{
	public class FactoryMateriaDTO
	{
		private static FactoryMateriaDTO _factory;
		public static FactoryMateriaDTO GetInstance()
		{
			if (_factory == null)
				_factory = new FactoryMateriaDTO();
			return _factory;
		}
		#region DTO
		public MateriaDTO CreateDTO(MateriaBE be)
		{
			MateriaDTO dto;
			if (be != null)
			{
				dto = new MateriaDTO()
				{
					id_materia = be.id_materia,
					desc_materia = be.desc_materia,
					hs_semanales = be.hs_semanales,
					hs_totales = be.hs_totales,
					estado = be.estado
				};
				dto.Planmateria = new List<PlanMateriaDTO>();
				if (be.Planmateria != null)
				{
					foreach (var item in be.Planmateria)
					{
						dto.Planmateria.Add(CreatePlanMateriaBusiness(item));
					}
				}
				return dto;
			}
			return dto = new MateriaDTO();
		}
		public PlanMateriaDTO CreatePlanMateriaBusiness(PlanMateriaBE be)
		{
			PlanMateriaDTO dto;
			if (be != null)
			{
				dto = new PlanMateriaDTO()
				{
					idplanmateria = be.idplanmateria,
					idmateria = be.idmateria,
					idplan = be.idplan,
					estado = be.estado
				};
				return dto;
			}
			return dto = new PlanMateriaDTO();
		}
		#endregion
	}
}