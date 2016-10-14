using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeServices.Models; // using custom model class "Consumption" (to work with ajax and databases)
using HomeServices.Models.Calc; // to access context calc models
using System.Data.Entity;
using System.Collections.Specialized;
using System.Web.Script.Serialization; // for json serialization
using Newtonsoft.Json; // new library for json parsing 

namespace HomeServices.Controllers
{
    public class CalcController : Controller
    {
        // WORKING WITH DB:
        CalcContext db = new CalcContext(); // initializing context class object in controller to work with EntityFramework Context class
        protected override void Dispose(bool disposing) // Dispose method to close all active db connections
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Calculations()
        {
            return View(db.session_list); // passing "session_list" data context to the view
        }

        // HANDLING AJAX:
        [HttpPost] 
        public ActionResult GetCost(FuelInfo fuel_info) // using custom model class "FuelInfo"
        {
            string to_parse = new JavaScriptSerializer().Serialize(Json(fuel_info).Data); // Converting object of type "FuelInfo" to Json => Serializing the json to string using a new instance of JavaScriptSerializer class       
            Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(to_parse); // Serializing our json string to dictionary using JSON.NET
            double cost = Convert.ToDouble(values["Cost"]); // Getting dictionary values by their ID's and saving them to variables 
            double consumption = Convert.ToDouble(values["Consumption"]);
            double distance = Convert.ToDouble(values["Distance"]);
            return Json(CalculateCost(cost, consumption, distance)); // returning the result of CalculateCost method in the format of json back to our Javascript function
        }

        private double CalculateCost(double cost, double consumption, double distance) // the calculation method
        {
            double total_fuel_amount = (consumption / 100) * distance;
            double total_cost = total_fuel_amount * cost;
            return Math.Round(total_cost, 2);
        }
    }
}