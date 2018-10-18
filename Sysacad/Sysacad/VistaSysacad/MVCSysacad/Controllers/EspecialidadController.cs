using MVCSysacad.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSysacad.Controllers.Proxy;
using MVCSysacad.Enum;

namespace MVCSysacad.Controllers
{
    public class EspecialidadController : BaseSysacadProxyController<EspecialidadVM>
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
		public ActionResult Index()
		{
			if (!ModelState.IsValid)
				return View();
			#region Cookie
			string cookievalue ="eyJhbGciOiJSUzI1NiIsImtpZCI6IkU1N0RBRTRBMzU5NDhGODhBQTg2NThFQkExMUZFOUIxMkI5Qzk5NjIiLCJ0eXAiOiJKV1QifQ.eyJ1bmlxdWVfbmFtZSI6Ik1pa2VAQ29udG9zby5jb20iLCJBc3BOZXQuSWRlbnRpdHkuU2VjdXJpdHlTdGFtcCI6ImMzM2U4NzQ5LTEyODAtNGQ5OS05OTMxLTI1Mzk1MzY3NDEzMiIsInJvbGUiOiJBZG1pbmlzdHJhdG9yIiwib2ZmaWNlIjoiMzAwIiwianRpIjoiY2UwOWVlMGUtNWQxMi00NmUyLWJhZGUtMjUyYTZhMGY3YTBlIiwidXNhZ2UiOiJhY2Nlc3NfdG9rZW4iLCJzY29wZSI6WyJlbWFpbCIsInByb2ZpbGUiLCJyb2xlcyJdLCJzdWIiOiJjMDM1YmU5OS0yMjQ3LTQ3NjktOWRjZC01NGJkYWRlZWY2MDEiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjUwMDEvIiwibmJmIjoxNDc2OTk3MDI5LCJleHAiOjE0NzY5OTg4MjksImlhdCI6MTQ3Njk5NzAyOSwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MDAwLyJ9.q-c6Ld1b7c77td8B-0LcppUbL4a8JvObiru4FDQWrJ_DZ4_zKn6_0ud7BSijj4CV3d3tseEM-3WHgxjjz0e8aa4Axm55y4Utf6kkjGjuYyen7bl9TpeObnG81ied9NFJTy5HGYW4ysq4DkB2IEOFu4031rcQsUonM1chtz14mr3wWHohCi7NJY0APVPnCoc6ae4bivqxcYxbXlTN4p6bfBQhr71kZzP0AU_BlGHJ1N8k4GpijHVz2lT-2ahYaVSvaWtqjlqLfM_8uphNH3V7T7smaMpomQvA6u-CTZNJOZKalx99GNL4JwGk13MlikdaMFXhcPiamhnKtfQEsoNauA";
			if (User.Identity.IsAuthenticated)
				cookievalue = "eyJhbGciOiJSUzI1NiIsImtpZCI6IkU1N0RBRTRBMzU5NDhGODhBQTg2NThFQkExMUZFOUIxMkI5Qzk5NjIiLCJ0eXAiOiJKV1QifQ.eyJ1bmlxdWVfbmFtZSI6Ik1pa2VAQ29udG9zby5jb20iLCJBc3BOZXQuSWRlbnRpdHkuU2VjdXJpdHlTdGFtcCI6ImMzM2U4NzQ5LTEyODAtNGQ5OS05OTMxLTI1Mzk1MzY3NDEzMiIsInJvbGUiOiJBZG1pbmlzdHJhdG9yIiwib2ZmaWNlIjoiMzAwIiwianRpIjoiY2UwOWVlMGUtNWQxMi00NmUyLWJhZGUtMjUyYTZhMGY3YTBlIiwidXNhZ2UiOiJhY2Nlc3NfdG9rZW4iLCJzY29wZSI6WyJlbWFpbCIsInByb2ZpbGUiLCJyb2xlcyJdLCJzdWIiOiJjMDM1YmU5OS0yMjQ3LTQ3NjktOWRjZC01NGJkYWRlZWY2MDEiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjUwMDEvIiwibmJmIjoxNDc2OTk3MDI5LCJleHAiOjE0NzY5OTg4MjksImlhdCI6MTQ3Njk5NzAyOSwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MDAwLyJ9.q - c6Ld1b7c77td8B - 0LcppUbL4a8JvObiru4FDQWrJ_DZ4_zKn6_0ud7BSijj4CV3d3tseEM - 3WHgxjjz0e8aa4Axm55y4Utf6kkjGjuYyen7bl9TpeObnG81ied9NFJTy5HGYW4ysq4DkB2IEOFu4031rcQsUonM1chtz14mr3wWHohCi7NJY0APVPnCoc6ae4bivqxcYxbXlTN4p6bfBQhr71kZzP0AU_BlGHJ1N8k4GpijHVz2lT - 2ahYaVSvaWtqjlqLfM_8uphNH3V7T7smaMpomQvA6u - CTZNJOZKalx99GNL4JwGk13MlikdaMFXhcPiamhnKtfQEsoNauA";
			#endregion
			int state = 1;
			int top = 100;
			string orderby = "id_especialidad";
			string ascending = "asc";
			int page = 1;
			string filters = "?state=" + state + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page;
			List<EspecialidadVM> list = Myproxy().GetAll(filters, cookievalue);
			
			return View("List", list);
		}
		#endregion
		public ActionResult InsertForm()
		{
			EspecialidadVM model = new EspecialidadVM();
			return View("Insert",model);
		}
		public ActionResult FormUpdate(Int32 id)
		{
			EspecialidadVM especialidad = Myproxy().Get(id);
			return View("Update", especialidad);
		}
		public override ActionResult Add(EspecialidadVM model)
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
		public override ActionResult Update(EspecialidadVM model)
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
				EspecialidadVM model = new EspecialidadVM();
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