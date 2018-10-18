﻿using BusinessEntities;
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
				if (be.curso != null)
				{
					dto.curso = FactoryCursoDTO.GetInstance().CreateDTO(be.curso);
				}
				dto.persona = new PersonaDTO();
				if (be.persona != null)
				{
					dto.persona = FactoryPersonaDTO.GetInstance().CreateDTO(be.persona);
				}
				return dto;
			}
			return dto = new Alumnos_InscripcionDTO();
		}
		#endregion
	}
}