using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models.DTOs;

namespace WebApi.Models.Factory
{
	public class FactoryDocente_CursoDTO
	{
		private static FactoryDocente_CursoDTO _factory;
		public static FactoryDocente_CursoDTO GetInstance()
		{
			if (_factory == null)
				_factory = new FactoryDocente_CursoDTO();
			return _factory;
		}
		#region Business
		public Docente_CursoDTO CreateDTO(Docente_CursoBE be)
		{
			Docente_CursoDTO dto;
			if (be != null)
			{
				dto = new Docente_CursoDTO()
				{
					id_curso = be.id_curso,
					id_dictado = be.id_dictado,
					id_docente = be.id_docente,
					cargo = be.cargo,
					estado = be.estado
				};
				return dto;
			}
			return dto = new Docente_CursoDTO();
		}
		#endregion
	}
}