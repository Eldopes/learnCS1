using System;
using System.Collections.Generic;
using System.Text;



namespace LearnCS1
{
    public class BasicSyntax
    {
        public static void Task1() // LISTS #1 
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

        public static void Task2()  // LISTS #2 
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

        public static void Task3() // DICTIONARIES 
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

        public static void Task4() // STRINGS #1 
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

        public static void Task5() // STRINGS #2  
        { // string formatting illustrated 
            string person = "Adolf Hitler"; 
            int day = 20;
            string month = "April";
            int year = 1889;

            string theBirth = String.Format("{0} was born on the {1}-th of {2}, {3}", person, day, month, year); 
            //returns the formatted string (we are addressing the defined above variables by their indexes)
            Console.WriteLine(theBirth);
        }

        public static void Task6() // STRINGS #3  
        { // Substring, Replace< Indexof methods illustrated 
            string fullstring = "ingloriooooooooous"; // Base string for all experimaents

            string from3 = fullstring.Substring(3); // Substring methord starts extracting symbols starting from the 3rd character
            string from3to5 = fullstring.Substring(3, 5); // Substring methord starts extracting symbols starting from the 3rd character, and stops on 5th character

            string to_replace = "0"; // will be replaced by this
            string fullstring_replaced = fullstring.Replace("o" ,to_replace); // o's will be replaced by 0
                      
     /*       Console.WriteLine(fullstring);
            Console.WriteLine(from3);
            Console.WriteLine(from3to5);
            Console.WriteLine(fullstring_replaced); // Output: o's are replaced by 0s   */

            Console.WriteLine(fullstring.IndexOf("o")); // finding out the first occurence of string "o" in string fullstring
            Console.WriteLine(fullstring_replaced.IndexOf(to_replace)); // finding out the first occurence of string to_replace in string fullstring_replaced
        }
        
        public static void Task7()  // for loops 
        { 
              Helper.EvenOutput(1, 1000);  // for the definitions see helper class 
              Helper.UnEvenOutput(1, 1000); 
        }

        


    }

    }

