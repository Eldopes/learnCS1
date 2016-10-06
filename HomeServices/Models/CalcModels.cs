using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeServices.Models
{
    public class FuelInfo // building custom class to represent data sent from ajax to Calc controller's CalculateCost Action
    {
        public string Consumption { get; set; } // represent methods  getValue() and setValue()
        public string Cost { get; set; }
    }
}