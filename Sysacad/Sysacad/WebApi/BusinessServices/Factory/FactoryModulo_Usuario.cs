using BusinessEntities;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Factory
{
    public class FactoryModulo_Usuario
    {
        #region Constructor Singleton
        private static FactoryModulo_Usuario _factory;
        public static FactoryModulo_Usuario GetInstance()
        {
            if (_factory == null)
                _factory = new FactoryModulo_Usuario();
            return _factory;
        }
        #endregion

        #region Create Business
        public Modulos_UsuarioBE CreateBusiness(DataModel.modulos_usuarios entity)
        {
            Modulos_UsuarioBE be;
            if (entity != null)
            {
                be = new Modulos_UsuarioBE()
                {
                    id_modulo_usuario = entity.id_modulo_usuario,
                    id_modulo = entity.id_modulo,
                    id_usuario = entity.id_usuario,
                    alta = entity.alta,
                    modificacion = entity.modificacion,
                    consulta = entity.consulta,
                    baja = entity.baja,
                    estado = entity.estado,
                    modulo = null,
                    usuario = null
                };
                return be;
            }
            return be = new Modulos_UsuarioBE();
        }
        #endregion

        #region Create Business
        public DataModel.modulos_usuarios CreateEntity (Modulos_UsuarioBE  be)
        {
            DataModel.modulos_usuarios entity;
            if (be != null)
            {
                entity = new DataModel.modulos_usuarios()
                {
                    id_modulo_usuario = be.id_modulo_usuario,
                    id_modulo = be.id_modulo,
                    id_usuario = be.id_usuario,
                    alta = be.alta,
                    modificacion = be.modificacion,
                    consulta = be.consulta,
                    baja = be.baja,
                    estado = be.estado,
                    modulos = null,
                    usuarios = null
                };
                return entity;
            }
            return entity = new DataModel.modulos_usuarios();
        }
        #endregion
    }
}
