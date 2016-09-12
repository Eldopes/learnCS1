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
        
        public static void WriteAll( int start, int end) // for simply writing all values in a given range from start to end
        {
            // пока не то что нужно, надо убрать 
              while (start < end)
              {
                  //list.Add(start);
                  Console.WriteLine(start);
                  start++; 
              }                           
        }
        

    }
}

