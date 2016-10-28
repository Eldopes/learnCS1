using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Diagnostics; // for tracking process memory usage

namespace WordParser
{
    class UltimateReturner
    {

        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.Unicode; 
            string input = string.Empty;            

            // Open the text file using a stream reader.
            try
                {
                  using (StreamReader sr = new StreamReader("C:\\Users\\Eugene\\OneDrive\\war_and_peace.txt", Encoding.GetEncoding("Unicode")))
              //  using (StreamReader sr = new StreamReader("D:\\Downloads\\log\\log.txt", Encoding.GetEncoding("Unicode")))
                    {

                    input = sr.ReadToEnd().ToLower(); // Read the stream to a string

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(e.Message);
                }

            // Write to  the text file using a stream writer.
                try
                {
                using (StreamWriter sw = new StreamWriter("C:\\Users\\Eugene\\OneDrive\\parse_result\\result.txt"))               
                {

                    foreach (KeyValuePair<string, int> kv in Parse(input))
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

        static IDictionary<string, int> Parse(string input)
        {            
            string pattern = "[\\p{P}+|\\s+|\\t|\\n|\\r]"; // pattern for regular expression parsing (punctuation marks + tabulation + Next line + carriage return)          

            string [] splitted = Regex.Split(input, pattern);
            Dictionary<string, int> parcedResults = new Dictionary<string, int>(); // new dictionary for storing the parsed results

            foreach (var line in splitted.GroupBy(value => value).                 
                        Select(group =>
                        new {
                             Metric = group.Key,
                             Count = group.Count()
                         })
                        .OrderByDescending(x => x.Count))     // descending sorting the object by count                   
              {
                parcedResults.Add(line.Metric, line.Count); // adding parced results to our dictionary (already sorted in the right way)
              }
            parcedResults.Remove(""); // removing null values 

            return parcedResults;
        }
    }
}
