using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskTopSysacad.DTO
{
	public class MateriaDTO : BaseSysacadDTO
	{
        #region Properties
        public int id_materia { get; set; }
        public int id_plan { get; set; }
        public string desc_materia { get; set; }
        public int hs_semanales { get; set; }
        public int hs_totales { get; set; }
        #endregion

        #region Relation
        public PlanDTO planes { get; set; }
        #endregion

        #region List
        public List<CursoDTO> cursos { get; set; }
        #endregion
    }
}
