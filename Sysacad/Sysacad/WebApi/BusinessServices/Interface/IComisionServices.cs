using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Interface
{
	public interface IComisionServices
	{
		ComisionBE GetById(Int32 Id);
		List<ComisionBE> GetAll(Int32 state, Int32 page, Int32 pageSize, String orderBy, String ascending, ref Int32 count);
		Int64 Create(ComisionBE Be);
		Boolean Update(Int64 Id, ComisionBE Be);
		Boolean Delete(Int32 Id);
	}
}
