using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models.Hypermedia;
using WebApi.Models.Representacion;

namespace WebApi.Models.DTOs
{
	public class ModuloDTO : BaseDto
	{
        public Int32 id_modulo { get; set; }
        public String desc_modulo { get; set; }
        public String ejecuta { get; set; }

        #region List
        public List<Modulos_UsuarioDTO> modulo_usuario { get; set; }
        #endregion
    }
}