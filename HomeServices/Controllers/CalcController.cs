using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeServices.Models; // using custom model class "Consumption"
using System.Collections.Specialized;
using System.Web.Script.Serialization; // for json serialization
using Newtonsoft.Json; // new library for json parsing 
using Newtonsoft.Json.Linq; 



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
            string to_parse = new JavaScriptSerializer().Serialize(Json(fuel_info).Data); // Converting object of type "FuelInfo" to Json => Serializing the json to string using a new instance of JavaScriptSerializer class       
            Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(to_parse); // Serializing our json string to dictionary using JSON.NET
            double cost = Convert.ToDouble(values["Cost"]); // Getting dictionary values by their ID's and saving them to variables 
            double consumption = Convert.ToDouble(values["Consumption"]);
            double distance = Convert.ToDouble(values["Distance"]);

           // CalculateCost(cost, consumption, distance);
            return Json(CalculateCost(cost, consumption, distance));
        }

        private double CalculateCost(double cost, double consumption, double distance)
        {
            double total_fuel_amount = (consumption / 100) * distance;
            double total_cost = total_fuel_amount * cost;
            return total_cost;
        }


    }
}