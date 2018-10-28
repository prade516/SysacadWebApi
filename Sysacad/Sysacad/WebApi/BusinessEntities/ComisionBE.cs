using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
	public class ComisionBE:BaseBE
	{
        #region Properties
        public int id_comision { get; set; }
        public int id_plan { get; set; }
        public string desc_comision { get; set; }
        public int anio_especialidad { get; set; }
        #endregion

        #region Relation
        public virtual PlanBE planes { get; set; }
        #endregion

        #region List
        public List<CursoBE> cursos { get; set; }
        #endregion
    }
}
