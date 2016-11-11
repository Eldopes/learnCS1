using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesExample
{
    class Program
    {
        delegate void Pow(int x); // defining delegates outside of a method (Delegate is a reference to method. To use delegate, initializing it's object is a must)
        delegate void Answer(string x);

        static void Main(string[] args)
        {
            Pow somenumber; // initializing object of a delegate
            Answer blahblah; 
            
           string input = Console.ReadLine();

           if (AllIsNumeric(input) == true)
            {
                somenumber = numberDegree;
                somenumber.Invoke(Convert.ToInt32(input));
            }
           else
            {
                blahblah = stringDisplay;
                blahblah.Invoke(input);
            }            
            

        }
        
        private static void numberDegree(int x)
        {
            Console.WriteLine(Math.Pow(x, 2));
        }

        private static void stringDisplay(string y)
        {
            Console.WriteLine(String.Format("Your input was a string: {0}", y));
        }

        static bool AllIsNumeric(object input) // Helper method to check if input contains ONLY numbers
        {
            foreach (var item in input.ToString())
            {
                if (Char.IsNumber(item) == false) { return false; }
            }

            return true;
        }
        

    }
}
