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
                    id_plan = be.id_plan,
					desc_materia = be.desc_materia,
					hs_semanales = be.hs_semanales,
					hs_totales = be.hs_totales,
					estado = be.estado
				};				
				return dto;
			}
			return dto = new MateriaDTO();
		}
		
		#endregion
	}
}