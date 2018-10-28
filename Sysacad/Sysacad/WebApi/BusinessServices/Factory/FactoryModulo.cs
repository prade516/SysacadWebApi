using BusinessEntities;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Factory
{
	public class FactoryModulo
	{
		private static FactoryModulo _factory;
		public static FactoryModulo GetInstance()
		{
			if (_factory == null)
				_factory = new FactoryModulo();
			return _factory;
		}

		#region Business
		public ModuloBE CreateBusiness(DataModel.modulos entity)
		{
			ModuloBE be;
			if (entity!=null)
			{
				be = new ModuloBE()
				{
					id_modulo=entity.id_modulo,
					desc_modulo=entity.desc_modulo,
					ejecuta=entity.ejecuta,
					estado=entity.estado
				};
				be.modulo_usuario = new List<Modulos_UsuarioBE>();
				if (entity.modulos_usuarios!=null)
				{
					foreach (var item in entity.modulos_usuarios)
					{
						be.modulo_usuario.Add(FactoryModulo_Usuario.GetInstance().CreateBusiness(item));
					}
				}
				return be;
			}
			return be = new ModuloBE();
		}		
		#endregion

		#region Entity
		public DataModel.modulos CreateEntity(ModuloBE be)
		{
            DataModel.modulos entity;
			if (be != null)
			{
				entity = new DataModel.modulos()
				{
					id_modulo = be.id_modulo,
					desc_modulo = be.desc_modulo,
					ejecuta = be.ejecuta,
					estado = be.estado
				};				
				return entity;
			}
			return entity = new DataModel.modulos();
		}
		
		#endregion
	}
}
