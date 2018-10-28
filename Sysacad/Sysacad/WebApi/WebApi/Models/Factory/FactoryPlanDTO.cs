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

		#region DTO
		public PlanDTO CreateDTO(PlanBE be)
		{
			PlanDTO dto = new PlanDTO()
			{
				id_plan = be.id_plan,
				desc_plan = be.desc_plan,
                id_especialidad = be.id_especialidad,
                Especialidad = be.especialidades !=null? FactoryEspecialidadDTO.GetInstance().CreateDTO(be.especialidades):null,
                estado = be.estado
			};
			
			return dto;
		}		
		#endregion
	}
}