using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Loops
{
    class Program
    {
        static void Main(string[] args)
        {
            // WhileLoopExample();
            WhileLoopExample();
            CheckForInput();
            
        }

        static void WhileLoopExample()
        {
            string userIsDone = "";
            //	Test	on	a	lower-class	copy	of	the	string.
            while (userIsDone.ToLower()	!=	"yes")
            {				Console.WriteLine("In	while	loop");
                Console.Write("Are	you	done?	[yes]	[no]:	");
                userIsDone	=	Console.ReadLine();
                Thread.Sleep(1000);
            }
        }

        static void CheckForInput()
        {
            Task mytask = Task.Run(() =>
            {
                int [] repeats = new int[5] { 1, 2, 3, 4, 5 };
                foreach (int item in repeats)
                {
                    Console.WriteLine(item);
                    Thread.Sleep(1000);
                }
               
            });
            mytask.Wait();            
        }



    }
}
