using BusinessServices.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using DataModel.UnitOfWork;
using SolveApi.Error;
using System.Linq.Expressions;
using SolveApi.Enum;
using DataModel;
using SolveApi.Extention;

namespace BusinessServices.Services
{
	public class PersonaServices : IPersonaServices
	{
		#region Member
		private readonly UnitOfWork _puente;
		#endregion
		#region Constructor
		public PersonaServices(UnitOfWork punte)
		{
			_puente = punte;
		}
		#endregion
		public long Create(PersonaBE Be)
		{
			try
			{
				if (Be != null)
				{
					DataModel.personas entity = Factory.FactoryPersona.GetInstance().CreateEntity(Be);
					_puente.PersonaRepository.Insert(entity);
					_puente.Commit();
					return entity.id_persona;
				}
				else
				{
					throw new ApiBusinessException(1012, "No se pudo crear el plan", System.Net.HttpStatusCode.NotFound, "Http");
				}
			}
			catch (Exception ex)
			{
				throw HandlerErrorExceptions.GetInstance().RunCustomExceptions(ex);
			}
		}

		public bool Delete(int Id)
		{
			var flag = false;
			try
			{
				Expression<Func<personas, Boolean>> predicate = x => x.estado == (Int32)StateEnum.Alta && x.id_persona == Id;
				var entity = _puente.PersonaRepository.GetOneByFilters(predicate, new string[] { "Usuarios.modulo_usuario" });
				if (entity == null)
					throw new ApiBusinessException(1012, "No se pudo Dar de baja a ese persona", System.Net.HttpStatusCode.NotFound, "Http");
				if (entity.Usuarios != null)
				{
					foreach (var item in entity.Usuarios)
					{
						foreach (var modusuario in item.modulo_usuario)
						{							
							 modusuario.estado= (Int32)StateEnum.Baja;
							_puente.Modulo_Usuario_repository.Delete(modusuario, new List<string>() { "estado" });
						}
						item.estado = (Int32)StateEnum.Baja;
						_puente.UsuarioRepository.Delete(item, new List<string>() {"estado"});
					}
				}
				 entity.estado = (Int32)StateEnum.Baja;
				_puente.PersonaRepository.Delete(entity, new List<string>() {"estado"});
				_puente.Commit();

				flag = true;
				return flag;

			}
			catch (Exception ex)
			{
				throw HandlerErrorExceptions.GetInstance().RunCustomExceptions(ex);
			}
		}

		public List<PersonaBE> GetAll(int state, int page, int idconectado, int pageSize, string orderBy, string ascending, ref int count, Int32 tipo_persona)
		{
			try
			{
				Expression<Func<personas, Boolean>> predicate = x => (x.estado == state||state==0) && (x.id_persona==idconectado|| idconectado==0) && (x.tipo_persona==tipo_persona || tipo_persona==0);
				IQueryable<DataModel.personas> entity = _puente.PersonaRepository.GetAllByFilters(predicate, null /*new string[] { "Usuarios.modulo_usuario" }*/);
				count = entity.Count();
				var skipAmount = 0;

				if (page > 0)
					skipAmount = pageSize * (page - 1);

				entity = entity
					.OrderByPropertyOrField(orderBy, ascending)
					.Skip(skipAmount)
					.Take(pageSize);

				List<PersonaBE> be = new List<PersonaBE>();
				foreach (var item in entity)
				{
					be.Add(Factory.FactoryPersona.GetInstance().CreateBusiness(item));
				}
				return be;
			}
			catch (Exception ex)
			{
				throw HandlerErrorExceptions.GetInstance().RunCustomExceptions(ex);
			}
		}

		public PersonaBE GetById(int Id)
		{
			try
			{
				Expression<Func<personas, Boolean>> predicate = x => x.estado == (Int32)StateEnum.Alta && x.id_persona == Id;
				var entity = _puente.PersonaRepository.GetOneByFilters(predicate, new string[] { "Usuarios.modulo_usuario" });
				if (entity != null)
				{
					return Factory.FactoryPersona.GetInstance().CreateBusiness(entity);
				}
				else
					throw new ApiBusinessException(1012, "No se encuentra disponible a esa persona", System.Net.HttpStatusCode.NotFound, "Http");
			}
			catch (Exception ex)
			{
				throw HandlerErrorExceptions.GetInstance().RunCustomExceptions(ex);
			}
		}

		public List<PersonaBE> Login(string usermane, string password)
		{
			try
			{
				var encrypt = SolveApi.Encriptacion.Encriptacion.GetInstance().EncryptKey(password);
				Expression<Func<personas, Boolean>> predicate = x => x.Usuarios.FirstOrDefault().estado == (Int32)StateEnum.Alta && x.Usuarios.FirstOrDefault().nombre_usuario==usermane && x.Usuarios.FirstOrDefault().clave== encrypt;
				IQueryable<DataModel.personas> entity = _puente.PersonaRepository.GetAllByFilters(predicate, new string[] { "Usuarios.modulo_usuario" });
				List<PersonaBE> be = new List<PersonaBE>();

				foreach (var item in entity)
				{
					be.Add(Factory.FactoryPersona.GetInstance().CreateBusiness(item));
				}
				return be;
			}
			catch (Exception ex)
			{
				throw HandlerErrorExceptions.GetInstance().RunCustomExceptions(ex);
			}
		}

		public bool Update(long Id, PersonaBE Be)
		{
			try
			{
				var flag = false;

				if (Be != null)
				{
					var entity = Factory.FactoryPersona.GetInstance().CreateEntity(Be);
					if (entity.Usuarios != null)
					{
						foreach (var item in entity.Usuarios)
						{
							if (item.modulo_usuario!=null)
							{
								foreach (var mod in item.modulo_usuario)
								{
									_puente.Modulo_Usuario_repository.Update(mod, new List<string>() { "id_modulo", "id_usuario","alta","baja","modificacion","consulta"});

								}
							}
							item.modulo_usuario = null;
							_puente.UsuarioRepository.Update(item, new List<string>() { "nombre_usuario", "clave","habilitado","email","cambia_clave" });
							
						}
					}
					entity.Usuarios = null;
					_puente.PersonaRepository.Update(entity, new List<string>() { "id_plan","nombre","apellido","direccion","telefono","fecha_nac","legajo","tipo_persona"});
					_puente.Commit();

					flag = true;
					return flag;
				}
				else
					throw new ApiBusinessException(1012, "No se pudo Modificar por que la entidad no esta completa", System.Net.HttpStatusCode.NotFound, "Http");

			}
			catch (Exception ex)
			{
				throw HandlerErrorExceptions.GetInstance().RunCustomExceptions(ex);
			}
		}

		public bool ChangePassword(long Id, UsuarioBE Be)
		{
			try
			{
				var flag = false;

				if (Be != null)
				{
					var usr = Factory.FactoryUsuario.GetInstance().CreateEntity(Be);
					_puente.UsuarioRepository.Update(usr, new List<string>() { "clave", "cambia_clave" });
					_puente.Commit();

					flag = true;
					return flag;
				}
				else
					throw new ApiBusinessException(1012, "No se pudo Modificar la contraseña", System.Net.HttpStatusCode.NotFound, "Http");

			}
			catch (Exception ex)
			{
				throw HandlerErrorExceptions.GetInstance().RunCustomExceptions(ex);
			}
		}
	}
}
