using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HomeServices
{
    public class RouteConfig // Routes are set up here 
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}", // typical url of our application
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional } // default actions (if controller not chosen, it defaults to home controller to return index page)
            );

        
        }
    }
}
