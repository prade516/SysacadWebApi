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
                if (be.modulo_usuario != null)
                {
                    dto.modulo_usuario = new List<Modulos_UsuarioDTO>();
                    foreach (var item in be.modulo_usuario)
                    {
                        dto.modulo_usuario.Add(Factory.FactoryModulo_UsuarioDTO.GetInstance().CreateDTO(item));
                    }
                }
				return dto;
			}
			return dto = new ModuloDTO();
		}		
		#endregion
	}
}