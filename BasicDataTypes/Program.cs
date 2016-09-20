using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
           // ParseFromStrings();
            UseDatesAndTimes();
        }

        static void ParseFromStrings()
        {
            Console.WriteLine("=>	Data	type	parsing:");
            bool b = bool.Parse("True");
            Console.WriteLine("Value	of	b:	{0}", b);
            double d = double.Parse("99.884");
            Console.WriteLine("Value	of	d:	{0}", d);
            int i = int.Parse("8");
            Console.WriteLine("Value	of	i:	{0}", i);
            char c = Char.Parse("w");
            Console.WriteLine("Value	of	c:	{0}", c);

            Console.WriteLine();
            string z =  d.ToString();
            Console.WriteLine(d.GetType());
            Console.WriteLine(z.GetType());     
        }

        static void UseDatesAndTimes()
        {
           /*           
           Console.WriteLine("=>	Dates	and	Times:");
            //	This	constructor	takes	(year,	month,	day).
            DateTime	dt	=	new	DateTime(1991,	10,	13);
            //	What	day	of	the	month	is	this?
            Console.WriteLine("The	day	of	{0}	is	{1}",	dt.Date,	dt.DayOfWeek);
            //	Month	is	now	December.
            DateTime new_dt =	dt.AddMonths(2); // adding two months, and the date is modified 
            Console.WriteLine("The	day	of	{0}	is	{1}", new_dt.Date, new_dt.DayOfWeek); // printing out the new date 
            */
           
            //	This	constructor	takes	(hours,	minutes,	seconds).
            TimeSpan	ts	=	new	TimeSpan(4,	30,	0); 
            Console.WriteLine(ts);
            //	Subtract	15	minutes	from	the	current	TimeSpan	and		
            //	print	the	result.
            Console.WriteLine(ts.Subtract(new	TimeSpan(0,	15,	0))); 
        } 


        }
}
