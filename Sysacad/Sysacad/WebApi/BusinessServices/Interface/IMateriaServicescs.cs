﻿using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Interface
{
	public interface IMateriaServicescs
	{
		MateriaBE GetById(Int64 Id);
		List<MateriaBE> GetAll(Int32 state, Int32 page, Int32 pageSize, String orderBy, String ascending, ref Int32 count);
		Int64 Create(MateriaBE Be);
		Boolean Update(Int64 Id, MateriaBE Be);
		Boolean Delete(Int64 Id);
	}
}
