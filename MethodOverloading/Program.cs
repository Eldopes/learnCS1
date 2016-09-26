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
            FunWithMatrix();
        }

        static void FunWithObjects()
        {
            int[] integers = new int[2] { 2, 3 }; // simple array of integers (not used in example)
            object[] stuff = new object[4] { 1, false, "Hitler", 3 }; // array of objects

            foreach (var obj in stuff)
            {
                Console.WriteLine("Value: {0}  => Type: {1}", obj, obj.GetType());
            }
        }

        static void FunWithMatrix() // also known as two-dimension rectangular array 
        {
            int[,] currency = new int[2,3]; // represents a square structure, where [numner of vertical lines, number of horizontal lines]
            currency[0, 0] = 1;
            currency[0, 1] = 2;
            currency[0, 2] = 3;
            currency[1, 0] = 4;
            currency[1, 1] = 5;
            currency[1, 2] = 6;                

            for (int i = 0; i < 2; i++) // here we use <, not <=, because 1st index in arrays is addressed as 0, not 1
            {
                for (int j = 0; j < 3; j++)
                {
                    
                     Console.WriteLine(currency[i,j]);
                }
            }
        }

        static void FunWithMultiDimArrays()
        {

        }
    }
}
