using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static RegSearcher.Helper;
using OfficeOpenXml; // loading EPPlus for excel management
using OfficeOpenXml.Drawing;


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

            Environment.Exit(Searcher(extension, reg, path) == true ? 1 : 0); // returns 1 if found and 0 if not
        }

        static bool Searcher(string extension, string reg, string path) // detects file extension and calls the needed method
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

            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    StringBuilder input = new StringBuilder();

                    while (!sr.EndOfStream)
                    {
                        input = input.Append(sr.ReadLine()); // append the stream-read line to the stringbuilder                            
                        if (SearchLine(input, reg)) // if Searching the line for reg match returns true => ParseTxt() is successfull and returns true
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
                Console.WriteLine(e.Message);
            }

            return false;
        }

        static bool ParseXlsx(string reg, string path)
        {
            Console.WriteLine("Parsing Xlsx");

            try
            {
                var package = new ExcelPackage(new FileInfo(path));

                ExcelWorksheet workSheet = package.Workbook.Worksheets.First();
                var start = workSheet.Dimension.Start;
                var end = workSheet.Dimension.End;

                for (int row = start.Row; row <= end.Row; row++) // Iterating through our excel spreadsheet: 
                { // Row by row...
                    for (int col = start.Column; col <= end.Column; col++)
                    { // Cell by cell...
                        string cellValue = workSheet.Cells[row, col].Text.ToString(); // The actual cell value to search the reg in  
                        StringBuilder input = new StringBuilder();
                        input.Append(cellValue);

                        if (SearchLine(input, reg)) // if Searching the line for reg match returns true => ParseXlsx() is successfull and returns true
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            return false;
        }
    }
}
