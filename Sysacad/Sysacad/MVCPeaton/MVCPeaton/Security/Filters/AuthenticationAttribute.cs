using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCPeaton.Security.Filters
{
    public class AuthenticationAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["ApiToken"] == null)
            {
                //filterContext.HttpContext.Response.RedirectToRoute(RouteConfig.LoginRouteName);
                filterContext.Result= new RedirectToRouteResult(new RouteValueDictionary()
                {
                    { "controller", "Account" },
                    { "action", "Login" }
                });
                return;
            }

            if (filterContext.HttpContext.Session["ExpireToken"] == null
               || (DateTime)filterContext.HttpContext.Session["ExpireToken"]<DateTime.Now)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary()
                {
                    { "controller", "Account" },
                    { "action", "ExpireSession" }
                });
                return;
            }
        }
    }
}