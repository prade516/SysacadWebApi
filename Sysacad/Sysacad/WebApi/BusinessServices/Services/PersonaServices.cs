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
using SolveApi.Tipo_de_usuario;

namespace BusinessServices.Services
{
	public class PersonaServices : IPersonaServices
	{
		#region Member
		private readonly UnitOfWork _unitOfWork;
		#endregion
		#region Constructor
		public PersonaServices(UnitOfWork punte)
		{
			_unitOfWork = punte;
		}
		#endregion

		public long Create(PersonaBE Be)
		{
			try
			{
				if (Be != null)
				{
                    Be.legajo = GetLastLegajo();
                    Be.Usuarios[0].nombre_usuario = GetLastLegajo().ToString();
                    if (TypeUser.GetInstance().GetTyperUser(Be.tipo_persona)== 1 || TypeUser.GetInstance().GetTyperUser(Be.tipo_persona) == 2) 
                          Be.id_plan = 20;    
                 
                    DataModel.personas entity = Factory.FactoryPersona.GetInstance().CreateEntity(Be);

                    Expression<Func<DataModel.personas, Boolean>> predicate = x => (x.telefono == entity.telefono);
                    DataModel.personas verify = _unitOfWork.PersonaRepository.GetOneByFilters(predicate, new string[] { "usuarios.modulos_usuarios" });
                    if (verify!=null)
                        throw new ApiBusinessException(1012, "Ya existe un usuario con ese numero de telefono", System.Net.HttpStatusCode.Forbidden, "Http");

                    var email = entity.usuarios.FirstOrDefault().email.ToString();
                    Expression<Func<DataModel.usuarios, Boolean>> predicateuser = x => (x.email == email);
                    DataModel.usuarios usur = _unitOfWork.UsuarioRepository.GetOneByFilters(predicateuser, new string[] { "modulos_usuarios" });
                    if (usur != null)
                        throw new ApiBusinessException(1012, "Ya existe un usuario con ese email", System.Net.HttpStatusCode.Forbidden, "Http");

                    _unitOfWork.PersonaRepository.Insert(entity);
					_unitOfWork.Commit();
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
				Expression<Func<DataModel.personas, Boolean>> predicate = x => x.estado == (Int32)StateEnum.Alta && x.id_persona == Id;
				var entity = _unitOfWork.PersonaRepository.GetOneByFilters(predicate, new string[] { "usuarios.modulos_usuarios" });
				if (entity == null)
					throw new ApiBusinessException(1012, "No se pudo Dar de baja a ese persona", System.Net.HttpStatusCode.NotFound, "Http");
				if (entity.usuarios != null)
				{
					foreach (var item in entity.usuarios)
					{
						foreach (var modusuario in item.modulos_usuarios)
						{							
							 modusuario.estado= (Int32)StateEnum.Baja;
							_unitOfWork.Modulo_Usuario_repository.Delete(modusuario, new List<string>() { "estado" });
						}
						item.estado = (Int32)StateEnum.Baja;
						_unitOfWork.UsuarioRepository.Delete(item, new List<string>() {"estado"});
					}
				}
				 entity.estado = (Int32)StateEnum.Baja;
				_unitOfWork.PersonaRepository.Delete(entity, new List<string>() {"estado"});
				_unitOfWork.Commit();

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
				Expression<Func<DataModel.personas, Boolean>> predicate = x => (x.estado == state||state==0) && (x.id_persona==idconectado|| idconectado==0) && (x.tipo_persona==tipo_persona || tipo_persona==0);
				IQueryable<DataModel.personas> entity = _unitOfWork.PersonaRepository.GetAllByFilters(predicate, new string[] { "usuarios.modulos_usuarios" });
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
				Expression<Func<DataModel.personas, Boolean>> predicate = x => x.estado == (Int32)StateEnum.Alta && x.id_persona == Id;
				var entity = _unitOfWork.PersonaRepository.GetOneByFilters(predicate, new string[] { "usuarios.modulos_usuarios" });
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
				Expression<Func<DataModel.personas, Boolean>> predicate = x => x.usuarios.FirstOrDefault().estado == (Int32)StateEnum.Alta && x.usuarios.FirstOrDefault().nombre_usuario==usermane && x.usuarios.FirstOrDefault().clave== encrypt;
				IQueryable<DataModel.personas> entity = _unitOfWork.PersonaRepository.GetAllByFilters(predicate, new string[] { "usuarios.modulos_usuarios" });
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
                    if (TypeUser.GetInstance().GetTyperUser(Be.tipo_persona) == 1 || TypeUser.GetInstance().GetTyperUser(Be.tipo_persona) == 2)
                        Be.id_plan = 20;
                    var entity = Factory.FactoryPersona.GetInstance().CreateEntity(Be);
					if (entity.usuarios != null)
					{
						foreach (var item in entity.usuarios)
						{
							if (item.modulos_usuarios!=null)
							{
								foreach (var mod in item.modulos_usuarios)
								{
									_unitOfWork.Modulo_Usuario_repository.Update(mod, new List<string>() { "id_modulo", "id_usuario","alta","baja","modificacion","consulta"});

								}
							}
							item.modulos_usuarios = null;
							//_unitOfWork.UsuarioRepository.Update(item, new List<string>() { "nombre_usuario", "clave","habilitado","email","cambia_clave" });
							
						}
					}
					entity.usuarios = null;
					_unitOfWork.PersonaRepository.Update(entity, new List<string>() { "id_plan","nombre","apellido","direccion","telefono","fecha_nac","legajo","tipo_persona"});
					_unitOfWork.Commit();

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
					_unitOfWork.UsuarioRepository.Update(usr, new List<string>() { "clave", "cambia_clave" });
					_unitOfWork.Commit();

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

        #region LastLegajo
        private Int32 GetLastLegajo()
        {
            int state = 0;
            var lastlegajo = 0;

            Expression<Func<DataModel.personas, Boolean>> predicate = x => (x.estado == state || state == 0);

            List<DataModel.personas> resultado = _unitOfWork.PersonaRepository.GetAllByFilters(predicate).ToList();
            if (resultado.Count() != 0)
                lastlegajo = resultado.LastOrDefault().legajo + 1;
            else
                lastlegajo = 100;
            return lastlegajo;
        }
        #endregion
    }
}
