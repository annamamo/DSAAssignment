using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Security.Principal;

namespace Electros
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
        protected void Session_Start(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["accountid"] = "";
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            if (Context.User != null)
            {
                string name = Context.User.Identity.Name;
                IEnumerable<Common.Role> userRoles = new RoleServ.RoleServiceClient().GetUserRoles(name).ToList();
                   

                string[] arrayRoles = new string[userRoles.Count()];
                int count = 0;

                foreach (Common.Role r in userRoles)
                {
                    arrayRoles[count] = r.Name;
                    count++;
                }
                GenericPrincipal gp = new GenericPrincipal(Context.User.Identity, arrayRoles);
                Context.User = gp;
            }
        }
    }

}