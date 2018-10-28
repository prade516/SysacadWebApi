using BusinessEntities;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Factory
{
	public class FactoryPersona
	{
		private static FactoryPersona _factory;
		public static FactoryPersona GetInstance()
		{
			if (_factory == null)
				_factory = new FactoryPersona();
			return _factory;
		}
		#region Business
		public PersonaBE CreateBusiness(DataModel.personas entity)
		{
			PersonaBE be;
			if (entity!=null)
			{
				be = new PersonaBE()
				{
					id_persona=entity.id_persona,
					id_plan=entity.id_plan,
					apellido=entity.apellido,
					nombre=entity.nombre,
					direccion=entity.direccion,
					fecha_nac=entity.fecha_nac,
					legajo=entity.legajo,
					telefono=entity.telefono,
					tipo_persona=entity.tipo_persona,
					estado=entity.estado
				};
				be.Usuarios = new List<UsuarioBE>();
				if (entity.usuarios!=null)
				{
					foreach (var item in entity.usuarios)
					{
						be.Usuarios.Add(FactoryUsuario.GetInstance().CreateBusiness(item));
					}
				}
				return be;
			}
			return be = new PersonaBE();
		}
		#endregion

		#region Entity
		public DataModel.personas CreateEntity(PersonaBE be)
		{
            DataModel.personas entity;
			if (be != null)
			{
				entity = new DataModel.personas()
				{
					id_persona = be.id_persona,
					id_plan = be.id_plan,
					apellido = be.apellido,
					nombre = be.nombre,
					direccion = be.direccion,
					fecha_nac = be.fecha_nac,
					legajo = be.legajo,
					telefono = be.telefono,
					tipo_persona = be.tipo_persona,
					estado = be.estado
				};
				entity.usuarios = new List<DataModel.usuarios>();
				if (entity.usuarios != null)
				{
					foreach (var item in be.Usuarios)
					{
						entity.usuarios.Add(FactoryUsuario.GetInstance().CreateEntity(item));
					}
				}
				return entity;
			}
			return entity = new DataModel.personas();
		}
		#endregion
	}
}
