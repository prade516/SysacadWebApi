using BusinessServices.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;
using DataModel.UnitOfWork;
using SolveApi.Error;
using SolveApi.Enum;
using System.Linq.Expressions;
using DataModel;
using SolveApi.Extention;

namespace BusinessServices.Services
{
	public class EspecialidadService : IEspecialidadServices
	{
		#region Member
		private readonly UnitOfWork _puente;
		#endregion
		#region Constructor
		public EspecialidadService(UnitOfWork punte)
		{
			_puente = punte;
		}
		#endregion
		public long Create(EspecialidadBE Be, string username)
		{
			try
			{
				if (Be != null)
				{
					DataModel.especialidades entity = Factory.FactoryEspecialidad.CreateEntity(Be);
					_puente.EspecialidadRepository.Insert(entity);
					_puente.Commit();

					return entity.id_especialidad;
				}
				else
				{
					throw new ApiBusinessException(1012, "No se pudo crear la especialidad", System.Net.HttpStatusCode.NotFound, "Http");
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
					var especialidad = _puente.EspecialidadRepository.GetById(Id);
					if (especialidad == null)
						throw new ApiBusinessException(1012, "No se pudo Dar de baja a esa especialidad", System.Net.HttpStatusCode.NotFound, "Http");
					
					 especialidad.estado = (Int32)StateEnum.Baja;
					_puente.EspecialidadRepository.Delete(especialidad, new List<string>() { "estado" });
					_puente.Commit();

					flag = true;
					return flag;

			}
			catch (Exception ex)
			{
				throw HandlerErrorExceptions.GetInstance().RunCustomExceptions(ex);
			}
		}

		public List<EspecialidadBE> GetAll(int estado, int page, int pageSize, string orderBy, string ascending, ref int count)
		{
			try
			{
				Expression<Func<especialidades, Boolean>> predicate = x => x.estado == estado;
				IQueryable<especialidades> especialidadentity = _puente.EspecialidadRepository.GetAllByFilters(predicate, null);
				count = especialidadentity.Count();
				var skipAmount = 0;

				if (page > 0)
					skipAmount = pageSize * (page - 1);

				especialidadentity = especialidadentity
					.OrderByPropertyOrField(orderBy, ascending)
					.Skip(skipAmount)
					.Take(pageSize);

				List<EspecialidadBE> especialidad = new List<EspecialidadBE>();
				foreach (var item in especialidadentity)
				{
					especialidad.Add(Factory.FactoryEspecialidad.CreateBusiness(item));
				}
				return especialidad;
			}
			catch (Exception ex)
			{
				throw HandlerErrorExceptions.GetInstance().RunCustomExceptions(ex);
			}
		}		
		public EspecialidadBE GetById(long Id)
		{
			try
			{
				Expression<Func<especialidades, Boolean>> predicate = x => x.estado == (Int32)StateEnum.Alta && x.id_especialidad == Id;
				var especialidadentity = _puente.EspecialidadRepository.GetOneByFilters(predicate, null);
				if (especialidadentity != null)
				{
					return Factory.FactoryEspecialidad.CreateBusiness(especialidadentity);
				}
				else
					throw new ApiBusinessException(1012, "No se encuentra disponible esa especialidad", System.Net.HttpStatusCode.NotFound, "Http");
			}
			catch (Exception ex)
			{
				throw HandlerErrorExceptions.GetInstance().RunCustomExceptions(ex);
			}
		}

		public bool Update(long Id, EspecialidadBE Be)
		{
			try
			{
				var flag = false;

				if (Be != null)
				{
					var especialidadentity = Factory.FactoryEspecialidad.CreateEntity(Be);
					_puente.EspecialidadRepository.Update(especialidadentity, new List<string>() { "desc_especialidad" });
					_puente.Commit();

					flag = true;
					return flag;
				}
				else
					throw new ApiBusinessException(1012, "No se pudo Modificar a esa especialidad", System.Net.HttpStatusCode.NotFound, "Http");

			}
			catch (Exception ex)
			{
				throw HandlerErrorExceptions.GetInstance().RunCustomExceptions(ex);
			}
		}
	}
}
