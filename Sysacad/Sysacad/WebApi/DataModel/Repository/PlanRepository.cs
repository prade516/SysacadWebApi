using DataModel.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Repository
{
	public class PlanRepository : GenericRepository.GenericRepository<planes>, IPlanRepository
	{
		public PlanRepository(SysacadContext context) : base(context)
		{
		}
		public override void Delete(planes entity, List<string> modifiedfields)
		{
			var plan = dbcontext.planes.Find(entity.id_plan);
			plan.estado = entity.estado;
			plan.desc_plan = entity.desc_plan;
			dbcontext.planes.Attach(plan);
			base.Delete(plan, modifiedfields);
		}
	}
}
