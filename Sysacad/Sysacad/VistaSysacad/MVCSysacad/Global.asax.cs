﻿using HalClient.Net;
using HalClient.Net.Parser;
using MVCSysacad.Herramientas.Seguridad;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace MVCSysacad
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			// Create the default parser
			IHalJsonParser parser = new HalJsonParser();

			// Create the factory
			IHalHttpClientFactory factory = new HalHttpClientFactory(parser);
		}
		protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
		{
			HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

			if (authCookie != null)
			{
				FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

				//JwtSecurityToken jwTok = TokenHelper.GetJWTokenFromCookie(authCookie);

				DataValues md = JsonConvert.DeserializeObject<DataValues>(authTicket.UserData);

				// Create the IIdentity instance
				IIdentity id = new FormsIdentity(authTicket);

				//string[] roles = Session["RolesToken"].ToString().Split(',');
				string[] roles = roles = md.Roles.Split(',');
				// Create the IPrinciple instance
				IPrincipal principal = new GenericPrincipal(id, roles);

				// Set the context user
				Context.User = principal;
			}
		}
	}
}
