using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models.DTOs;

namespace WebApi.Models.Factory
{
	public class FactoryAlumnos_InscripcionDTO
	{
		private static FactoryAlumnos_InscripcionDTO _factory;
		public static FactoryAlumnos_InscripcionDTO GetInstance()
		{
			if (_factory == null)
				_factory = new FactoryAlumnos_InscripcionDTO();
			return _factory;
		}
		#region Business
		public Alumnos_InscripcionDTO CreateDTO(Alumnos_InscripcionBE be)
		{
			Alumnos_InscripcionDTO dto;
			if (be != null)
			{
				dto = new Alumnos_InscripcionDTO()
				{
					id_inscripcion = be.id_inscripcion,
					id_curso = be.id_curso,
					id_alumno=be.id_alumno,
					condicion = be.condicion,
					nota = be.nota,
					estado = be.estado
				};
				dto.curso = new CursoDTO();
				if (be.cursos != null)
				{
					dto.curso = FactoryCursoDTO.GetInstance().CreateDTO(be.cursos);
				}
				dto.persona = new PersonaDTO();
				if (be.personas != null)
				{
					dto.persona = FactoryPersonaDTO.GetInstance().CreateDTO(be.personas);
				}
				return dto;
			}
			return dto = new Alumnos_InscripcionDTO();
		}
		#endregion
	}
}