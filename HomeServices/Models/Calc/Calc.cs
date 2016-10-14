using System;
using System.Collections.Generic;
using System.Data.Entity; //Access Entity framework classes
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
/*
 * CAR TRIP CALCULATOR => MODEL CLASSES
 * Represent data needed for Fuel cost calculator page 
 * 
 * */

namespace HomeServices.Models
{
    // MODEL FUELINFO (to work with ajax)
    public class FuelInfo // building custom class to represent data sent from ajax to Calc controller's CalculateCost Action
    {
        public string Consumption { get; set; } // represent methods  getValue() and setValue()
        public string Cost { get; set; }
        public string Distance { get; set; }
    }

    // MODEL SESSIONINFO (to work with session data and saver it to db)
    public class Session // to represent useful session data we want to save to db 
    {
        public int id { get; set; } 
        public string useragent { get; set; }
        public string result { get; set; }
    }

    public class SessionContext : DbContext // context for Entity Framework
    {
        public SessionContext(): base("DefaultConnection") // not to change web.config, we pass this to default connection
        { }
        public DbSet<Session> Sessions { get; set; }
    }

}