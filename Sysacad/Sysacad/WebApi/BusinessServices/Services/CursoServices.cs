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
	public class CursoServices : ICursoServices
	{
		#region Member
		private readonly UnitOfWork _unitOfWork;
		#endregion
		#region Constructor
		public CursoServices(UnitOfWork punte)
		{
			_unitOfWork = punte;
		}
		#endregion
		public long Create(CursoBE Be)
		{
			try
			{
				if (Be != null)
				{
					DataModel.cursos entity = Factory.FactoryCurso.GetInstance().CreateEntity(Be);
					_unitOfWork.CursoRepository.Insert(entity);
					_unitOfWork.Commit();

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
				var entity = _unitOfWork.CursoRepository.GetOneByFilters(predicate, new string[] { "docentes_cursos"});
			
				if (entity == null)
					throw new ApiBusinessException(1012, "No se pudo Dar de baja a ese curso", System.Net.HttpStatusCode.NotFound, "Http");
				if (entity.docentes_cursos!=null)
				{
					foreach (var item in entity.docentes_cursos)
					{
						item.estado= (Int32)StateEnum.Baja;
						_unitOfWork.Docentes_CursosRepository.Delete(item, new List<string>() { "estado" });
					}
				}
				entity.estado = (Int32)StateEnum.Baja;
				_unitOfWork.CursoRepository.Delete(entity, new List<string>() { "estado" });
				_unitOfWork.Commit();

				flag = true;
				return flag;

			}
			catch (Exception ex)
			{
				throw HandlerErrorExceptions.GetInstance().RunCustomExceptions(ex);
			}
		}

		public List<CursoBE> GetAll(int state, int page, int pageSize, string orderBy, string ascending, Int32 tipo,int idconectado, bool iscripcion, ref int count)
		{
            try
            {
                Expression<Func<DataModel.cursos, Boolean>> predicate = x => x.estado == state;
                IQueryable<DataModel.cursos> entity = _unitOfWork.CursoRepository.GetAllByFilters(predicate, new string[] { "comisiones", "docentes_cursos", "alumnos_inscripciones", "materias" });
                count = entity.Count();
                var skipAmount = 0;

                if (page > 0)
                    skipAmount = pageSize * (page - 1);

                entity = entity
                    .OrderByPropertyOrField(orderBy, ascending)
                    .Skip(skipAmount)
                    .Take(pageSize);

                List<CursoBE> be = new List<CursoBE>();
                List<CursoBE> Finallist = new List<CursoBE>();

                foreach (var item in entity)
                {
                    be.Add(Factory.FactoryCurso.GetInstance().CreateBusiness(item));
                }
               

                if (iscripcion)
                {
                    if (tipo == Convert.ToInt32(RolPersonEnum.Administrador))
                        Finallist = Administrador(be);
                    else if (tipo == Convert.ToInt32(RolPersonEnum.Alumno))
                        Finallist = Alumno(be, idconectado);
                    return Finallist;
                }
                else
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
				var entity = _unitOfWork.CursoRepository.GetOneByFilters(predicate, new string[] { "comisiones", "docentes_cursos", "alumnos_inscripciones", "materias" });
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
							_unitOfWork.Docentes_CursosRepository.Update(item, new List<string>() { "id_docente","id_curso", "cargo"});
						}
					}
					entity.docentes_cursos = null;
					_unitOfWork.CursoRepository.Update(entity, new List<string>() { "id_materia", "id_comision", "anio_calendario", "cupo" });
					_unitOfWork.Commit();

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

        #region Private method

        List<CursoBE> list;
        private List<CursoBE> Administrador(List<CursoBE> be)
        {
            var Listcursos = be.GroupBy(a => a.id_materia).Select(grp => grp.First());
            list = new List<CursoBE>();
            foreach (var item in Listcursos)
            {
                item.accion = "Inscribir";
                list.Add(item);
            }          
            return list;
        }

        private List<CursoBE> Alumno(List<CursoBE> be, Int32 IdConectado)
        {
            var Listcursos = be.GroupBy(a => a.id_materia).Select(grp => grp.First());

            Expression<Func<DataModel.alumnos_inscripciones, Boolean>> predicate = x => x.estado == 1;
            IQueryable<DataModel.alumnos_inscripciones> inscripto = _unitOfWork.Alumnos_InscripcionesRepository.GetAllByFilters(predicate,null);

            list = new List<CursoBE>();
            foreach (var item in Listcursos)
            {
                if (inscripto.Where(x => x.id_curso == item.id_curso).Count() <= item.cupo)
                {
                    var resul = inscripto.Where(t => t.condicion == "Inscripto" && t.id_curso == item.id_curso && t.id_alumno == IdConectado).Count();
                    if (resul > 0)
                    {
                        item.accion = "Eliminar";
                        list.Add(item);
                    }
                    else
                    {
                        item.accion = "Inscribir";
                        list.Add(item);
                    }

                }
            }
            return list;
        }
        #endregion
    }
}
