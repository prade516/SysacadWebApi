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
	public class ComisionServices : IComisionServices
	{
		#region Member
		private readonly UnitOfWork _puente;
		#endregion
		#region Constructor
		public ComisionServices(UnitOfWork punte)
		{
			_puente = punte;
		}
		#endregion
		public long Create(ComisionBE Be)
		{
			try
			{
				if (Be != null)
				{
					DataModel.comisiones entity = Factory.FactoryComision.GetInstance().CreateEntity(Be);
					_puente.ComisionesRepository.Insert(entity);
					_puente.Commit();

					return entity.id_comision;
				}
				else
				{
					throw new ApiBusinessException(1012, "No se pudo crear la comision", System.Net.HttpStatusCode.NotFound, "Http");
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
				Expression<Func<DataModel.comisiones, Boolean>> predicate = x => x.estado == (Int32)StateEnum.Alta && x.id_comision == Id;
				var entity = _puente.ComisionesRepository.GetOneByFilters(predicate, new string[] { "Plancomision" });
				if (entity == null)
					throw new ApiBusinessException(1012, "No se pudo Dar de baja a la comision", System.Net.HttpStatusCode.NotFound, "Http");
				
				entity.estado = (Int32)StateEnum.Baja;
				_puente.ComisionesRepository.Delete(entity, new List<string>() { "estado" });
				_puente.Commit();

				flag = true;
				return flag;

			}
			catch (Exception ex)
			{
				throw HandlerErrorExceptions.GetInstance().RunCustomExceptions(ex);
			}
		}

		public List<ComisionBE> GetAll(int state, int page, int pageSize, string orderBy, string ascending, ref int count)
		{
			try
			{
				Expression<Func<DataModel.comisiones, Boolean>> predicate = x => x.estado == state;
				IQueryable<DataModel.comisiones> entity = _puente.ComisionesRepository.GetAllByFilters(predicate, new string[] { "Plancomision" });
				count = entity.Count();
				var skipAmount = 0;

				if (page > 0)
					skipAmount = pageSize * (page - 1);

				entity = entity
					.OrderByPropertyOrField(orderBy, ascending)
					.Skip(skipAmount)
					.Take(pageSize);

				List<ComisionBE> comision = new List<ComisionBE>();
				foreach (var item in entity)
				{
					comision.Add(Factory.FactoryComision.GetInstance().CreateBusiness(item));
				}
				return comision;
			}
			catch (Exception ex)
			{
				throw HandlerErrorExceptions.GetInstance().RunCustomExceptions(ex);
			}
		}

		public ComisionBE GetById(int Id)
		{
			try
			{
				Expression<Func<DataModel.comisiones, Boolean>> predicate = x => x.estado == (Int32)StateEnum.Alta && x.id_comision == Id;
				var entity = _puente.ComisionesRepository.GetOneByFilters(predicate, new string[] { "Plancomision" });
				if (entity != null)
				{
					return Factory.FactoryComision.GetInstance().CreateBusiness(entity);
				}
				else
					throw new ApiBusinessException(1012, "No se encuentra disponible la comision", System.Net.HttpStatusCode.NotFound, "Http");
			}
			catch (Exception ex)
			{
				throw HandlerErrorExceptions.GetInstance().RunCustomExceptions(ex);
			}
		}

		public bool Update(long Id, ComisionBE Be)
		{
			try
			{
				var flag = false;

				if (Be != null)
				{
					var entity = Factory.FactoryComision.GetInstance().CreateEntity(Be);
                    
					_puente.ComisionesRepository.Update(entity, new List<string>() { "desc_comision", "anio_especialidad" });
					_puente.Commit();

					flag = true;
					return flag;
				}
				else
					throw new ApiBusinessException(1012, "No se pudo Modificar la comision", System.Net.HttpStatusCode.NotFound, "Http");

			}
			catch (Exception ex)
			{
				throw HandlerErrorExceptions.GetInstance().RunCustomExceptions(ex);
			}
		}
	}
}
