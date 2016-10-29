using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LargeParser
{
    public class GlobalData
    {
        public static Dictionary<string, int> parcedResults = new Dictionary<string, int>(); // global dictionary for storing the result
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Input stream:
            try
            {
             //   using (StreamReader sr = File.OpenText("C:\\Users\\Eugene\\OneDrive\\war_and_peace.txt"))
                using (StreamReader sr = File.OpenText("D:\\Downloads\\log\\log.txt"))
                {
                    Console.OutputEncoding = Encoding.Unicode;
                    StringBuilder input = new StringBuilder();

                    while (!sr.EndOfStream)
                    {
                        input = input.Append(sr.ReadLine().ToLower()); // append the stream-read line to the stringbuilder                            
                        Parse(input);
                        input.Clear();
                    }
                }
                }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            // Output stream:
            List<KeyValuePair<string, int>> sortedResults = (from pair in GlobalData.parcedResults orderby pair.Value descending select pair).ToList(); // sorting the dictionary and packing it to list 

            try
            {
               //   using (StreamWriter sw = new StreamWriter("C:\\Users\\Eugene\\OneDrive\\parse_result\\result_new.txt"))
                using (StreamWriter sw = new StreamWriter("D:\\Downloads\\log\\log_result.txt"))
                {

                    foreach (KeyValuePair<string, int> kv in sortedResults)
                    {
                        sw.WriteLine("{0} => {1}", kv.Key, kv.Value);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot write ot file:");
                Console.WriteLine(e.Message);
            }
            
        }

        static void Parse(StringBuilder input)
        {
             
             string pattern = "[\\p{P}+|\\s+|\\t|\\n|\\r]"; // pattern for regular expression parsing (punctuation marks + tabulation + Next line + carriage return)
             string[] splitted = Regex.Split(input.ToString(), pattern);
            
            foreach (var item in splitted)
            {
                if (GlobalData.parcedResults.ContainsKey(item))
                {
                    GlobalData.parcedResults[item]++; // if contains => increment existing value by 1                                   
                } 
                else if (!string.IsNullOrEmpty(item) /* to remove null values */ ) 
                {
                    GlobalData.parcedResults.Add(item, 1); // if not => add with a value of 0    
                } 
            }                 
           
        }
    }
}
