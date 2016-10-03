using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeServices.Controllers
{
    public class CalcController : Controller
    {
        // GET: Calc
        public ActionResult Calculations()
        {
            return View();
        }

        [HttpPost] // TODO: Ajax processing 
        public ActionResult CalculateCost(int consumption)
        {            
            return Json(new { success = false, responseText = "The attached file is not supported." }, JsonRequestBehavior.AllowGet);
        }


    }
}