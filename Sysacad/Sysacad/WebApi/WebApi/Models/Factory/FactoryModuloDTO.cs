using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models.DTOs;

namespace WebApi.Models.Factory
{
	public class FactoryModuloDTO
	{
		private static FactoryModuloDTO _factory;
		public static FactoryModuloDTO GetInstance()
		{
			if (_factory == null)
				_factory = new FactoryModuloDTO();
			return _factory;
		}
		#region DTO
		public ModuloDTO CreateDTO(ModuloBE be)
		{
			ModuloDTO dto;
			if (be != null)
			{
				dto = new ModuloDTO()
				{
					id_modulo = be.id_modulo,
					desc_modulo = be.desc_modulo,
					ejecuta = be.ejecuta,
					estado = be.estado
				};				
				return dto;
			}
			return dto = new ModuloDTO();
		}		
		#endregion
	}
}