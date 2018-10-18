using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
	public class UsuarioBE: BaseBE
    {
        public Int32 id_usuario { get; set; }
        public String nombre_usuario { get; set; }
        public String clave { get; set; }
        public Boolean habilitado { get; set; }
        public String email { get; set; }
        public Boolean cambia_clave { get; set; }
        public Int32 id_persona { get; set; }
        #region Relation
        public PersonaBE personas { get; set; }
        #endregion

        #region List
        public List<Modulos_UsuarioBE> modulo_usuario { get; set; }
        #endregion
    }
}
