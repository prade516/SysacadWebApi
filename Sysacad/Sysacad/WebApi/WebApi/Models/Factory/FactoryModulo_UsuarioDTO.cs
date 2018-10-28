using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models.DTOs;

namespace WebApi.Models.Factory
{
    public class FactoryModulo_UsuarioDTO
    {
        private static FactoryModulo_UsuarioDTO _factory;
        public static FactoryModulo_UsuarioDTO GetInstance()
        {
            if (_factory == null)
                _factory = new FactoryModulo_UsuarioDTO();
            return _factory;
        }

        #region Create dto
        public Modulos_UsuarioDTO CreateDTO(Modulos_UsuarioBE be)
        {
            Modulos_UsuarioDTO dto;
            if (be != null)
            {
                dto = new Modulos_UsuarioDTO()
                {
                    id_modulo_usuario = be.id_modulo_usuario,
                    id_modulo = be.id_modulo,
                    id_usuario = be.id_usuario,
                    alta = be.alta,
                    modificacion = be.modificacion,
                    consulta = be.consulta,
                    baja = be.baja,
                    estado = be.estado,
                    modulo = null,
                    usuario = null
                };
                return dto;
            }
            return dto = new Modulos_UsuarioDTO();
        }
        #endregion
    }
}