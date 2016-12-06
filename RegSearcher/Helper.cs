using System.Text;
using System.Text.RegularExpressions;

namespace RegSearcher
{
    static class Helper
    {
        public static bool SearchLine(StringBuilder input , string reg )
        {
            Regex r = new Regex(reg); 
            Match result = r.Match(input.ToString()); // returns String.Empty if match is not found 

            if (string.IsNullOrEmpty(result.ToString()))
            {
                return false;
            }

            return true;
        }        
    }
}
