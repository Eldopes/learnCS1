using System;
using System.Diagnostics;
// Тестовые модули
using Ramax.TestApp.SomeSpace;
using B = Ramax.TestApp.AnotherSpace.B;
using Ramax.TestApp.AnotherSpace; // added this one 

namespace Ramax.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new A();
            var b = new B(5);

            Debug.Assert(a.Number == 3);
            Debug.Assert(a.Calculate(2) == 2 * 2 * 3);
            Debug.Assert(b.Calculate(10, 4) == 10 * 4 * 5);

            Debug.Assert(a.IsFirst == true);
            Debug.Assert(a.IsSecond == false);
            Debug.Assert(b.IsFirst == false);
            Debug.Assert(b.IsSecond == true);

            Debug.Assert(a is First);
            Debug.Assert(b is Second);
            Debug.Assert(a is Parent);
            Debug.Assert(b is Parent);

            try
            {
                a.Calculate(7);
                Debug.Assert(false);  
            }
            catch (MyException exc)
            {
                Debug.Assert(exc.Message == "Error text");
            }

            try
            {
                a.IsSecond = true;
                Debug.Assert(false);   
            }
            catch (ArgumentException)
            {

            }
            Console.WriteLine("done");
        }
    }
 

    class Parent { }

    public class MyException : Exception
    {
        public MyException(string message)
        : base(message)
        {
        }
    }

    namespace SomeSpace
    {
        class First : Parent { }

        class A : First
        {
            public int Number = 3;
            public bool IsFirst = true;
            public bool IsSecond
                {
                get { return false; }
                set { throw new ArgumentException(); }
                }      
            public int Calculate(int a_one)
                {
                if (a_one == 7)
                    {
                        throw (new MyException("Error text"));
                    }
                return 2 * 2 * 3;
                }
        }
    }    
 
    namespace AnotherSpace
    {
        class Second : Parent
        { }

        class B : Second
        {
            public B(int arg)
            { }               
   
            public bool IsFirst = false;
            public bool IsSecond = true;

            public int Calculate(int b_one, int b_two)
            {
                return 10 * 4 * 5;
            }
        }
    }
}
