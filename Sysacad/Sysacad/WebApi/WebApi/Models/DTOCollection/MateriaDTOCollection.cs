using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models.DTOs;
using WebApi.Models.Hypermedia;
using WebApi.Models.Representacion;

namespace WebApi.Models.DTOCollection
{
	public class MateriaDTOCollection : BaseCollectionRepresentation<MateriaDTO>
	{
		public override BaseHypermedia Mytemplate
		{
			get
			{
				if (_mytemplate == null)
					_mytemplate = PlanHypermedia.GetInstance();
				return _mytemplate;
			}

			set
			{
				_mytemplate = value;
			}
		}

		public MateriaDTOCollection(IList<MateriaDTO> list) : base(list)
		{
			foreach (var l in list)
			{
				l.CreateUpdateLink();
				l.CreateDeleteLink();
				l.MyPlanMateriaRelations();
			}
		}

		public MateriaDTOCollection(IList<MateriaDTO> list, string filters, int pagenumber, int count, int top) : base(list, filters, pagenumber, count, top)
		{
			foreach (var l in list)
			{
				l.CreateUpdateLink();
				l.CreateDeleteLink();
				l.MyPlanMateriaRelations();
			}
		}
	}
}