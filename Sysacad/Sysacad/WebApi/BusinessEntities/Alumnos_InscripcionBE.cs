using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
	public class Alumnos_InscripcionBE:BaseBE
	{
        #region Properties
  
        public int id_inscripcion { get; set; }
        public int id_alumno { get; set; }
        public int id_curso { get; set; }
        public string condicion { get; set; }
        public int nota { get; set; }
        #endregion

        #region Relation
        public CursoBE cursos { get; set; }
        public PersonaBE personas { get; set; }
        #endregion
    }
}
