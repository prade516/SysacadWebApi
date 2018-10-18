using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Interface
{
	public interface IModuloServices
	{
		ModuloBE GetById(Int32 Id);
		List<ModuloBE> GetAll(Int32 state, Int32 page, Int32 pageSize, String orderBy, String ascending, ref Int32 count);
		Int64 Create(ModuloBE Be);
		Boolean Update(Int64 Id, ModuloBE Be);
		Boolean Delete(Int32 Id);
	}
}
