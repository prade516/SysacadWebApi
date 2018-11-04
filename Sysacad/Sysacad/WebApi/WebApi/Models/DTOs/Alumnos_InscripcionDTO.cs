using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models.DTOs
{
	public class Alumnos_InscripcionDTO :BaseDto
    {
        #region Properties

        public int id_inscripcion { get; set; }
        public int id_alumno { get; set; }
        public int id_curso { get; set; }
        public string condicion { get; set; }
        public int nota { get; set; }
        #endregion

        #region Relation
        public CursoDTO cursos { get; set; }
        public PersonaDTO personas { get; set; }
        #endregion       
	}
}