using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
	public class personas: BaseDM
    {
		[Key]
		public Int32 id_persona { get  ; set   ; }
		public Int32 id_plan { get  ; set   ; }
		public String nombre { get  ; set   ; }
		public String apellido { get  ; set   ; }
		public String direccion { get  ; set   ; }
		public String telefono { get  ; set   ; }
		public DateTime fecha_nac { get  ; set   ; }
		public Int32 legajo { get  ; set   ; }
		public Int32 tipo_persona { get  ; set   ; }

        #region Relation
        [ForeignKey(name: "id_persona")]
        public planes plan { get; set; }
        #endregion
        #region List
        public List<usuarios> Usuarios { get; set; }
        #endregion
    }
}
