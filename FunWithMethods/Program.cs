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
            Console.WriteLine("Out method example");
            Console.WriteLine("Addition: {0}", add);
            Console.WriteLine("Dimension: {0}", dim);
            Console.WriteLine();

            // FOR "ref method"
            Console.WriteLine("Ref method example");
            string what = "pisya ";
            string where = "v rotik ";
            Console.WriteLine(what + where); // before the replacement
            SwapPlaces(ref what, ref where);
            Console.WriteLine(what + where); // after the replacement 
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

    }
}
