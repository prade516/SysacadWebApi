using BusinessServices.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using DataModel.UnitOfWork;
using SolveApi.Error;
using SolveApi.Enum;
using DataModel;
using System.Linq.Expressions;
using SolveApi.Extention;

namespace BusinessServices.Services
{
	public class PlanServices : IPlanServices
	{
		#region Member
		private readonly UnitOfWork _puente;
		#endregion
		#region Constructor
		public PlanServices(UnitOfWork punte)
		{
			_puente = punte;
		}
		#endregion

		public long Create(PlanBE Be)
		{
			try
			{
				if (Be != null)
				{
					DataModel.planes entity = Factory.FactoryPlan.GetInstance().CreateEntity(Be);
					_puente.Planrepository.Insert(entity);
					_puente.Commit();

					return entity.id_plan;
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

		public bool Delete(Int32 Id)
		{
			var flag = false;
			try
			{
				Expression<Func<DataModel.planes, Boolean>> predicate = x => x.estado == (Int32)StateEnum.Alta && x.id_plan==Id;
				var plan = _puente.Planrepository.GetOneByFilters(predicate, null /*new string[] { "Planespecialidad" }*/);
				if (plan == null)
					throw new ApiBusinessException(1012, "No se pudo Dar de baja a ese plan", System.Net.HttpStatusCode.NotFound, "Http");
                
				plan.estado = (Int32)StateEnum.Baja;
				_puente.Planrepository.Delete(plan, new List<string>() { "estado" });
				_puente.Commit();

				flag = true;
				return flag;

			}
			catch (Exception ex)
			{
				throw HandlerErrorExceptions.GetInstance().RunCustomExceptions(ex);
			}
		}

		public List<PlanBE> GetAll(int state, int page, int pageSize, string orderBy, string ascending, ref int count)
		{
			try
			{
				Expression<Func<DataModel.planes, Boolean>> predicate = x => x.estado == state && x.desc_plan != "none";
				IQueryable<DataModel.planes> entity = _puente.Planrepository.GetAllByFilters(predicate, new string[] { "especialidades" });
				count = entity.Count();
				var skipAmount = 0;

				if (page > 0)
					skipAmount = pageSize * (page - 1);

				entity = entity
					.OrderByPropertyOrField(orderBy, ascending)
					.Skip(skipAmount)
					.Take(pageSize);

				List<PlanBE> plan = new List<PlanBE>();
				foreach (var item in entity)
				{
					plan.Add(Factory.FactoryPlan.GetInstance().CreateBusiness(item));
				}
				return plan;
			}
			catch (Exception ex)
			{
				throw HandlerErrorExceptions.GetInstance().RunCustomExceptions(ex);
			}
		}

		public PlanBE GetById(long Id)
		{
			try
			{
                if (Id == 0)
                    throw new ApiBusinessException(1012, "No se encuentra disponible el plan.", System.Net.HttpStatusCode.NotFound, "Http");

                Expression<Func<DataModel.planes, Boolean>> predicate = x => x.estado == (Int32)StateEnum.Alta && x.id_plan == Id;
				var entity = _puente.Planrepository.GetOneByFilters(predicate, new string[] { "especialidades" });
				if (entity != null)
				{
					return Factory.FactoryPlan.GetInstance().CreateBusiness(entity);
				}
				else
					throw new ApiBusinessException(1012, "No se encuentra disponible el plan.", System.Net.HttpStatusCode.NotFound, "Http");
			}
			catch (Exception ex)
			{
				throw HandlerErrorExceptions.GetInstance().RunCustomExceptions(ex);
			}
		}

		public bool Update(long Id, PlanBE Be)
		{
			try
			{
				var flag = false;

				if (Be != null)
				{
					var entity = Factory.FactoryPlan.GetInstance().CreateEntity(Be);
					
					_puente.Planrepository.Update(entity, new List<string>() { "desc_plan"});
					_puente.Commit();

					flag = true;
					return flag;
				}
				else
					throw new ApiBusinessException(1012, "No se pudo Modificar el plan", System.Net.HttpStatusCode.NotFound, "Http");

			}
			catch (Exception ex)
			{
				throw HandlerErrorExceptions.GetInstance().RunCustomExceptions(ex);
			}
		}
	}
}
