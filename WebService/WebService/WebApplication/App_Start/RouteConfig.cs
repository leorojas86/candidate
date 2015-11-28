using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Add",
                url: "{controller}/{action}/{name}/{email}/{phone}",
                defaults: new { controller = "Contacts", action = "Add" }
            );

            routes.MapRoute(
                name: "Update",
                url: "{controller}/{action}/{id}/{name}/{email}/{phone}",
                defaults: new { controller = "Contacts", action = "Update" }
            );

            routes.MapRoute(
                name: "Delete",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Contacts", action = "Delete" }
            );

            routes.MapRoute(
                name: "Get",
                url: "{controller}/{action}",
                defaults: new { controller = "Contacts", action = "Get" }
            );

            routes.MapRoute(
                name: "Index",
                url: "{controller}/{action}/{param1}/{param2}/{param3}/{param4}",
                defaults: new { controller = "Contacts", action = "Get", param1 = UrlParameter.Optional, param2 = UrlParameter.Optional, param3 = UrlParameter.Optional, param4 = UrlParameter.Optional }
            );
        }
    }
}
