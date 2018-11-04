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
                    accion = be.accion,
                    materias = be.materias != null ? FactoryMateriaDTO.GetInstance().CreateDTO(be.materias) : null,
                    comisiones = be.comisiones != null ? FactoryComisionDTO.GetInstance().CreateDTO(be.comisiones) : null,
                    estado = be.estado
				};
				dto.docentes_cursos = new List<Docente_CursoDTO>();
				if (be.docentes_cursos!=null)
				{
					foreach (var item in be.docentes_cursos)
					{
						dto.docentes_cursos.Add(FactoryDocente_CursoDTO.GetInstance().CreateDTO(item));
					}
				}

                dto.alumnos_inscripciones = new List<Alumnos_InscripcionDTO>();
                if (be.alumnos_inscripciones != null)
                {
                    foreach (var item in be.alumnos_inscripciones)
                    {
                        dto.alumnos_inscripciones.Add(FactoryAlumnos_InscripcionDTO.GetInstance().CreateDTO(item));
                    }
                }
                return dto;
			}
			return dto = new CursoDTO();
		}
		#endregion
	}
}