using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
	public class Modulos_UsuarioBE : BaseBE
    {
        #region Properties

        public Int32 id_modulo_usuario { get; set; }
        public Int32 id_modulo { get; set; }
        public Int32 id_usuario { get; set; }
        public Boolean alta { get; set; }
        public Boolean baja { get; set; }
        public Boolean modificacion { get; set; }
        public Boolean consulta { get; set; }

        #endregion

        #region Ralation
        public ModuloBE modulo { get; set; }
        public UsuarioBE usuario { get; set; }

        #endregion
    }
}
