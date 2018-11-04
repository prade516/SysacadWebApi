using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Interface
{
	public interface ICursoServices
	{
		CursoBE GetById(Int64 Id);
		List<CursoBE> GetAll(Int32 state, Int32 page, Int32 pageSize, String orderBy, String ascending,Int32 tipo, Int32 idconectado, Boolean iscripcion, ref Int32 count);
		Int64 Create(CursoBE Be);
		Boolean Update(Int64 Id, CursoBE Be);
		Boolean Delete(Int64 Id);
	}
}
