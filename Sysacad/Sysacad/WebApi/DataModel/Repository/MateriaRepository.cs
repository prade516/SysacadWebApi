using DataModel.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Repository
{
	public class MateriaRepository : GenericRepository.GenericRepository<materias>, IMateriaRepository
	{
		public MateriaRepository(SysacadContext context) : base(context)
		{
		}
		public override void Delete(materias entity, List<string> modifiedfields)
		{
			var materia = dbcontext.materias.Find(entity.id_materia);
			materia.estado = entity.estado;
			materia.hs_semanales = entity.hs_semanales;
			materia.hs_totales = entity.hs_totales;
			materia.desc_materia = entity.desc_materia;
			dbcontext.materias.Attach(materia);
			base.Delete(materia, modifiedfields);
		}
	}
}
