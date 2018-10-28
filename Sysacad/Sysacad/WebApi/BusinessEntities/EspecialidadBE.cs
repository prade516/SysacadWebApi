using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    public class EspecialidadBE:BaseBE
    {
        #region Properties
        public Int32 id_especialidad { get; set; }
        public String desc_especialidad { get; set; }
        #endregion

        #region List
        public List<PlanBE> planes { get; set; }
        #endregion
    }
}
