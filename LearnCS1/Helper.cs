using System;
using System.Collections.Generic;


// extra Class for adding multiple values to lists

namespace LearnCS1
{
    public static class Helper
    {   // below in this class we define universal methods (a method with parameters of given type) 

        public static void AddMany<T>(this List<T> list, params T[] values) // for adding multiple values to a list 
        {
            list.AddRange(values);
        }

        public static void EvenOutput( int start, int end) // outputs all even values from start to end
        {
            while (start <= end)
            {
                if (start % 2 == 0)
                {
                    Console.WriteLine(start);                    
                }
                start++;
            }
        }

        public static void UnEvenOutput(int start, int end) //  outputs all uneven values from start to end
        {
            while (start <= end)
            {
                if (start % 2 == 1)
                {
                    Console.WriteLine(start);
                }
                start++;
            }
        }


    }
}

