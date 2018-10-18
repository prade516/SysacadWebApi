using MVCSysacad.Controllers.Proxy;
using MVCSysacad.Enum;
using MVCSysacad.Herramientas.Exceptions;
using MVCSysacad.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSysacad.Controllers
{
    public class PersonaController : BaseSysacadProxyController<PersonaVM>
	{
		#region Override methods needed for base controller
		public override BaseProxy<PersonaVM> Myproxy()
		{
			return new PersonaProxy();
		}

		public override string MyRelationEmbeeded()
		{
			throw new NotImplementedException();
		}

		protected override string MySpecificUrl()
		{
			return "/api/personas";
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
			string orderby = "id_persona";
			string ascending = "asc";
			int page = 1;
			string filters = "?state=" + state + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page+"&tipo_persona=1";
			List<PersonaVM> list = Myproxy().GetAll(filters, cookievalue);

			//ViewBag.Tipo = list.FirstOrDefault().tipo_persona;
			//System.Web.HttpContext.Current.Session["sessionString"] = list.FirstOrDefault().tipo_persona;
			//ViewData["sessionString"] = System.Web.HttpContext.Current.Session["sessionString"] as String;

			return View("List", list);
		}
		public ActionResult Docente()
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
			string orderby = "id_persona";
			string ascending = "asc";
			int page = 1;
			string filters = "?state=" + state + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page + "&tipo_persona=2";
			List<PersonaVM> list = Myproxy().GetAll(filters, cookievalue);			
			return View("Docente", list);
		}
		public ActionResult Alumno()
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
			string orderby = "id_persona";
			string ascending = "asc";
			int page = 1;
			string filters = "?state=" + state + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page + "&tipo_persona=3";
			List<PersonaVM> list = Myproxy().GetAll(filters, cookievalue);

			return View("Alumno", list);
		}
		public ActionResult InsertForm(Int32 id)
		{
			PersonaVM model = new PersonaVM();
			model.modulo = new ModuloProxy().GetAll("?state=1");
			model.plan = new PlanProxy().GetAll("?state=1");
			model.role = Role.Administrador | Role.Docente | Role.Alumno;
			if (id == 1)
			{
				return View("Insert", model);
			}
			else if (id==2)
			{
				return View("InsertDocente", model);
			}
			else
			{
				return View("InsertAlumno", model);
			}
			
		}
		public ActionResult FormUpdate(Int32 id)
		{
			PersonaVM model = Myproxy().Get(id);
			model.usuariossingle = new UsuarioVM();
			model.usuariossingle.modulo_usuariosingle = new Modulos_UsuarioVM();
			foreach (var item in model.Usuarios)
			{
				model.usuariossingle = item;
				foreach (var itemmod in item.modulo_usuario)
				{
					
					model.usuariossingle.modulo_usuariosingle = itemmod;
				}
			}
			model.plan = new PlanProxy().GetAll("?state=1");
			model.modulo = new ModuloProxy().GetAll("?state=1");		
			return View("Update", model);
		}

		public override ActionResult Add(PersonaVM model)
		{
			try
			{
				model.estado = (Int32)EstadoPersona.Alta;
				model.legajo = GetLastLegajo();
				//model.tipo_persona = Convert.ToInt32(model.role);
				model.Usuarios = new List<UsuarioVM>()
				{
					new UsuarioVM()
					{
						nombre_usuario=model.usuariossingle.nombre_usuario,
						clave=model.usuariossingle.clave,
						email=model.usuariossingle.email,
						habilitado=true,
						cambia_clave=false,
						estado= (Int32)EstadoPersona.Alta,						
						modulo_usuario = new List<Modulos_UsuarioVM>()
						{
							new Modulos_UsuarioVM()
							{
								id_modulo=model.usuariossingle.modulo_usuariosingle.id_modulo,
								alta=model.usuariossingle.modulo_usuariosingle.alta,
								modificacion=model.usuariossingle.modulo_usuariosingle.modificacion,
								baja=model.usuariossingle.modulo_usuariosingle.baja,
								consulta=model.usuariossingle.modulo_usuariosingle.consulta,
								estado=(Int32)EstadoPersona.Alta
							},
						},
					},
				};
				
				// En caso de ser invalido el ModelState.
				if (!ModelState.IsValid)
					return View("AddForm");
				string cookievalue = "";
				if (User.Identity.IsAuthenticated)
					cookievalue = Decode().Token;
				Myproxy().Create(model, cookievalue);
				if (model.tipo_persona == (Int32)Role.Administrador)
				{
					return RedirectToAction("Index");
				}
				else if (model.tipo_persona == (Int32)Role.Docente)
				{
					return RedirectToAction("Docente");
				}
				else
				{
					return RedirectToAction("Alumno");
				}
			}
			catch (Exception ex)
			{
				HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
				return RedirectToAction("Index");
			}
		}
		public override ActionResult Update(PersonaVM model)
		{
			try
			{
				model.Usuarios = new List<UsuarioVM>()
				{
					new UsuarioVM()
					{
						id_persona=model.id_persona,
						id_usuario=model.usuariossingle.id_usuario,
						nombre_usuario=model.usuariossingle.nombre_usuario,
						clave=model.usuariossingle.clave,
						email=model.usuariossingle.email,
						habilitado=true,
						cambia_clave=false,
						estado= (Int32)EstadoPersona.Alta,
						modulo_usuario = new List<Modulos_UsuarioVM>()
						{
							new Modulos_UsuarioVM()
							{
								id_modulo_usuario=model.usuariossingle.modulo_usuariosingle.id_modulo_usuario,
								id_usuario=model.usuariossingle.modulo_usuariosingle.id_usuario,
								id_modulo=model.usuariossingle.modulo_usuariosingle.id_modulo,
								alta=model.usuariossingle.modulo_usuariosingle.alta,
								modificacion=model.usuariossingle.modulo_usuariosingle.modificacion,
								baja=model.usuariossingle.modulo_usuariosingle.baja,
								consulta=model.usuariossingle.modulo_usuariosingle.consulta,
								estado=(Int32)EstadoPersona.Alta
							},
						},
					},
				};
				// En caso de ser invalido el ModelState.
				if (!ModelState.IsValid)
					return View("AddForm");
				string cookievalue = "";
				if (User.Identity.IsAuthenticated)
					cookievalue = Decode().Token;
				Myproxy().Update(model, cookievalue);
				if (model.tipo_persona==(Int32)Role.Administrador)
				{
					return RedirectToAction("Index");
				}
				else if (model.tipo_persona == (Int32)Role.Docente)
				{
					return RedirectToAction("Docente");
				}
				else
				{
					return RedirectToAction("Alumno");
				}
				
			}
			catch (Exception ex)
			{
				HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
				return RedirectToAction("Index");
			}
		}
		public  ActionResult DeleteAll(long id, long tipo=0)
		{
			try
			{
				PersonaVM model = new PersonaVM();
				model.Id = (Int32)(id);
				// En caso de ser invalido el ModelState.
				if (!ModelState.IsValid)
					return View("AddForm");
				string cookievalue = "";
				if (User.Identity.IsAuthenticated)
					cookievalue = Decode().Token;
				Myproxy().Delete(model, cookievalue);
				if (tipo== (Int32)Role.Administrador)
				{
					return RedirectToAction("Index");
				}
				else if (tipo == (Int32)Role.Docente)
				{
					return RedirectToAction("Docente");
				}
				else
				{
					return RedirectToAction("Alumno");
				}
			}
			catch (Exception ex)
			{
				HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
				return RedirectToAction("Index");
			}
		}
		#region LastLegajo
		private Int32 GetLastLegajo()
		{
			int state = 1;
			int top = 100;
			string orderby = "id_persona";
			string ascending = "asc";
			int page = 1;
			string filters = "?state=" + state + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page;

			var lastlegajo = 0;
			var resultado = Myproxy().GetAll(filters);
			if (resultado.Count() != 0)
			{
				lastlegajo = Myproxy().GetAll(filters).LastOrDefault().legajo+1;
			}
			else
			{
				lastlegajo +=1;
			}

			return lastlegajo;
		}
		#endregion
	}
}