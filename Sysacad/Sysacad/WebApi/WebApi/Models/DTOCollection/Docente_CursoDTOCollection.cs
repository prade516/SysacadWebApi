using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models.DTOs;
using WebApi.Models.Hypermedia;
using WebApi.Models.Representacion;

namespace WebApi.Models.DTOCollection
{
	public class Docente_CursoDTOCollection : BaseCollectionRepresentation<Docente_CursoDTO>
	{
		public override BaseHypermedia Mytemplate
		{
			get
			{
				if (_mytemplate == null)
					_mytemplate = Docente_CursoHypermedia.GetInstance();
				return _mytemplate;
			}

			set
			{
				_mytemplate = value;
			}
		}

		public Docente_CursoDTOCollection(IList<Docente_CursoDTO> list) : base(list)
		{
			foreach (var l in list)
			{
				l.CreateUpdateLink();
				l.CreateDeleteLink();
				l.GetMyCurso();
			}
		}

		public Docente_CursoDTOCollection(IList<Docente_CursoDTO> list, string filters, int pagenumber, int count, int top) : base(list, filters, pagenumber, count, top)
		{
			foreach (var l in list)
			{
				l.CreateUpdateLink();
				l.CreateDeleteLink();
				l.GetMyCurso();
			}
		}
	}
}