using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessServices.Interface
{
	public interface IEspecialidadServices
	{
		EspecialidadBE GetById(Int64 Id);
		List<EspecialidadBE> GetAll(Int32 state, Int32 page, Int32 pageSize, String orderBy, String ascending, ref Int32 count);
		Int64 Create(EspecialidadBE Be, String username);
		Boolean Update(Int64 Id, EspecialidadBE Be);
		Boolean Delete(Int64 Id);
	}
}
