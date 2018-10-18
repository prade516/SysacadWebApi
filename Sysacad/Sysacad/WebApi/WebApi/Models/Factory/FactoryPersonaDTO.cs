using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models.DTOs;

namespace WebApi.Models.Factory
{
	public class FactoryPersonaDTO
	{
		private static FactoryPersonaDTO _factory;
		public static FactoryPersonaDTO GetInstance()
		{
			if (_factory == null)
				_factory = new FactoryPersonaDTO();
			return _factory;
		}

		#region DTO
		public PersonaDTO CreateDTO(PersonaBE be)
		{
			PersonaDTO dto;
			if (be != null)
			{
				dto = new PersonaDTO()
				{
					id_persona = be.id_persona,
					id_plan = be.id_plan,
					apellido = be.apellido,
					nombre = be.nombre,
					direccion = be.direccion,
					fecha_nac = be.fecha_nac,
					legajo = be.legajo,
					telefono = be.telefono,
					tipo_persona = be.tipo_persona,
					estado = be.estado
				};
				dto.Usuarios = new List<UsuarioDTO>();
				if (be.Usuarios != null)
				{
					foreach (var item in be.Usuarios)
					{
						dto.Usuarios.Add(FactoryUsuarioDTO.GetInstance().CreateDTO(item));
					}
				}
				return dto;
			}
			return dto = new PersonaDTO();
		}
		#endregion
	}
}