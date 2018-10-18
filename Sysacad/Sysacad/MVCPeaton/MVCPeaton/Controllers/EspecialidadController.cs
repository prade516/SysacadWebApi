using MVCPeaton.Controllers.Proxys;
using MVCPeaton.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPeaton.Controllers
{
	public class EspecialidadController : BaseProxyController<EspecialidadVM>
	{
		// GET: Especialidad
		#region Override methods needed for base controller
		public override BaseProxy<EspecialidadVM> Myproxy()
		{
			return new EspecialidadProxy();
		}

		public override string MyRelationEmbeeded()
		{
			throw new NotImplementedException();
		}

		protected override string MySpecificUrl()
		{
			return "/api/especialidades";
		}
		#endregion
		#region List
		public ActionResult List()
		{
			if (!ModelState.IsValid)
				return View();
			#region Cookie
			string cookievalue = "";
			if (User.Identity.IsAuthenticated)
				cookievalue = Decode().Token;
			#endregion
			int state = 1;
			int top = 100;
			string orderby = "id_especialidad";
			string ascending = "asc";
			int page = 1;
			string filters = "?state=" + state + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page;
			List<EspecialidadVM> list = Myproxy().GetAll(filters, cookievalue).Result;

			return View("List", list);
		}
		#endregion
	}
}