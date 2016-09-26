using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodOverloading
{
    class Program
    {
        static void Main(string[] args)
        {
            FunWithObjects();
        }

        static void FunWithObjects()
        {
            int[] integers = new int[2] { 2, 3 }; // simple array of integers (not used in example)
            object[] stuff = new object[4] {1, false, "Hitler", 3}; // array of objects

            foreach (var obj in stuff)
            {
                Console.WriteLine("Value: {0}  => Type: {1}", obj, obj.GetType());
            }
        }

    }
}
