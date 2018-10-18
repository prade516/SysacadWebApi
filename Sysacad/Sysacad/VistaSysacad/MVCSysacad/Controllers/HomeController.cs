using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSysacad.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			if (Convert.ToString(@Session["sessionString"]) == String.Empty) 
			{
				return RedirectToAction("Login","Login");
			}
			return View();
		}		
	}
}