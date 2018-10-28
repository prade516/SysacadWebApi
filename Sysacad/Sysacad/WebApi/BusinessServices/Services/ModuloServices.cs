using BusinessServices.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using DataModel.UnitOfWork;
using SolveApi.Error;
using DataModel;
using System.Linq.Expressions;
using SolveApi.Enum;
using SolveApi.Extention;

namespace BusinessServices.Services
{
	public class ModuloServices : IModuloServices
	{
		#region Member
		private readonly UnitOfWork _unitOfWork;
		#endregion
		#region Constructor
		public ModuloServices(UnitOfWork punte)
		{
			_unitOfWork = punte;
		}
		#endregion
		public long Create(ModuloBE Be)
		{
			try
			{
				if (Be != null)
				{
					DataModel.modulos entity = Factory.FactoryModulo.GetInstance().CreateEntity(Be);
					_unitOfWork.ModuloRepository.Insert(entity);
					_unitOfWork.Commit();

					return entity.id_modulo;
				}
				else
				{
					throw new ApiBusinessException(1012, "No se pudo crear el modulo", System.Net.HttpStatusCode.NotFound, "Http");
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
				Expression<Func<DataModel.modulos, Boolean>> predicate = x => x.estado == (Int32)StateEnum.Alta && x.id_modulo == Id;
				var entity = _unitOfWork.ModuloRepository.GetOneByFilters(predicate,null);
				if (entity == null)
					throw new ApiBusinessException(1012, "No se pudo Dar de baja a ese modulo", System.Net.HttpStatusCode.NotFound, "Http");

				entity.estado = (Int32)StateEnum.Baja;
				_unitOfWork.ModuloRepository.Delete(entity, new List<string>() { "estado" });
				_unitOfWork.Commit();

				flag = true;
				return flag;

			}
			catch (Exception ex)
			{
				throw HandlerErrorExceptions.GetInstance().RunCustomExceptions(ex);
			}
		}

		public List<ModuloBE> GetAll(int state, int page, int pageSize, string orderBy, string ascending, ref int count)
		{
			try
			{
				Expression<Func<DataModel.modulos, Boolean>> predicate = x => x.estado == state;
				IQueryable<DataModel.modulos> entity = _unitOfWork.ModuloRepository.GetAllByFilters(predicate, new string[] { "modulos_usuarios" });
				count = entity.Count();
				var skipAmount = 0;

				if (page > 0)
					skipAmount = pageSize * (page - 1);

				entity = entity
					.OrderByPropertyOrField(orderBy, ascending)
					.Skip(skipAmount)
					.Take(pageSize);

				List<ModuloBE> be = new List<ModuloBE>();
				foreach (var item in entity)
				{
					be.Add(Factory.FactoryModulo.GetInstance().CreateBusiness(item));
				}
				return be;
			}
			catch (Exception ex)
			{
				throw HandlerErrorExceptions.GetInstance().RunCustomExceptions(ex);
			}
		}

		public ModuloBE GetById(int Id)
		{
			try
			{
				Expression<Func<DataModel.modulos, Boolean>> predicate = x => x.estado == (Int32)StateEnum.Alta && x.id_modulo == Id;
				var entity = _unitOfWork.ModuloRepository.GetOneByFilters(predicate, new string[] { "modulos_usuarios" });
				if (entity != null)
				{
					return Factory.FactoryModulo.GetInstance().CreateBusiness(entity);
				}
				else
					throw new ApiBusinessException(1012, "No se encuentra disponible el modulo", System.Net.HttpStatusCode.NotFound, "Http");
			}
			catch (Exception ex)
			{
				throw HandlerErrorExceptions.GetInstance().RunCustomExceptions(ex);
			}
		}

		public bool Update(long Id, ModuloBE Be)
		{
			try
			{
				var flag = false;

				if (Be != null)
				{
					var entity = Factory.FactoryModulo.GetInstance().CreateEntity(Be);
					
					entity.modulos_usuarios = null;
					_unitOfWork.ModuloRepository.Update(entity, new List<string>() { "desc_modulo", "ejecuta" });
					_unitOfWork.Commit();

					flag = true;
					return flag;
				}
				else
					throw new ApiBusinessException(1012, "No se pudo Modificar el modulo", System.Net.HttpStatusCode.NotFound, "Http");

			}
			catch (Exception ex)
			{
				throw HandlerErrorExceptions.GetInstance().RunCustomExceptions(ex);
			}
		}
	}
}
