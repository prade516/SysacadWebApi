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
using DataModel;
using SolveApi.Enum;
using SolveApi.Extention;

namespace BusinessServices.Services
{
	public class Alumnos_InscripcionServices : IAlumnos_InscripcionServices
	{
		#region Member
		private readonly UnitOfWork _unitOfWork;
		#endregion

		#region Constructor
		public Alumnos_InscripcionServices(UnitOfWork punte)
		{
			_unitOfWork = punte;
		}
		#endregion

		public long Create(Alumnos_InscripcionBE Be)
		{
			if (Be != null)
			{
                DataModel.alumnos_inscripciones entity = Factory.FactoryAlumnos_Inscripcion.GetInstance().CreateEntity(Be);
				_unitOfWork.Alumnos_InscripcionesRepository.Insert(entity);
				_unitOfWork.Commit();

				return entity.id_inscripcion;
			}
			else
			{
				throw new ApiBusinessException(1012, "No se pudo completar la inscripcion", System.Net.HttpStatusCode.NotFound, "Http");
			}
		}

		public bool Delete(int Id)
		{
			var flag = false;
			try
			{
				Expression<Func<DataModel.alumnos_inscripciones, Boolean>> predicate = x => x.estado == (Int32)StateEnum.Alta && x.id_inscripcion == Id;
				var entity = _unitOfWork.Alumnos_InscripcionesRepository.GetOneByFilters(predicate, null);
				if (entity == null)
					throw new ApiBusinessException(1012, "No se pudo Dar de baja a la inscripcion", System.Net.HttpStatusCode.NotFound, "Http");

				entity.estado = (Int32)StateEnum.Baja;
				_unitOfWork.Alumnos_InscripcionesRepository.Delete(entity, new List<string>() { "estado" });
				_unitOfWork.Commit();

				flag = true;
				return flag;

			}
			catch (Exception ex)
			{
				throw HandlerErrorExceptions.GetInstance().RunCustomExceptions(ex);
			}
		}

		public List<Alumnos_InscripcionBE> GetAll(int state, int page, int pageSize, string orderBy, string ascending, ref int count, int idalumno, Int32 id_curso)
		{
			try
			{
				Expression<Func<DataModel.alumnos_inscripciones, Boolean>> predicate = x => x.estado == state 
				&&((x.id_alumno==idalumno)||(idalumno==0))
				&&((x.id_curso==id_curso)||(id_curso==0))
				&& ((x.id_alumno == idalumno && x.id_curso == id_curso) || (idalumno == 0 || id_curso == 0));
				IQueryable<DataModel.alumnos_inscripciones> entity = _unitOfWork.Alumnos_InscripcionesRepository.GetAllByFilters(predicate, new string[] { "cursos","personas" });
				count = entity.Count();
				var skipAmount = 0;

				if (page > 0)
					skipAmount = pageSize * (page - 1);

				entity = entity
					.OrderByPropertyOrField(orderBy, ascending)
					.Skip(skipAmount)
					.Take(pageSize);

				List<Alumnos_InscripcionBE> be = new List<Alumnos_InscripcionBE>();
				foreach (var item in entity)
				{
					be.Add(Factory.FactoryAlumnos_Inscripcion.GetInstance().CreateBusiness(item));
				}
				return be;
			}
			catch (Exception ex)
			{
				throw HandlerErrorExceptions.GetInstance().RunCustomExceptions(ex);
			}
		}

		public Alumnos_InscripcionBE GetById(int Id)
		{
			try
			{
				Expression<Func<DataModel.alumnos_inscripciones, Boolean>> predicate = x => x.estado == (Int32)StateEnum.Alta && x.id_inscripcion == Id;
				var entity = _unitOfWork.Alumnos_InscripcionesRepository.GetOneByFilters(predicate,null);
				if (entity != null)
				{
					return Factory.FactoryAlumnos_Inscripcion.GetInstance().CreateBusiness(entity);
				}
				else
					throw new ApiBusinessException(1012, "No se encuentra disponible es materia para inscribir", System.Net.HttpStatusCode.NotFound, "Http");
			}
			catch (Exception ex)
			{
				throw HandlerErrorExceptions.GetInstance().RunCustomExceptions(ex);
			}
		}

		public bool Update(long Id, Alumnos_InscripcionBE Be)
		{
			try
			{
				var flag = false;

				if (Be != null)
				{
					var entity = Factory.FactoryAlumnos_Inscripcion.GetInstance().CreateEntity(Be);
										
					_unitOfWork.Alumnos_InscripcionesRepository.Update(entity, new List<string>() { "id_alumno", "id_curso", "condicion", "nota" });
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
