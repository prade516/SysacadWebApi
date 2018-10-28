using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
	public class MateriaBE:BaseBE
	{
        #region Properties
        public int id_materia { get; set; }
        public int id_plan { get; set; }
        public string desc_materia { get; set; }
        public int hs_semanales { get; set; }
        public int hs_totales { get; set; }
        #endregion

        #region Relation
        public PlanBE planes { get; set; }
        #endregion

        #region List
        public List<CursoBE> cursos { get; set; }
        #endregion
    }
}
