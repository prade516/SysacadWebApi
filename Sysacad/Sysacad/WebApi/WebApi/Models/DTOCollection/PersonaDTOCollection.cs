using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models.DTOs;
using WebApi.Models.Hypermedia;
using WebApi.Models.Representacion;

namespace WebApi.Models.DTOCollection
{
	public class PersonaDTOCollection : BaseCollectionRepresentation<PersonaDTO>
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

		public PersonaDTOCollection(IList<PersonaDTO> list) : base(list)
		{
			foreach (var l in list)
			{
				l.CreateUpdateLink();
				l.CreateDeleteLink();
				l.MyUsuarioRelations();
			}
		}

		public PersonaDTOCollection(IList<PersonaDTO> list, string filters, int pagenumber, int count, int top) : base(list, filters, pagenumber, count, top)
		{
			foreach (var l in list)
			{
				l.CreateUpdateLink();
				l.CreateDeleteLink();
				l.MyUsuarioRelations();
			}
		}
	}
}