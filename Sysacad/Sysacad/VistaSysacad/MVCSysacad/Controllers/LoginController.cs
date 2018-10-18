using MVCSysacad.Controllers.Proxy;
using MVCSysacad.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSysacad.Controllers
{
    public class LoginController : BaseSysacadProxyController<PersonaVM>
	{
		#region Override methods needed for base controller
		public override BaseProxy<PersonaVM> Myproxy()
		{
			return new LoginProxy();
		}

		public override string MyRelationEmbeeded()
		{
			throw new NotImplementedException();
		}

		protected override string MySpecificUrl()
		{
			return "/api/logins";
		}
		#endregion
		// GET: Plan
		public ActionResult Login()
		{			
			PersonaVM model = new PersonaVM();
			return View("Login", model);
		}
		public ActionResult Logear(PersonaVM model)
		{
			try
			{				
				var usr = model.usuariossingle.nombre_usuario;
				var pas = model.usuariossingle.clave;
				PersonaVM conect = Myproxy().GetAll("?username=" + usr + "&password=" + pas).FirstOrDefault();
				if (conect != null)
				{
					if (conect.Usuarios.FirstOrDefault().cambia_clave == false)
					{
						return View("ChangePassword",conect);
					}
					else
					{
						var usractual = User.Identity.Name;
						System.Web.HttpContext.Current.Session["sessionString"] = conect.tipo_persona;
						System.Web.HttpContext.Current.Session["name"] = conect.nombre + " " + conect.apellido;
						return RedirectToAction("Index", "Home");
					}
				}
				else
				{
					ViewBag.message = "El usuario o/y la contraseña es incorecto";
					return View("Login");
				}
			}
			catch (Exception ex)
			{
				throw;
			}
		}
		public ActionResult LogOut()
		{
			System.Web.HttpContext.Current.Session["sessionString"] = String.Empty;
			System.Web.HttpContext.Current.Session["name"] = String.Empty;

			return RedirectToAction("Login");
		}
		//public ActionResult ChangePassword()
		//{
		//	PersonaVM vm = new PersonaVM();
		//	return View("ChangePassword",vm);
		//}
		public ActionResult Change(PersonaVM vm)
		{
			var usuario = new PersonaProxy().Get(vm.id_persona);
			var x = usuario.Usuarios.FirstOrDefault().clave;
			if (vm.usuariossingle.clave!=null)
			{
				if (usuario.Usuarios.FirstOrDefault().clave == vm.usuariossingle.clave)
				{
					if (vm.usuariossingle.nuevaclave == vm.usuariossingle.confirmarclave)
					{
						vm.Usuarios = new List<UsuarioVM>()
						{
							new UsuarioVM()
							{
								id_usuario = usuario.Usuarios.FirstOrDefault().id_usuario,
								id_persona = usuario.Usuarios.FirstOrDefault().id_persona,
								nombre_usuario = usuario.Usuarios.FirstOrDefault().nombre_usuario,
								clave = vm.usuariossingle.nuevaclave,
								cambia_clave=true,
								habilitado=usuario.Usuarios.FirstOrDefault().habilitado,
								estado = usuario.Usuarios.FirstOrDefault().estado
							}
						};
						Myproxy().Update(vm);
					}
					else
					{
						ViewBag.message = "La confirmacion de la clave nueva es diferente que la clave nueva";
						return View("ChangePassword", vm);
					}

				}
				else
				{
					ViewBag.message = "La clave actuales no esta correcta vuelve a ingresar";
					return View("ChangePassword", vm);
				}
			}
			else
			{
				ViewBag.message = "Debe ingresar la clave actuales";
				return View("ChangePassword", vm);
			}			
			return RedirectToAction("Login");
		}
	}
}