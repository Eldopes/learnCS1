using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // FOR "out method"
            int add, dim;
            Arithmetic(12, 13, out add, out dim); // the parameters "one" and "two" aren't assigned, the Addition method does the assignment upon calling
                Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Out method example");
                Console.ResetColor();
            Console.ResetColor();
            Console.WriteLine("Addition: {0}", add);
            Console.WriteLine("Dimension: {0}", dim);
            Console.WriteLine();


            // FOR "ref method"
                Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Ref method example");
                Console.ResetColor();
            string what = "pisya ";
            string where = "v rotik ";
            Console.WriteLine(what + where); // before the replacement
            SwapPlaces(ref what, ref where);
            Console.WriteLine(what + where); // after the replacement
            Console.WriteLine();

            // FOR "params methhod"
                Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Params method example"); 
                Console.ResetColor();
            Console.WriteLine(CalculateAverage(2.5, 3, 4)); // passing a bunch of double values
            double[] retards = new double[] {10, 20, 30, 35.5};
            Console.WriteLine(CalculateAverage(retards)); // passing an array of doubles
            Console.WriteLine();

            // FOR methods with optional perameters
                Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Method with optional perameters example:");
                Console.ResetColor();           
            JewsSurvived("Moishe");
            JewsSurvived("Moishe", "Moshiah", "Aaron");

            // FOR methods with named aruments
                Console.ForegroundColor = ConsoleColor.Yellow; 
            Console.WriteLine("Method with named arguments example:");
                Console.ResetColor();           
            NamedArgsTesting(1, "Pisya", DateTime.Now); // normal argument order
            Console.WriteLine();
            NamedArgsTesting(b: "Pisya", a: 1, c: DateTime.Now); // named argument order
        }

        static void Arithmetic(int one, int two, out int add, out int dim) // "out" methods are designed to return multiple values (not actually  physical "return" though)
        {
            add = one + two; // "out" method itself assigns  parameters before exiting. Therefore, the parameters "one" and "two" should not be assigned in the Main method
            dim = one - two;
        }

        static void SwapPlaces(ref string what, ref string where) // "ref" methods are designed to make operations with outer data, therefore the variables should already be assigned outside
        {
            string temporary = what; // temporary string to save value
            what = where;
            where = temporary;  
        }

        static double CalculateAverage(params double [] values) // params methods can take any number of arguments (either an array or just a bunch of variables of the same type that can be treated as an array)
        {
            Console.WriteLine("Calculating the average value...");
            double sum = 0;
            foreach (var i in values)
            {
                sum += i;
            }
            return sum / values.Length;
        }

        static void JewsSurvived(string survivor_1, string survivor_2 = "Rebe", string survivor_3 = "Sara") // optional parameters can either be passed to method or taken as dafault
        {
            Console.WriteLine("Survivor: {0}", survivor_1);
            Console.WriteLine("Survivor: {0}", survivor_2);
            Console.WriteLine("Survivor: {0}", survivor_3);
            Console.WriteLine();
        }

        static void NamedArgsTesting(int a, string b, DateTime c) 
        {
            Console.WriteLine("Your number: {0}, your string: {1}, date: {2}", a, b, c);                       
        }



    }
}
