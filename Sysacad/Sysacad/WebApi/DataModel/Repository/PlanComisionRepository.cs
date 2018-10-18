using DataModel.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Repository
{
	public class PlanComisionRepository : GenericRepository.GenericRepository<plancomisiones>, IPlanComisionesRepository
	{
		public PlanComisionRepository(SysacadContext context) : base(context)
		{
		}
		public override void Delete(plancomisiones entity, List<string> modifiedfields)
		{
			var plancomision = dbcontext.plancomisiones.Find(entity.id_plancomision);
			plancomision.estado = entity.estado;
			plancomision.id_comision = entity.id_comision;
			plancomision.id_plan = entity.id_plan;
			dbcontext.plancomisiones.Attach(plancomision);
			base.Delete(plancomision, modifiedfields);
		}
	}
}
