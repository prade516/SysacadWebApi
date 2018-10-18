using DataModel.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Repository
{
	public class ComisionRepository : GenericRepository.GenericRepository<comisiones>, IComisionesRepository
	{
		public ComisionRepository(SysacadContext context) : base(context)
		{
		}
		public override void Delete(comisiones entity, List<string> modifiedfields)
		{
			var comision = dbcontext.comisiones.Find(entity.id_comision);
			comision.estado = entity.estado;
			comision.id_comision = entity.id_comision;
			comision.desc_comision = entity.desc_comision;
			comision.anio_especialidad = entity.anio_especialidad;
			dbcontext.comisiones.Attach(comision);
			base.Delete(comision, modifiedfields);
		}
	}
}
