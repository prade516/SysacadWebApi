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
		public ModuloBE CreateBusiness(modulos entity)
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
				if (entity.modulo_usuario!=null)
				{
					foreach (var item in entity.modulo_usuario)
					{
						be.modulo_usuario.Add(CreateModUsuarioBusiness(item));
					}
				}
				return be;
			}
			return be = new ModuloBE();
		}
		public Modulos_UsuarioBE CreateModUsuarioBusiness(modulos_usuarios entity)
		{
			Modulos_UsuarioBE be;
			if (entity!=null)
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
					usuario=null
				};
				return be;
			}
			return be = new Modulos_UsuarioBE();
		}
		#endregion
		#region Entity
		public modulos CreateEntity(ModuloBE be)
		{
			modulos entity;
			if (be != null)
			{
				entity = new modulos()
				{
					id_modulo = be.id_modulo,
					desc_modulo = be.desc_modulo,
					ejecuta = be.ejecuta,
					estado = be.estado
				};				
				return entity;
			}
			return entity = new modulos();
		}
		
		#endregion
	}
}
