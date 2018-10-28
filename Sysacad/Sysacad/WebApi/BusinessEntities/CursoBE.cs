using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
	public class CursoBE:BaseBE
	{
        #region Properties
       
        public int id_curso { get; set; }

        public int id_materia { get; set; }

        public int id_comision { get; set; }

        public int anio_calendario { get; set; }

        public int cupo { get; set; }
        #endregion

        #region Relation
      
        public ComisionBE comisiones { get; set; }
        public MateriaBE materias { get; set; }
        #endregion

        #region List
        public List<Alumnos_InscripcionBE> alumnos_inscripciones { get; set; }
        public List<Docente_CursoBE> docentes_cursos { get; set; }
        #endregion
    }
}
