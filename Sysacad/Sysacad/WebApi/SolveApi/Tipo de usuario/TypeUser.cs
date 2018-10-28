using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolveApi.Tipo_de_usuario
{
    public class TypeUser
    {
        #region Constructor Single
        private static TypeUser _factory;
        public static TypeUser GetInstance()
        {
            if (_factory == null)
                _factory = new TypeUser();
            return _factory;
        }
        #endregion

        public Int32 GetTyperUser(Int32 type)
        {
            var tipo = 0;
            switch (type)
            {
                case 1:
                    tipo = Convert.ToInt32(Enum.RolPersonEnum.Administrador);
                    break;
                case 2:
                    tipo = Convert.ToInt32(Enum.RolPersonEnum.Docente);
                    break;
                default:
                    tipo = Convert.ToInt32(Enum.RolPersonEnum.Alumno);
                    break;
            }
            return tipo;
        }
    }
}
