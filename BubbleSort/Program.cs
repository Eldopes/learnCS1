using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] to_sort = new int[] { 82, 32, 27, 9, 7, 45, 1050, 588, 1 };
            BubbleSort( to_sort);
       
            foreach (var item in to_sort)
            {
                Console.WriteLine(item);
            } 
        }

        static void BubbleSort(int[] to_sort)
        {

            for (int i = 0; i < (to_sort.Length - 1); i++)
            {         
                for (int j = 0; j < (to_sort.Length - i - 1); j++)
                {
                    if (to_sort[j] > to_sort[j + 1])
                    {
                        int temp = to_sort[j];
                        to_sort[j] = to_sort[j + 1];
                        to_sort[j + 1] = temp;                  
                    }
                }
            }

        }


    }
}


