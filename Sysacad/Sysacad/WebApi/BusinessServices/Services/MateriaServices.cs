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
using SolveApi.Enum;
using System.Linq.Expressions;
using SolveApi.Extention;

namespace BusinessServices.Services
{
	public class MateriaServices : IMateriaServicescs
	{
		#region Member
		private readonly UnitOfWork _puente;
		#endregion
		#region Constructor
		public MateriaServices(UnitOfWork punte)
		{
			_puente = punte;
		}
		#endregion
		public long Create(MateriaBE Be)
		{
			try
			{
				if (Be != null)
				{
					DataModel.materias entity = Factory.FactoryMateria.GetInstance().CreateEntity(Be);
					_puente.MateriaRepository.Insert(entity);
					_puente.Commit();

					return entity.id_materia;
				}
				else
				{
					throw new ApiBusinessException(1012, "No se pudo crear la materia", System.Net.HttpStatusCode.NotFound, "Http");
				}
			}
			catch (Exception ex)
			{
				throw HandlerErrorExceptions.GetInstance().RunCustomExceptions(ex);
			}
		}

		public bool Delete(long Id)
		{
			var flag = false;
			try
			{
				Expression<Func<DataModel.materias, Boolean>> predicate = x => x.estado == (Int32)StateEnum.Alta && x.id_materia == Id;
				var entity = _puente.MateriaRepository.GetOneByFilters(predicate, new string[] { "Planmateria" });
				if (entity == null)
					throw new ApiBusinessException(1012, "No se pudo Dar de baja a ese materia", System.Net.HttpStatusCode.NotFound, "Http");
				
				entity.estado = (Int32)StateEnum.Baja;
				_puente.MateriaRepository.Delete(entity, new List<string>() { "estado" });
				_puente.Commit();

				flag = true;
				return flag;

			}
			catch (Exception ex)
			{
				throw HandlerErrorExceptions.GetInstance().RunCustomExceptions(ex);
			}
		}

		public List<MateriaBE> GetAll(int state, int page, int pageSize, string orderBy, string ascending, ref int count)
		{
			try
			{
				Expression<Func<DataModel.materias, Boolean>> predicate = x => x.estado == state;
				IQueryable<DataModel.materias> entity = _puente.MateriaRepository.GetAllByFilters(predicate, new string[] { "Planmateria" });
				count = entity.Count();
				var skipAmount = 0;

				if (page > 0)
					skipAmount = pageSize * (page - 1);

				entity = entity
					.OrderByPropertyOrField(orderBy, ascending)
					.Skip(skipAmount)
					.Take(pageSize);

				List<MateriaBE> BE = new List<MateriaBE>();
				foreach (var item in entity)
				{
					BE.Add(Factory.FactoryMateria.GetInstance().CreateBusiness(item));
				}
				return BE;
			}
			catch (Exception ex)
			{
				throw HandlerErrorExceptions.GetInstance().RunCustomExceptions(ex);
			}
		}

		public MateriaBE GetById(long Id)
		{
			try
			{
				Expression<Func<DataModel.materias, Boolean>> predicate = x => x.estado == (Int32)StateEnum.Alta && x.id_materia == Id;
				var entity = _puente.MateriaRepository.GetOneByFilters(predicate, new string[] { "Planmateria" });
				if (entity != null)
				{
					return Factory.FactoryMateria.GetInstance().CreateBusiness(entity);
				}
				else
					throw new ApiBusinessException(1012, "No se encuentra disponible esa materia", System.Net.HttpStatusCode.NotFound, "Http");
			}
			catch (Exception ex)
			{
				throw HandlerErrorExceptions.GetInstance().RunCustomExceptions(ex);
			}
		}

		public bool Update(long Id, MateriaBE Be)
		{
			try
			{
				var flag = false;

				if (Be != null)
				{
					var entity = Factory.FactoryMateria.GetInstance().CreateEntity(Be);
					
					_puente.MateriaRepository.Update(entity, new List<string>() { "desc_materia", "hs_semanales","hs_totales" });
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
