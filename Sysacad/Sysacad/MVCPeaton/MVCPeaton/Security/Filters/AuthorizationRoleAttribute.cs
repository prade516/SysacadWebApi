using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCPeaton.Security.Filters
{
    public class AuthorizationRoleAttribute:ActionFilterAttribute
    {
        public string Roles { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            bool authorized = false;
            if (filterContext.HttpContext.Session["ApiToken"] == null ||
                filterContext.HttpContext.Session["RolesToken"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary()
                {
                    { "controller", "Account" },
                    { "action", "Login" }
                });
                return;
            }
                


            if (filterContext.HttpContext.Session["ExpireToken"] == null
              || (DateTime)filterContext.HttpContext.Session["ExpireToken"] < DateTime.Now)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary()
                {
                    { "controller", "Account" },
                    { "action", "ExpireSession" }
                });
                return;
            }

            List<String> stringList = filterContext.HttpContext.Session["RolesToken"].ToString().Split(',').
                    Select(handler => handler.Trim()).ToList();
            List<String> rolesList = Roles.Split(',').
                    Select(handler => handler.Trim()).ToList();
            foreach (var role in stringList)
            {
                foreach (var find in rolesList)
                {
                    if (role.Equals(find))
                    { 
                        authorized = true;
                        break;
                    }
                }
            }
          //if(!stringList.Any(t => t.Equals(stringList.Select(d => d.ToString()))))
          if(!authorized)
              filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary()
                {
                    { "controller", "Account" },
                    { "action", "Login" }
                });
        }
    }
}