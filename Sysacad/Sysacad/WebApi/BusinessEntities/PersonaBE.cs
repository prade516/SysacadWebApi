using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
	public class PersonaBE: BaseBE
    {
        #region Properties

        public Int32 id_persona { get; set; }
        public Int32 id_plan { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public String direccion { get; set; }
        public String telefono { get; set; }
        public DateTime fecha_nac { get; set; }
        public Int32 legajo { get; set; }
        public Int32 tipo_persona { get; set; }

        #endregion

        #region Relation
        public PlanBE plan { get; set; }
        #endregion

        #region List
        public List<UsuarioBE> Usuarios { get; set; }
        #endregion
    }
}
