using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace RegSearcher
{
    class Program
    {
        static void Main(string[] args)
        {
            string extension, path, reg;
            extension = path = reg = String.Empty; 
                  
            try
            {
                path = args[0]; // 1st argument = path
                reg = args[1]; // 2nd argument = regular expression

                extension = Path.GetExtension(path);
            }
            catch (Exception e)
            {
                Console.WriteLine("Path or regular expression is incorrect:");
                Console.WriteLine(e.Message);
            }
       
              
            Environment.Exit(Searcher(extension, reg, path) == true ? 1 : 0); // returns 1 if found
        }

        static bool Searcher( string extension, string reg, string path )
        {
            switch (extension)
            {
                case ".txt":
                    return ParseTxt(reg, path);
                case ".xlsx":
                    return ParseXlsx(reg, path);
                default:
                    Console.WriteLine("Wrong file extension");
                    return false;
            }
        }

        static bool ParseTxt(string reg, string path)
        {
            Console.WriteLine("Parsing text");



/*


            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    Console.OutputEncoding = Encoding.Unicode;
                    StringBuilder input = new StringBuilder();

                    while (!sr.EndOfStream)
                    {
                        input = input.Append(sr.ReadLine().ToLower()); // append the stream-read line to the stringbuilder                            
                        Parse(input); // TODO parse by line here (not regex.split but regex.find)
                        input.Clear();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }


    */













            return true; // if found 
        }

        static bool ParseXlsx(string reg, string path)
        {
            Console.WriteLine("Parsing excel");

            return false; // if found
        }
    }
}
