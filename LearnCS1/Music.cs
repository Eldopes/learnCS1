using System;
using System.Threading;
using System.Threading.Tasks;


namespace LearnCS1
{
    class Music 
    {
        public static void Cherry() // Beeping !  ( TO DO: Make it async for melody legato)
        {           

            Beeping(659, 500); // Beep(frequency, duration)
            Beeping(587, 500);                

            Beeping(659, 500);
            Beeping(440, 700);
            Beeping(370, 500);
            Beeping(440, 500);
            Beeping(587, 700);
            Beeping(587, 700);
            Beeping(494, 600);                 

        }       


        public static  void Beeping(int freq, int dur)
        {
            Console.Beep(freq, dur);            
        }
        

    }
}
