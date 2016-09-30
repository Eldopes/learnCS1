using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
/*
 *  MVC framework tries to launch Home Controller even without any additional routes in the address line 
 *  eg   localhost:8080  or  localhost:8080/home/ are identical
 * 
 * */

namespace HomeServices.Controllers
{
    public class HomeController : Controller // main app controller containing Action functions each of which renders a page  
    {   // ActionResult is a base class which defines server response 
        public ActionResult Index() 
        {
            return View();  // returns view Index.Cshtml   (aka main home page)
        } 
     
         public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View(); // returns view About.Cshtml   (aka about page)
        } 

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page."; // returns view Contact.Cshtml  (aka contact page)
            return View();
        }

        public ActionResult SiteMap()
        {
            return View();  // 
        }


    }
}