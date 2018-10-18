using BusinessEntities;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Factory
{
	public class FactoryUsuario
	{
		private static FactoryUsuario _factory;
		public static FactoryUsuario GetInstance()
		{
			if (_factory == null)
				_factory = new FactoryUsuario();
			return _factory; 
		}
		#region Business
		public UsuarioBE CreateBusiness(usuarios entity)
		{
			UsuarioBE be;
			if (entity!=null)
			{
				be = new UsuarioBE()
				{
					id_usuario=entity.id_usuario,
					id_persona=entity.id_persona,
					clave= SolveApi.Encriptacion.Encriptacion.GetInstance().DecryptKey(entity.clave),
					nombre_usuario=entity.nombre_usuario,
					cambia_clave=entity.cambia_clave,
					email=entity.email,
					habilitado=entity.habilitado,
					estado=entity.estado
				};
				be.modulo_usuario = new List<Modulos_UsuarioBE>();
				if (entity.modulo_usuario!=null)
				{
					foreach (var item in entity.modulo_usuario)
					{
						be.modulo_usuario.Add(CreateModuloUsuarioBusiness(item));
					}
				}
				return be;
			}
			return be = new UsuarioBE();
		}
		public Modulos_UsuarioBE CreateModuloUsuarioBusiness(modulos_usuarios entity)
		{
			Modulos_UsuarioBE be;
			if (entity!=null)
			{
				be = new Modulos_UsuarioBE()
				{
					id_modulo_usuario=entity.id_modulo_usuario,
					id_modulo=entity.id_modulo,
					id_usuario=entity.id_usuario,
					alta=entity.alta,
					modificacion=entity.modificacion,
					consulta=entity.consulta,
					baja=entity.baja,
					estado=entity.estado
				};
				return be;
			}
			return be = new Modulos_UsuarioBE();
		}
		#endregion

		#region Entity
		public usuarios CreateEntity(UsuarioBE be)
		{
			usuarios entity;
			if (be != null)
			{
				entity = new usuarios()
				{
					id_usuario = be.id_usuario,
					id_persona = be.id_persona,
					clave = SolveApi.Encriptacion.Encriptacion.GetInstance().EncryptKey(be.clave),
					nombre_usuario = be.nombre_usuario,
					cambia_clave = be.cambia_clave,
					email = be.email,
					habilitado = be.habilitado,
					estado = be.estado
				};
				entity.modulo_usuario = new List<modulos_usuarios>();
				if (be.modulo_usuario != null)
				{
					foreach (var item in be.modulo_usuario)
					{
						entity.modulo_usuario.Add(CreateModuloUsuarioEntity(item));
					}
				}
				return entity;
			}
			return entity = new usuarios();
		}
		public modulos_usuarios  CreateModuloUsuarioEntity(Modulos_UsuarioBE be)
		{
			modulos_usuarios entity;
			if (be != null)
			{
				entity = new modulos_usuarios()
				{
					id_modulo_usuario = be.id_modulo_usuario,
					id_modulo = be.id_modulo,
					id_usuario = be.id_usuario,
					alta = be.alta,
					modificacion = be.modificacion,
					consulta = be.consulta,
					baja = be.baja,
					estado = be.estado
				};
				return entity;
			}
			return entity = new modulos_usuarios();
		}
		#endregion
	}
}
