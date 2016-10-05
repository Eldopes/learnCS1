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
        public ActionResult CalculateCost(string consumption) // must be string because Post allways sends string
        {
            //  var result = consumption;
            // int result = 35;
            return Json(new { bla = "example"});          
        }


    }
}