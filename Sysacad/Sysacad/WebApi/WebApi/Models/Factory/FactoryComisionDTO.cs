using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models.DTOs;

namespace WebApi.Models.Factory
{
	public class FactoryComisionDTO
	{
		private static FactoryComisionDTO _factory;
		public static FactoryComisionDTO GetInstance()
		{
			if (_factory == null)
				_factory = new FactoryComisionDTO();
			return _factory;
		}
		#region Business
		public ComisionDTO CreateDTO(ComisionBE be)
		{
			ComisionDTO dto;
			if (be != null)
			{
				dto = new ComisionDTO()
				{
					id_comision = be.id_comision,
					desc_comision = be.desc_comision,
					anio_especialidad = be.anio_especialidad,
					estado = be.estado
				};
				
				return dto;
			}
			return dto = new ComisionDTO();
		}
		
		#endregion
	}
}