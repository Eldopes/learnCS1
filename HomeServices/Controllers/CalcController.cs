using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeServices.Models; // using custom model class "Consumption"
using System.Collections.Specialized;
using System.Web.Script.Serialization; // for json serialization
using Newtonsoft.Json.Linq; // new library for json parsing 


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
            JsonResult result = CalculateCost(to_calc); // invokes calculation method and seves the result of type "JsonResult"
            return result; // successfully returning the result of type "JsonResult" to view (TEST)
        }

        private JsonResult CalculateCost(object to_calc) // TODO: JSon parsing via JSON.net and calculation 
        {
            string data_json = new JavaScriptSerializer().Serialize(to_calc); // getting json from object
            JObject elements = JObject.Parse(data_json); // parsing json to get key-value pairs 
                        
            //  var value = GetValue(elements);
            //   Jobject  smth like this  

            return Json(to_calc); // returns the result of calculation to GetCost method 
        }

    }
}