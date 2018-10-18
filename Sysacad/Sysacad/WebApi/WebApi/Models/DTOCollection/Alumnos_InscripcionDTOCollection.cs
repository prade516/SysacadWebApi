using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models.DTOs;
using WebApi.Models.Hypermedia;
using WebApi.Models.Representacion;

namespace WebApi.Models.DTOCollection
{
	public class Alumnos_InscripcionDTOCollection : BaseCollectionRepresentation<Alumnos_InscripcionDTO>
	{
		public override BaseHypermedia Mytemplate
		{
			get
			{
				if (_mytemplate == null)
					_mytemplate = Alumnos_InscripcionHypermedia.GetInstance();
				return _mytemplate;
			}

			set
			{
				_mytemplate = value;
			}
		}

		public Alumnos_InscripcionDTOCollection(IList<Alumnos_InscripcionDTO> list) : base(list)
		{
			foreach (var l in list)
			{
				l.CreateUpdateLink();
				l.CreateDeleteLink();
				l.MyUsuariosRelations();
				l.MyPersonaRelations();
			}
		}

		public Alumnos_InscripcionDTOCollection(IList<Alumnos_InscripcionDTO> list, string filters, int pagenumber, int count, int top) : base(list, filters, pagenumber, count, top)
		{
			foreach (var l in list)
			{
				l.CreateUpdateLink();
				l.CreateDeleteLink();
				l.MyUsuariosRelations();
				l.MyPersonaRelations();
			}
		}
	}
}