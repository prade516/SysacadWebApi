using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models.DTOs;

namespace WebApi.Models.Factory
{
	public class FactoryCursoDTO
	{
		private static FactoryCursoDTO _factory;
		public static FactoryCursoDTO GetInstance()
		{
			if (_factory == null)
				_factory = new FactoryCursoDTO();
			return _factory;
		}
		#region DTO
		public CursoDTO CreateDTO(CursoBE be)
		{
			CursoDTO dto;
			if (be != null)
			{
				dto = new CursoDTO()
				{
					id_curso = be.id_curso,
					id_comision = be.id_comision,
					id_materia = be.id_materia,
					anio_calendario = be.anio_calendario,
					cupo = be.cupo,
					estado = be.estado
				};
				dto.Docente_curso = new List<Docente_CursoDTO>();
				if (be.docentes_cursos!=null)
				{
					foreach (var item in be.docentes_cursos)
					{
						dto.Docente_curso.Add(FactoryDocente_CursoDTO.GetInstance().CreateDTO(item));
					}
				}
				return dto;
			}
			return dto = new CursoDTO();
		}
		#endregion
	}
}