using MVCSysacad.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSysacad.Controllers.Proxy;
using MVCSysacad.Enum;
using MVCSysacad.Herramientas.Exceptions;

namespace MVCSysacad.Controllers
{
    public class PlanController :BaseSysacadProxyController<PlanVM>
	{
		#region Override methods needed for base controller
		public override BaseProxy<PlanVM> Myproxy()
		{
			return new PlanProxy();
		}

		public override string MyRelationEmbeeded()
		{
			throw new NotImplementedException();
		}

		protected override string MySpecificUrl()
		{
			return "/api/planes";
		}
		#endregion
		// GET: Plan
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
			string orderby = "id_plan";
			string ascending = "asc";
			int page = 1;
			string filters = "?state=" + state + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page;
			List<PlanVM> list = Myproxy().GetAll(filters, cookievalue);
			foreach (var item in list)
			{
				foreach (var item2 in item.Planespecialidad)
				{
					item.name = item2.Especialidad.desc_especialidad;
				}
			}
			return View("List", list);
		}
		public ActionResult InsertForm(PlanVM model)
		{
			model.especialidad = new EspecialidadProxy().GetAll("?state=1");

			return View("Insert", model);
		}
		public ActionResult FormUpdate(Int32 id)
		{
			PlanVM model = Myproxy().Get(id);
			model.especialidad = new EspecialidadProxy().GetAll("?state=1");
			var especialidad = model.Planespecialidad.Where(x => x.idplan == id);
			model.id_especialidad = especialidad.FirstOrDefault().Especialidad.id_especialidad;
			return View("Update",model);
		}
		public override ActionResult Add(PlanVM model)
		{
			try
			{
				model.estado = (Int32)EstadoPersona.Alta;
				if (model!=null)
				{
					model.Planespecialidad = new List<PlanEspecialidadVM>()
					{
						new PlanEspecialidadVM()
						{
							idespecialidad=model.id_especialidad,
							estado=(Int32)EstadoPersona.Alta
						}
					};
				}
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
				HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
				return RedirectToAction("Index");
			}
		}
		public override ActionResult Update(PlanVM model)
		{
			try
			{
				//model.estado = (Int32)EstadoPersona.Alta;
				if (model.Planespecialidad != null)
				{
					foreach (var item in model.Planespecialidad)
					{
						item.idespecialidad = model.id_especialidad;
					}					
				}
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
				HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
				return RedirectToAction("Index");
			}
		}
		public override ActionResult DeleteForm(long id)
		{
			try
			{
				PlanVM model = new PlanVM();
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
				HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
				return RedirectToAction("Index");
			}
		}
	}
}