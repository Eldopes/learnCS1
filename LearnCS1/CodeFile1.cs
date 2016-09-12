using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LearnCS1
{
    public class CodeFile1
    {
        public static void Lesson1() // LISTS #1
        {
            Console.WriteLine("Lesson 1 func was called");

            List<int> numbers = new List<int>(); 
            // numbers.Add(1); // adding value to list            
            numbers.AddMany(1, 2, 3, 4, 5, 6, 7, 8, 9, 10); // for AddMany method look  ExtendedLists class 

            int element_index = numbers.IndexOf(2); // save index of number "2" into variable
            numbers.RemoveAt(element_index); // remove element with the specified index (element_index)  from List 
            Console.WriteLine(numbers.Count); // count the numbers list to check if element is really removed

            // ExtendedLists.WriteAll(1, 500);       

            /*  foreach (int i in numbers) // list values output
                    {
                    Console.WriteLine(i); 
                    } */
        }

        public static void Lesson2()  // LISTS #2
        {
            Console.WriteLine("Lesson 2 func was called =>\n ");
            
            List<string> pidory = new List<string>();
            pidory.AddMany("Grisha", "Vova");
            List<string> gomoseki = new List<string>();
            gomoseki.AddMany("Cheegr", "Den");
            gomoseki.AddRange(pidory); // adding list "pidory" to list "gomoseki"
            
            /* foreach (string i in pidory) // list values output
                {
                Console.WriteLine(i); 
                } */
             foreach (string i in gomoseki) // list values output
                {
                    Console.WriteLine(i);
                }
        }

        public static void Lesson3() // DICTIONARIES #1
        {
            Console.WriteLine("Lesson 3 func was called =>\n ");

            Dictionary<string, string> prices = new Dictionary<string, string>(); // Dictionary is a key => value data structure, like a hash in ruby 
            
            prices.Add("Orb of Fusing", "1/2");
            prices.Add("Orb of Alchemy",  "1/3");            
            prices["Orb of Alteration"] = "1/14";

            foreach (var pair in prices) // dictionary values output
            {
                Console.Write(pair.Key + " = ");
                Console.WriteLine(pair.Value + " Chaos Orb");              
            }

            if (prices.ContainsKey("Chaos Orb")) // check if dictinary contains a specific key 
            {
                Console.WriteLine("Yes");
            } else
            {
                Console.WriteLine("No");
            }
        }
        // blyat

    }
}
