using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCPeaton
{
    public class RouteConfig
    {
        //public const string LoginRouteName = "LogIn";
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Especialidad", action = "List", id = UrlParameter.Optional }
            );

            
        }
    }
}
