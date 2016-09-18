using System;



namespace LearnCS1
{
    class Music 
    {
        public static void Cherry() // Beeping ! 
        {
            Console.Beep(659, 500); // Beep(frequency, duration)
            Console.Beep(587, 500); 

            Console.Beep(659, 500);
            Console.Beep(440, 700); 

            Console.Beep(370, 500);
            Console.Beep(440, 500);
            Console.Beep(587, 700);
            Console.Beep(587, 700);
            Console.Beep(494, 600);
        }
    }
}
