using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Trying to catch exceptions here (example: simple calculation app)

namespace CatchingExceptions
{
    public class WrongInputException : System.Exception // making a class thet contains our exception (we extend it from System.Exception)
    {
        public WrongInputException(string message) : base(message) // our new exception (can accept string argument for message posting, which also inherits from base message )
        {}
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            { // checking input for correct string => Int conversion project - wide  (can also be done in Visual Studio preferences)
                    Console.WriteLine("******Simple Console calculator (can catch exceptions)******");
                    Console.WriteLine();
                    Console.WriteLine("First number ?");

                    int first = int.Parse(Console.ReadLine()); // 1st num              
                    Console.WriteLine("Operation ?");
                    string operation = Console.ReadLine(); // operation
                    Console.WriteLine("Second number ?");
                    int second = int.Parse(Console.ReadLine()); // second num

                    try // try the next block of code to see if we can catch our custom defined Exception
                    {
                        switch (operation)
                        {
                            case "+":
                                Console.WriteLine("Result: {0}", Addition(first, second));
                                break;
                            case "-":
                                Console.WriteLine("Result: {0}", Dimension(first, second));
                                break;
                            case "*":
                                Console.WriteLine("Result: {0}", Multiplication(first, second));
                                break;
                            case "/":
                                try
                                {
                                    Console.WriteLine("Result: {0}", Division(first, second)); // Here we try to catch standard zero division exception
                                }
                                catch (DivideByZeroException)
                                {
                                    Console.WriteLine("ACHTUNG! You've tried to divide {0} by ZERO!", first);
                                }
                                break;
                            default:
                                throw new WrongInputException("INCORRECT INPUT DATA"); //  We defined our program to throw our custom exception when input data is incorrect.                              
                        }
                    }
                    catch (Exception WrongInputException) // here we catch our custom exception if input was incorrect
                    {
                        Console.WriteLine("Wrong input detected: {0}", WrongInputException);
                    }

            }
            catch (FormatException)
            {
                Console.WriteLine("Wrong format input!"); // catching the incorrect string => ToInt32 conversion
            }
        }
        
        static int Addition(int x, int y)
        {
            return x + y;
        }

        static int Dimension(int x, int y)
        {
            return x - y;
        }

        static int Multiplication(int x, int y)
        {
            return x * y;
        }

        static int Division(int x, int y)
        {
            return x / y;
        }

    }

}
