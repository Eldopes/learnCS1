using System;


namespace TwoDimArray
{
    class Program
    {       
        static void Main(string[] args)
        {
             object[,] input = new object[,] // input array
            {
                { 9, 5, 3 },
                { 0, 7, -1 },
                { -5, 2, 9 },
                { "end", null, null }  
            };

            int rowLength = input.GetLength(0) - 1; // getting rid of the "end" element
            int columnLength = input.GetLength(1);

            int[,] newInput = new int[rowLength, columnLength];
            for (int row = 0; row < rowLength; row++)
            {
                for (int column = 0; column < columnLength; column++)
                {
                    newInput[row, column] = Convert.ToInt32(input[row, column]);
                }
            }
                        

            int[,] output = new int[rowLength, columnLength]; 
            int one, two, three, four; 

            for (int row = 0; row < rowLength; row++)
            {
                for (int column = 0; column < columnLength; column++)
                {
                    try
                    {
                        one = newInput[row - 1, column];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        one = newInput[newInput.GetLength(0) - 1, column];
                    }

                    try
                    {
                        two = newInput[row + 1, column];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        two = newInput[0, column];
                    }

                    try
                    {
                        three = newInput[row, column - 1];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        three = newInput[row, newInput.GetLength(1) - 1];
                    }

                    try
                    {
                        four = newInput[row, column + 1];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        four = newInput[row, 0];
                    }                                                 

                    output[row, column] = one + two + three + four;                 
                }                
            }                      
        } 
    }         
}

