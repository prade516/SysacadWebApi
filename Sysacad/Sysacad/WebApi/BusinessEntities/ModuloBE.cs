using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
	public class ModuloBE:BaseBE
	{
        public Int32 id_modulo { get; set; }
        public String desc_modulo { get; set; }
        public String ejecuta { get; set; }

        #region List
        public List<Modulos_UsuarioBE> modulo_usuario { get; set; }
        #endregion
    }
}
