using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace RegSearcher
{
    class Helper
    {
        public static bool SearchLine(StringBuilder input , string reg )
        {        

            Regex r = new Regex(reg); // new regex object 
            Match result = r.Match(input.ToString()); // returns String.Empty if match is not found 

            if (string.IsNullOrEmpty(result.ToString()))
            {
                return false;
            }

            return true;
        }
    }
}
