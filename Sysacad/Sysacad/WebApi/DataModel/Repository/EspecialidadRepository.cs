using DataModel.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataModel.Repository
{
	public class EspecialidadRepository : GenericRepository.GenericRepository<especialidades>, IEspecialidadRepository
	{
		public EspecialidadRepository(SysacadContext context) : base(context)
		{		
		}
		public override void Delete(especialidades entity, List<string> modifiedfields)
		{
			var espec = dbcontext.especialidades.Find(entity.id_especialidad);
						espec.estado = entity.estado;
						espec.desc_especialidad = entity.desc_especialidad;
			           dbcontext.especialidades.Attach(espec);
			base.Delete(espec, modifiedfields);
		}
	}
}
