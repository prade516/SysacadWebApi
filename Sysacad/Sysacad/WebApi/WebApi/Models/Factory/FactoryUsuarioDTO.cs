using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models.DTOs;

namespace WebApi.Models.Factory
{
	public class FactoryUsuarioDTO
	{
		private static FactoryUsuarioDTO _factory;
		public static FactoryUsuarioDTO GetInstance()
		{
			if (_factory == null)
				_factory = new FactoryUsuarioDTO();
			return _factory;
		}

		#region DTO
		public UsuarioDTO CreateDTO(UsuarioBE be)
		{
			UsuarioDTO dto;
			if (be != null)
			{
				dto = new UsuarioDTO()
				{
					id_usuario = be.id_usuario,
					id_persona = be.id_persona,
					clave = be.clave,
					nombre_usuario = be.nombre_usuario,
					cambia_clave = be.cambia_clave,
					email = be.email,
					habilitado = be.habilitado,
					estado = be.estado
				};
				dto.modulo_usuario = new List<Modulos_UsuarioDTO>();
				if (be.modulo_usuario != null)
				{
					foreach (var item in be.modulo_usuario)
					{
						dto.modulo_usuario.Add(CreateModuloUsuarioDTO(item));
					}
				}
				return dto;
			}
			return dto = new UsuarioDTO();
		}
		public Modulos_UsuarioDTO CreateModuloUsuarioDTO(Modulos_UsuarioBE be)
		{
			Modulos_UsuarioDTO dto;
			if (be != null)
			{
				dto = new Modulos_UsuarioDTO()
				{
					id_modulo_usuario = be.id_modulo_usuario,
					id_modulo = be.id_modulo,
					id_usuario = be.id_usuario,
					alta = be.alta,
					modificacion = be.modificacion,
					consulta = be.consulta,
					baja = be.baja,
					estado = be.estado
				};
				return dto;
			}
			return dto = new Modulos_UsuarioDTO();
		}
		#endregion		
	}
}