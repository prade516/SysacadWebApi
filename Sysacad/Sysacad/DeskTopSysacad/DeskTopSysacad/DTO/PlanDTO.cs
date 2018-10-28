using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskTopSysacad.DTO
{
	public class PlanDTO : BaseSysacadDTO
	{
        #region Properties

        public int id_plan { get; set; }
        public int id_especialidad { get; set; }
        public string desc_plan { get; set; }
        #endregion

        #region Relation
        public EspecialidadDTO especialidades { get; set; }
        #endregion

        #region List
        public List<ComisionDTO> comisiones { get; set; }
        public List<MateriaDTO> materias { get; set; }
        public List<PersonaDTO> personas { get; set; }
        #endregion
    }
}
