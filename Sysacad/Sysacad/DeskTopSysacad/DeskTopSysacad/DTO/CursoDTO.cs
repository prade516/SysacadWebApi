using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskTopSysacad.DTO
{
	public class CursoDTO : BaseSysacadDTO
	{
        #region Properties

        public int id_curso { get; set; }

        public int id_materia { get; set; }

        public int id_comision { get; set; }

        public int anio_calendario { get; set; }

        public int cupo { get; set; }

        public string accion { get; set; }
        public string materia { get; set; }
        #endregion

        #region Relation

        public ComisionDTO comisiones { get; set; }
        public MateriaDTO materias { get; set; }
        #endregion

        #region List
        public List<Alumnos_InscripcionDTO> alumnos_inscripciones { get; set; }
        public List<Docente_CursoDTO> docentes_cursos { get; set; }
        #endregion

    }
}
