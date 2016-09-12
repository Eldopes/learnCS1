using System;
using System.Collections.Generic;
using System.Text;



namespace LearnCS1
{
    public class CodeFile1
    {
        public static void Lesson1() // LISTS #1
        {
            Console.WriteLine("Lesson 1 func was called");

            List<int> numbers = new List<int>(); 
            // numbers.Add(1); // adding value to list            
            numbers.AddMany(1, 2, 3, 4, 5, 6, 7, 8, 9, 10); // for AddMany method look  Helper class 

            int element_index = numbers.IndexOf(2); // save index of number "2" into variable
            numbers.RemoveAt(element_index); // remove element with the specified index (element_index)  from List 
            Console.WriteLine(numbers.Count); // count the numbers list to check if element is really removed

            // Helper.WriteAll(1, 500);       

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

            prices.Add("Orb of Fusing", "1/2"); //  adding values to dictionary 
            prices.Add("Orb of Alchemy", "1/3");
            prices["Orb of Alteration"] = "1/14"; // adding values to dictionary #2
                                                  //  prices.Remove("Orb of Alchemy"); // removing values from dictionary

            foreach (var pair in prices) // dictionary values output
            {
                Console.Write(pair.Key + " = ");
                Console.WriteLine(pair.Value + " Chaos Orb");

            }

            if (prices.ContainsKey("Orb of Alchemy")) // check if dictinary contains a specific key 
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }

        }

        public static void Lesson4() // STRINGS
        {
            Console.WriteLine("Lesson 4 func was called =>\n ");
            
            string pisyaVrot = String.Empty; // creating an empty sting
            pisyaVrot += "pisyavrot tebe";  // adding one string to another
            
            string pisyaVnos = "OOPS";
            string concatenated = pisyaVrot + "__" + pisyaVnos;


            Console.WriteLine(pisyaVrot);
            Console.WriteLine(pisyaVnos);
            Console.WriteLine(concatenated);

        }
    }
}
