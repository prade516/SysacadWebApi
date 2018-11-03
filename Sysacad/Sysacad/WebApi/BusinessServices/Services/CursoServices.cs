﻿using BusinessServices.Interface;
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
	public class CursoServices : ICursoServices
	{
		#region Member
		private readonly UnitOfWork _puente;
		#endregion
		#region Constructor
		public CursoServices(UnitOfWork punte)
		{
			_puente = punte;
		}
		#endregion
		public long Create(CursoBE Be)
		{
			try
			{
				if (Be != null)
				{
					DataModel.cursos entity = Factory.FactoryCurso.GetInstance().CreateEntity(Be);
					_puente.CursoRepository.Insert(entity);
					_puente.Commit();

					return entity.id_curso;
				}
				else
				{
					throw new ApiBusinessException(1012, "No se pudo crear el curso", System.Net.HttpStatusCode.NotFound, "Http");
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
				Expression<Func<DataModel.cursos, Boolean>> predicate = x =>x.id_comision == Id;
				var entity = _puente.CursoRepository.GetOneByFilters(predicate, new string[] { "docentes_cursos"});
			
				if (entity == null)
					throw new ApiBusinessException(1012, "No se pudo Dar de baja a ese curso", System.Net.HttpStatusCode.NotFound, "Http");
				if (entity.docentes_cursos!=null)
				{
					foreach (var item in entity.docentes_cursos)
					{
						item.estado= (Int32)StateEnum.Baja;
						_puente.Docentes_CursosRepository.Delete(item, new List<string>() { "estado" });
					}
				}
				entity.estado = (Int32)StateEnum.Baja;
				_puente.CursoRepository.Delete(entity, new List<string>() { "estado" });
				_puente.Commit();

				flag = true;
				return flag;

			}
			catch (Exception ex)
			{
				throw HandlerErrorExceptions.GetInstance().RunCustomExceptions(ex);
			}
		}

		public List<CursoBE> GetAll(int state, int page, int pageSize, string orderBy, string ascending, ref int count)
		{
			try
			{
				Expression<Func<DataModel.cursos, Boolean>> predicate = x => x.estado == state;
				IQueryable<DataModel.cursos> entity = _puente.CursoRepository.GetAllByFilters(predicate, new string[] { "comisiones", "docentes_cursos", "alumnos_inscripciones", "materias" });
				count = entity.Count();
				var skipAmount = 0;

				if (page > 0)
					skipAmount = pageSize * (page - 1);

				entity = entity
					.OrderByPropertyOrField(orderBy, ascending)
					.Skip(skipAmount)
					.Take(pageSize);

				List<CursoBE> be = new List<CursoBE>();
				foreach (var item in entity)
				{
					be.Add(Factory.FactoryCurso.GetInstance().CreateBusiness(item));
				}
				return be;
			}
			catch (Exception ex)
			{
				throw HandlerErrorExceptions.GetInstance().RunCustomExceptions(ex);
			}
		}

		public CursoBE GetById(long Id)
		{
			try
			{
				Expression<Func<DataModel.cursos, Boolean>> predicate = x => x.estado == (Int32)StateEnum.Alta && x.id_curso == Id;
				var entity = _puente.CursoRepository.GetOneByFilters(predicate, new string[] { "comisiones", "docentes_cursos", "alumnos_inscripciones", "materias" });
				if (entity != null)
				{
					return Factory.FactoryCurso.GetInstance().CreateBusiness(entity);
				}
				else
					throw new ApiBusinessException(1012, "No se encuentra disponible ese curso", System.Net.HttpStatusCode.NotFound, "Http");
			}
			catch (Exception ex)
			{
				throw HandlerErrorExceptions.GetInstance().RunCustomExceptions(ex);
			}
		}

		public bool Update(long Id, CursoBE Be)
		{
			try
			{
				var flag = false;

				if (Be != null)
				{
					var entity = Factory.FactoryCurso.GetInstance().CreateEntity(Be);
					if (entity.docentes_cursos != null)
					{
						foreach (var item in entity.docentes_cursos)
						{
							_puente.Docentes_CursosRepository.Update(item, new List<string>() { "id_docente","id_curso", "cargo"});
						}
					}
					entity.docentes_cursos = null;
					_puente.CursoRepository.Update(entity, new List<string>() { "id_materia", "id_comision", "anio_calendario", "cupo" });
					_puente.Commit();

					flag = true;
					return flag;
				}
				else
					throw new ApiBusinessException(1012, "No se pudo Modificar a ese curso", System.Net.HttpStatusCode.NotFound, "Http");

			}
			catch (Exception ex)
			{
				throw HandlerErrorExceptions.GetInstance().RunCustomExceptions(ex);
			}
		}
	}
}
