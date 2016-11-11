using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueAndReference
{
    class Program
    {
        static public void Main(string[] args)
        {
            int i = 10;
            string s = "Hello, world";

            Console.WriteLine("i = " + i);
            //  ModifyInt(i);
            ModifyRefInt(ref i);
            Console.WriteLine("i = " + i);

            Console.WriteLine("s = " + s);
            //   ModifyString(s);
            ModifyRefString(ref s);
            Console.WriteLine("s = " + s);
        }

        static void ModifyInt(int i) 
        {
            i = 99;
        }

        static void ModifyString(string s)
        {
            s = "Hello, I've been modified.";
        }

        static void ModifyRefInt(ref int i) // passed by reference, so now the main method object is modified 
        {
            i = 99;
        }

        static void ModifyRefString(ref string s) // passed by reference, so now the main method object is modified 
        {
            s = "Hello, I've been modified.";
        }
    }
}
