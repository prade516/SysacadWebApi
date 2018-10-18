using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
	public class usuarios: BaseDM
    {
		[Key]
		public Int32 id_usuario { get ; set ; }
		public String nombre_usuario { get ; set; }
		public String clave { get; set ; }
		public Boolean habilitado { get; set ; }
		public String email { get; set ; }
		public Boolean cambia_clave { get ; set ; }
		public Int32 id_persona { get; set; }
        #region Relation
        [ForeignKey(name: "id_persona")]
        public personas personas { get; set; }
        #endregion

        #region List
        public List<modulos_usuarios> modulo_usuario { get; set; }
        #endregion
    }
}
