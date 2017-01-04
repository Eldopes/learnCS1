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
                { -5, 2, 9 },
                { "end", null, null }  
            };

            int rowLength = input.GetLength(0) - 1; // 3
            int columnLength = input.GetLength(1); // 3

            object[,] newInput = new object[rowLength, columnLength];
            for (int row = 0; row < rowLength; row++)
            {
                for (int column = 0; column < columnLength; column++)
                {
                    newInput[row, column] = input[row, column];
                }
            }

            

            object[,] output = new object[rowLength, columnLength]; // i. e new object [4, 3]
            int one, two, three, four; 

            for (int row = 0; row < rowLength; row++)
            {
                for (int column = 0; column < columnLength; column++)
                {
                    try
                    {
                        one = Convert.ToInt32(newInput[row - 1, column]);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        one = Convert.ToInt32(newInput[newInput.GetLength(0) - 1, column]);
                    }

                    try
                    {
                        two = Convert.ToInt32(newInput[row + 1, column]);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        two = Convert.ToInt32(newInput[0, column]);
                    }

                    try
                    {
                        three = Convert.ToInt32(newInput[row, column - 1]);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        three = Convert.ToInt32(newInput[row, newInput.GetLength(1) - 1]);
                    }

                    try
                    {
                        four = Convert.ToInt32(newInput[row, column + 1]);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        four = Convert.ToInt32(newInput[row, 0]);
                    }
                                                     


                    output[row, column] = one + two + three + four;                 
                }
                
            }  
                    
        }        
      
     
    }   
       
}

