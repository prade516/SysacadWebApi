using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models.Hypermedia;
using WebApi.Models.Representacion;

namespace WebApi.Models.DTOs
{
	public class Modulos_UsuarioDTO : BaseDto
	{
        public Int32 id_modulo_usuario { get; set; }
        public Int32 id_modulo { get; set; }
        public Int32 id_usuario { get; set; }
        public Boolean alta { get; set; }
        public Boolean baja { get; set; }
        public Boolean modificacion { get; set; }
        public Boolean consulta { get; set; }

        #region Ralation
        public ModuloDTO modulo { get; set; }
        public UsuarioDTO usuario { get; set; }

        #endregion
    }
}