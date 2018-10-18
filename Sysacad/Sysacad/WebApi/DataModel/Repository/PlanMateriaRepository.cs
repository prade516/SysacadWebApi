using DataModel.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Repository
{
	public class PlanMateriaRepository : GenericRepository.GenericRepository<planmaterias>, IPlanMateriaRepository
	{
		public PlanMateriaRepository(SysacadContext context) : base(context)
		{
		}
		public override void Delete(planmaterias entity, List<string> modifiedfields)
		{
			var plmateria = dbcontext.planmaterias.Find(entity.idplanmateria);
			plmateria.estado = entity.estado;
			plmateria.idplan = entity.idplan;
			plmateria.idmateria = entity.idmateria;

			dbcontext.planmaterias.Attach(plmateria);
			base.Delete(plmateria, modifiedfields);
		}
	}
}
