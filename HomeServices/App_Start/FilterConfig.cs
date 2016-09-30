using System.Web;
using System.Web.Mvc;

namespace HomeServices
{
    public class FilterConfig // Global Filters are set up here 
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
