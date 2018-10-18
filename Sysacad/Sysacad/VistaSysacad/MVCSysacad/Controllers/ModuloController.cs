using MVCSysacad.Controllers.Proxy;
using MVCSysacad.Enum;
using MVCSysacad.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSysacad.Controllers
{
    public class ModuloController : BaseSysacadProxyController<ModuloVM>
	{
		#region Override methods needed for base controller
		public override BaseProxy<ModuloVM> Myproxy()
		{
			return new ModuloProxy();
		}

		public override string MyRelationEmbeeded()
		{
			throw new NotImplementedException();
		}

		protected override string MySpecificUrl()
		{
			return "/api/modulos";
		}
		#endregion
		#region List
		public ActionResult Index()
		{
			if (!ModelState.IsValid)
				return View();
			#region Cookie
			string cookievalue = "";
			if (User.Identity.IsAuthenticated)
				cookievalue = "";
			#endregion
			int state = 1;
			int top = 100;
			string orderby = "id_modulo";
			string ascending = "asc";
			int page = 1;
			string filters = "?state=" + state + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page;
			List<ModuloVM> list = Myproxy().GetAll(filters, cookievalue);

			return View("List", list);
		}
		#endregion
		public ActionResult InsertForm()
		{
			ModuloVM model = new ModuloVM();
			return View("Insert", model);
		}
		public ActionResult FormUpdate(Int32 id)
		{
			ModuloVM especialidad = Myproxy().Get(id);
			return View("Update", especialidad);
		}
		public override ActionResult Add(ModuloVM model)
		{
			try
			{
				model.estado = (Int32)EstadoPersona.Alta;

				// En caso de ser invalido el ModelState.
				if (!ModelState.IsValid)
					return View("AddForm");
				string cookievalue = "";
				if (User.Identity.IsAuthenticated)
					cookievalue = Decode().Token;
				Myproxy().Create(model, cookievalue);
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				//HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
				return RedirectToAction("Index");
			}
		}
		public override ActionResult Update(ModuloVM model)
		{
			try
			{
				// En caso de ser invalido el ModelState.
				if (!ModelState.IsValid)
					return View("AddForm");
				string cookievalue = "";
				if (User.Identity.IsAuthenticated)
					cookievalue = Decode().Token;
				Myproxy().Update(model, cookievalue);
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				//HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
				return RedirectToAction("Index");
			}
		}
		public override ActionResult DeleteForm(long id)
		{
			try
			{
				ModuloVM model = new ModuloVM();
				model.Id = (Int32)(id);
				// En caso de ser invalido el ModelState.
				if (!ModelState.IsValid)
					return View("AddForm");
				string cookievalue = "";
				if (User.Identity.IsAuthenticated)
					cookievalue = Decode().Token;
				Myproxy().Delete(model, cookievalue);
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				//HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
				return RedirectToAction("Index");
			}
		}
	}
}