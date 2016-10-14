using System;
using System.Collections.Generic;
using System.Data.Entity; //Access Entity framework classes 
using System.Linq;
using System.Web;
/*
 * CAR TRIP CALCULATOR => DATA CONTEXT CLASS (to represent the Calc model to Entity Framework )
 * Contains data context for EntityFramework 
 * 
 * */

namespace HomeServices.Models.Calc
{
    public class CalcContext : DbContext // building data context class (extends general DbContext class of Entity Framework )
    { // defining the properties of Data Context class (each froperty stands for working with specific object types)
      
        //  public DbSet<FuelInfo> fuel_list { get; set; } 
        public DbSet<SessionInfo> session_list { get; set; } // properties of type "DBSet" to work with objects of type "SessionInfo". These objects will be stored in a specific table
    }
}