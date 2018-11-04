using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models.DTOs
{
	public class UsuarioDTO : BaseDto
    {
        public Int32 id_usuario { get; set; }
        public String nombre_usuario { get; set; }
        public String clave { get; set; }
        public Boolean habilitado { get; set; }
        public String email { get; set; }
        public Boolean cambia_clave { get; set; }
        public Int32 id_persona { get; set; }
        #region Relation
        public PersonaDTO personas { get; set; }
        #endregion

        #region List
        public List<Modulos_UsuarioDTO> modulo_usuario { get; set; }
        #endregion
    }
}