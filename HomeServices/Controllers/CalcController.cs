using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeServices.Models; // using custom model class "Consumption"

namespace HomeServices.Controllers
{
    public class CalcController : Controller
    {       
        public ActionResult Calculations()
        {
            return View();
        }

        [HttpPost] 
        public ActionResult GetCost(FuelInfo fuel_info) // using custom model class "Consumption"
        {
            object to_calc = fuel_info; // save data for passing to CalculateCost() method
            CalculateCost(fuel_info); // invokes outer calculation method

            object result = fuel_info;
            return Json(result); // successfully returning the result to view (TEST)
        }

        private double CalculateCost() // TODO: Object from GetCost() to array and processing 
        {
            return 1;
        }

    }
}