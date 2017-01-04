using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoDimArray
{
    class Program
    {
       
        static void Main(string[] args)
        {
             object[,] input = new object[,]
            {
                { 9, 5, 3 },
                { 0, 7, -1 },
                { -5, 2, 9 } /* ,
                { "end", null, null } */ //TODO: get rid of this 
            };
                       

            object[,] output = new object[ActualLength(input), input.GetLength(1)]; // i. e new object [4, 3]
            int one, two, three, four; 

            for (int row = 0; row < ActualLength(input); row++)
            {
                for (int column = 0; column < input.GetLength(1); column++)
                {
                    try
                    {
                        one = Convert.ToInt32(input[row - 1, column]);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        one = Convert.ToInt32(input[ActualLength(input) - 1, column]);
                    }

                    try
                    {
                        two = Convert.ToInt32(input[row + 1, column]);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        two = Convert.ToInt32(input[0, column]);
                    }

                    try
                    {
                        three = Convert.ToInt32(input[row, column - 1]);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        three = Convert.ToInt32(input[row, input.GetLength(1) - 1]);
                    }

                    try
                    {
                        four = Convert.ToInt32(input[row, column + 1]);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        four = Convert.ToInt32(input[row, 0]);
                    }
                                                        


                    output[row, column] = one + two + three + four;                 
                }
            }          
        }          
       
        static int ActualLength(object [,] input)
        {
            //  Console.WriteLine(input.GetLength(0));
            return input.GetLength(0); // - 1;
        }
    }   
       
}

