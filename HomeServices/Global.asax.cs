using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
// Application lifetime events are handled here 

namespace HomeServices
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {   // Application startup handler 
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes); // routing table of our application (RegisterRoutes method is defined in RouteConfig.cs)
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
