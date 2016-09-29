using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithEnums
{
    class Program
    {
        public enum Consumption : int // enums are user-defined data types that can contain any pre-defined values
        { 
            Vedro = 10, // this enum uses int for its inner data storage
            Hammer = 30,
            Logan = 7
        }

        static void Main(string[] args)
        {
            // var result = GetConsumption(Consumption.Vedro);
            // Console.WriteLine(result);
            Consumption ee = Consumption.Hammer; // make an instance of object ee  of type "consumption"
            // GetEnumTypeViaGetType(ee); // invoking method to get type 
            // GetEnumTypeViaTypeOf(ee);
        }

        public static string GetConsumption(Consumption ee) // passing object of type "consumption" ee as a parameter
        {
            switch (ee)
            {
                case Consumption.Vedro:                    
                    return "A fair one";                    
                case Consumption.Hammer:
                    return "You can't afford that";                    
                case Consumption.Logan:
                    return "Perfect!";                    
                default:
                    return "Wrong Input";
            }            
        }

        public static void GetEnumTypeViaGetType(Consumption ee) // getting underlying type of enum via .GetUnderlyingType() and GetType() methods
        {     // returns the type which was used to build enum data structure      
            Console.WriteLine(Consumption.GetUnderlyingType(ee.GetType())); 
            /* 1) Taking object "ee" of type "consumption" as argument 
             * 1) Getting the type of object "ee":   ee.GetType()
             * 2) passing the result as argument to Consumption.GetUnderlyingType(), and getting the underlying type 
             *
             * !!!! GetType() needs to be cast on the instance of an object, while typeof() doesn't
             */           
        }

        public static void GetEnumTypeViaTypeOf(Consumption ee) // getting underlying type of enum via .GetUnderlyingType() and GetType() methods
        {
            Type t = Consumption.GetUnderlyingType(typeof(Consumption)); // .typeof() takes type as argument (not object of type)
            Console.WriteLine(t);            
        }

    


    }
}
