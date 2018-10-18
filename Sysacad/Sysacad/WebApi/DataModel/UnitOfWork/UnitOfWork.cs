#region Using Namespaces...

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data.Entity.Validation;
using DataModel.GenericRepository;
using DataModel.Interface;
using DataModel.Repository;

#endregion

namespace DataModel.UnitOfWork
{
    /// <summary>
    /// Unit of Work class responsible for DB transactions
    /// </summary>
    public class UnitOfWork : IDisposable
    {
		#region Member
		private SysacadContext context = null;
		private bool disposed = false;
		#endregion
		#region Constructor
		public UnitOfWork()
		{
			context = new SysacadContext();
		}

		public SysacadContext GetNewContext()
		{
			return new SysacadContext();
		}

		public GenericRepository<T> getRepository<T>() where T : class
		{
			return new GenericRepository<T>(context);
		}

		#endregion
		#region Commit
		public void Commit()
		{

			context.SaveChanges();
		}
		#endregion
		#region Dispose
		protected virtual void Dispose(bool disposed)
		{
			if (!this.disposed)
			{
				if (disposed)
				{
					context.Dispose();
				}
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		#endregion
		#region Relation Repository
		#region Members
		private Interface.IEspecialidadRepository _especialidadrepository;
		private Interface.IPlanRepository _planrepository;
		private Interface.IPlanEspecialidadRepository _planespecialidadrepository;
		private Interface.IModulo_Usuario_repository _modulo_Usuario_repository;
		private Interface.IModuloRepository _moduloRepository;
		private Interface.IPersonaRepository _personaRepository;
		private Interface.IUsuarioRepository _usuarioRepository;
		private Interface.IPlanComisionesRepository _planComisionesRepository;
		private Interface.IComisionesRepository _comisionesRepository;
		private Interface.IPlanMateriaRepository _planMateriaRepository;
		private Interface.IMateriaRepository _materiaRepository;
		private Interface.ICursoRepository _cursoRepository;
		private Interface.IDocentes_CursosRepository _docentes_CursosRepository;
		private Interface.IAlumnos_InscripcionesRepository _alumnos_InscripcionesRepository;		

		#endregion
		#region Properties
		public IEspecialidadRepository EspecialidadRepository
		{
			get
			{
				if (_especialidadrepository == null)
				{
					return _especialidadrepository = new EspecialidadRepository(context);
				}
				return _especialidadrepository;
			}

			set
			{
				_especialidadrepository = value;
			}
		}

		public IPlanRepository Planrepository
		{
			get
			{
				if (_planrepository == null)
				{
					return _planrepository = new PlanRepository(context);
				}
				return _planrepository;
			}

			set
			{
				_planrepository = value;
			}
		}

		public IPlanEspecialidadRepository Planespecialidadrepository
		{
			get
			{
				if (_planespecialidadrepository == null)
				{
					return _planespecialidadrepository = new PlanEspecialidadRepository(context);
				}
				return _planespecialidadrepository;
			}

			set
			{
				_planespecialidadrepository = value;
			}
		}

		public IModulo_Usuario_repository Modulo_Usuario_repository
		{
			get
			{
				if (_modulo_Usuario_repository == null)
				{
					return _modulo_Usuario_repository = new Modulo_Usuario_repository(context);
				}
				return _modulo_Usuario_repository;
			}

			set
			{
				_modulo_Usuario_repository = value;
			}
		}
		public IModuloRepository ModuloRepository
		{
			get
			{
				if (_moduloRepository == null)
				{
					return _moduloRepository = new ModuloRepository(context);
				}
				return _moduloRepository;
			}

			set
			{
				_moduloRepository = value;
			}
		}
		public IPersonaRepository PersonaRepository
		{
			get
			{
				if (_personaRepository == null)
				{
					return _personaRepository = new PersonaRepository(context);
				}
				return _personaRepository;
			}

			set
			{
				_personaRepository = value;
			}
		}
		public IUsuarioRepository UsuarioRepository
		{
			get
			{
				if (_usuarioRepository == null)
				{
					return _usuarioRepository = new UsuarioRepository(context);
				}
				return _usuarioRepository;
			}

			set
			{
				_usuarioRepository = value;
			}
		}

		public IPlanComisionesRepository PlanComisionesRepository
		{
			get
			{
				if (_planComisionesRepository==null)
				{
					return _planComisionesRepository = new PlanComisionRepository(context);
				}
				return _planComisionesRepository;
			}
			set => _planComisionesRepository = value;
		}
		public IComisionesRepository ComisionesRepository
		{
			get
			{
				if (_comisionesRepository==null)
				{
					_comisionesRepository = new ComisionRepository(context);
				}
			  return _comisionesRepository;
			}
			set => _comisionesRepository = value;
		}

		public IPlanMateriaRepository PlanMateriaRepository
		{
			get
			{
				if (_planMateriaRepository==null)
				{
					_planMateriaRepository = new PlanMateriaRepository(context);
				}
				return _planMateriaRepository;
			}
			set => _planMateriaRepository = value;
		}
		public IMateriaRepository MateriaRepository
		{
			get
			{
				if (_materiaRepository==null)
				{
					_materiaRepository = new MateriaRepository(context);
				}
				return _materiaRepository;
			}
			set => _materiaRepository = value;
		}
		public ICursoRepository CursoRepository
		{
			get
			{
				if (_cursoRepository==null)
				{
					_cursoRepository = new CursoRepository(context);
				}
				return _cursoRepository;
			}
			set => _cursoRepository = value;
		}

		public IDocentes_CursosRepository Docentes_CursosRepository
		{
			get
			{
				if (_docentes_CursosRepository==null)
				{
					_docentes_CursosRepository = new Docentes_CursosRepository(context);
				}
				return _docentes_CursosRepository;
			}
			set { _docentes_CursosRepository = value; }
		}
		public IAlumnos_InscripcionesRepository Alumnos_InscripcionesRepository
		{
			get
			{
				if (_alumnos_InscripcionesRepository==null)
				{
					 _alumnos_InscripcionesRepository = new Alumnos_InscripcionesRepository(context);
				}
				return _alumnos_InscripcionesRepository;
			}
			set { _alumnos_InscripcionesRepository = value; }
		}
		#endregion
		#endregion
	}
}