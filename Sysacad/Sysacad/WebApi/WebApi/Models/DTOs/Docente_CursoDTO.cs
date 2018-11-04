using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models.DTOs
{
	public class Docente_CursoDTO : BaseDto
	{
        #region Properties

        public int id_dictado { get; set; }
        public int cargo { get; set; }
        public int id_docente { get; set; }
        public int id_curso { get; set; }
        #endregion

        #region Relation
        public CursoDTO cursos { get; set; }
        public PersonaDTO personas { get; set; }
        #endregion
    }
}