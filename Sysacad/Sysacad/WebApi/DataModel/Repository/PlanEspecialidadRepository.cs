using DataModel.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Repository
{
	public class PlanEspecialidadRepository : GenericRepository.GenericRepository<planespecialidades>, IPlanEspecialidadRepository
	{
		public PlanEspecialidadRepository(SysacadContext context) : base(context)
		{
		}
		public override void Delete(planespecialidades entity, List<string> modifiedfields)
		{
			var planespecialidad = dbcontext.planespecialidad.Find(entity.idplanespecialidad);
			planespecialidad.estado = entity.estado;
			planespecialidad.idplan = entity.idplan;
			planespecialidad.idespecialidad = entity.idespecialidad;
			dbcontext.planespecialidad.Attach(planespecialidad);
			base.Delete(planespecialidad, modifiedfields);
		}
		public override void Update(planespecialidades entity, List<string> modifiedfields)
		{
			var planespecialidad = dbcontext.planespecialidad.Find(entity.idplanespecialidad);
			planespecialidad.estado = entity.estado;
			planespecialidad.idplan = entity.idplan;
			planespecialidad.idespecialidad = entity.idespecialidad;
			dbcontext.planespecialidad.Attach(planespecialidad);
			base.Update(planespecialidad, modifiedfields);	
		}
	}
}
