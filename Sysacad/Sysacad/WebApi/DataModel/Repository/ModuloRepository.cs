using DataModel.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Repository
{
	public class ModuloRepository : GenericRepository.GenericRepository<modulos>, IModuloRepository
	{
		public ModuloRepository(SysacadContext context) : base(context)
		{
		}
		public override void Delete(modulos entity, List<string> modifiedfields)
		{
			var modulo = dbcontext.modulos.Find(entity.id_modulo);
			modulo.desc_modulo = entity.desc_modulo;
			modulo.ejecuta = entity.ejecuta;
			modulo.estado = entity.estado;
			dbcontext.modulos.Attach(modulo);
			base.Delete(modulo, modifiedfields);
		}
	}
}
