using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models.DTOs;

namespace WebApi.Models.Factory
{
	public class FactoryPlanDTO
	{
		private static FactoryPlanDTO _factory;
		public static FactoryPlanDTO GetInstance()
		{
			if (_factory == null)
				_factory = new FactoryPlanDTO();
			return _factory;
		}
		#region Entity
		public PlanDTO CreateDTO(PlanBE be)
		{
			PlanDTO dto = new PlanDTO()
			{
				id_plan = be.id_plan,
				desc_plan = be.desc_plan,
				estado = be.estado
			};
			dto.Planespecialidad = new List<PlanEspecialidadTOD>();
			if (be.Planespecialidad != null)
			{
				foreach (var item in be.Planespecialidad)
				{
					dto.Planespecialidad.Add(CreateDTOPlanEspecialidad(item));
				}
			}
			return dto;
		}
		public PlanEspecialidadTOD CreateDTOPlanEspecialidad(PlanEspecialidadBE be)
		{
			PlanEspecialidadTOD dto;
			if (be!=null)
			{
				 dto = new PlanEspecialidadTOD()
				 {
					idplanespecialidad = be.idplanespecialidad,
					idplan = be.idplan,
					idespecialidad = be.idespecialidad,
					estado=be.estado,
					Especialidad = FactoryEspecialidadDTO.GetInstance().CreateDTO(be.Especialidad)
				 };
				return dto;
			}			
			return dto = new PlanEspecialidadTOD();
		}
		#endregion
	}
}