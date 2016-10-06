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
        // GET: Calc
        public ActionResult Calculations()
        {
            return View();
        }

        [HttpPost] // TODO: Ajax processing 
        public ActionResult GetCost(FuelInfo fuel_info) // using custom model class "Consumption"
        {
            object result = fuel_info;

            CalculateCost(); // invokes outer calculation method
            return Json(result); // successfully returning the result to view 
        }

        private double CalculateCost()
        {
            return 1;
        }

    }
}