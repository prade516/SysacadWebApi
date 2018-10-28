using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
	public class PlanBE:BaseBE
	{
        #region Properties
        
        public int id_plan { get; set; }
        public int id_especialidad { get; set; }
        public string desc_plan { get; set; }
        #endregion

        #region Relation
        public EspecialidadBE especialidades { get; set; }
        #endregion

        #region List
        public List<ComisionBE> comisiones { get; set; }
        public List<MateriaBE> materias { get; set; }
        public List<PersonaBE> personas { get; set; }
        #endregion
    }
}
