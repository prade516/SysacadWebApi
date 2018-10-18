using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models.DTOs;

namespace WebApi.Models.Factory
{
	public class FactoryEspecialidadDTO
	{
		private static FactoryEspecialidadDTO _factory;
		public static FactoryEspecialidadDTO GetInstance()
		{
			if (_factory == null)
				_factory = new FactoryEspecialidadDTO();
			return _factory;
		}
		public EspecialidadDTO CreateDTO(EspecialidadBE be)
		{
			EspecialidadDTO dto = new EspecialidadDTO()
			{
				id_especialidad=be.idespecialidad,
				desc_especialidad=be.desc_especialidad,
				estado=be.estado
			};
			return dto;
		}
	}
}