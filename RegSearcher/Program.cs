using System;
using System.IO;
using System.Text;

using OfficeOpenXml; 

namespace RegSearcher
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime startTime = DateTime.Now;

            // Opening file stream and redirecting console output to log file
            FileStream strm;
            StreamWriter writer;
            TextWriter oldOutput = Console.Out;
            try
            {
                strm = new FileStream("./result.log", FileMode.OpenOrCreate, FileAccess.Write);
                writer = new StreamWriter(strm);
            }
            catch (ArgumentException e)
            {    
                Console.WriteLine("Cannot open result.log for writing");
                Console.WriteLine(e.Message);
                return;
            }
            Console.SetOut(writer);

            // Program logic itself
            Console.WriteLine("Program started at {0}", startTime);
            string extension, path, reg;
            extension = path = reg = String.Empty;

            try
            {
                path = args[0]; // 1st argument = path
                Console.WriteLine("Path is: {0}", args[0]);

                reg = args[1]; // 2nd argument = regular expression to search for
                Console.WriteLine("Regular expression is: {0}", args[1]);

                extension = Path.GetExtension(path);
            }
            catch (Exception e)
            {
                Console.WriteLine("Path or regular expression is incorrect:");
                Console.WriteLine(e.GetType() + ": "+  e.Message);               
            }

            int exitCode = Searcher(extension, reg, path) == true ? 1 : 0; // gathering info for log
            Console.WriteLine("Program exited at {0} with code {1}", DateTime.Now, exitCode);
            Console.WriteLine("Time elapsed: {0}", DateTime.Now.Subtract(startTime));
            

            // removing console output redirect and closing file stream
            Console.SetOut(oldOutput);
            writer.Close();
    
            Environment.Exit(exitCode); // returns 1 if found and 0 if not
        }

        static bool Searcher(string extension, string reg, string path) // detects file extension and calls the needed method
        {
            Console.WriteLine("File extension: {0}", extension);
            switch (extension)
            {
                case ".txt":                   
                    return ParseTxt(reg, path);
                case ".xlsx":
                    return ParseXlsx(reg, path);
                default:
                    Console.WriteLine("This file extension is not supported");
                    return false;
            }
        }

        static bool ParseTxt(string reg, string path) // is called if file extension is .txt
        {
            Console.WriteLine("Parsing text file");         

            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    StringBuilder input = new StringBuilder();

                    while (!sr.EndOfStream)
                    {
                        input = input.Append(sr.ReadLine()); // append the stream-read line to the stringbuilder                            
                        if (Helper.SearchLine(input, reg)) // if Searching the line for reg match returns true => ParseTxt() is successfull and returns true
                        {
                            return true;
                        }
                        input.Clear();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.GetType() + ": " + e.Message);
            }

            return false;
        }

        static bool ParseXlsx(string reg, string path) // is called if file extension is .xlsx
        {
            Console.WriteLine("Parsing xlsx file");

            try
            {
                var package = new ExcelPackage(new FileInfo(path)); // Loading Excel package from the selected path

                for (int i = 1; i <= package.Workbook.Worksheets.Count; i++) // Iterating through all our excel worksheets: 
                {
                    ExcelWorksheet workSheet = package.Workbook.Worksheets[i];
                    var start = workSheet.Dimension.Start;
                    var end = workSheet.Dimension.End;

                    for (int row = start.Row; row <= end.Row; row++) // Iterating through our excel spreadsheet: 
                    { // by row
                        for (int col = start.Column; col <= end.Column; col++)
                        { // by cell
                            string cellValue = workSheet.Cells[row, col].Text.ToString(); // The actual cell value to search the reg in  
                            StringBuilder input = new StringBuilder();
                            input.Append(cellValue);

                            if (Helper.SearchLine(input, reg)) // if Searching the line for reg match returns true => ParseXlsx() is successfull and returns true
                            {
                                return true;
                            }
                        }
                    }
                }                   
                                                
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.GetType() + ": " + e.Message);
            }

            return false;
        }
    }
}



