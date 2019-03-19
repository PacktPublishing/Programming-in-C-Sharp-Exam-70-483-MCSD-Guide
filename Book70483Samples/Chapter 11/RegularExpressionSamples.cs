using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Chapter11
{
    internal class RegularExpressionSamples
    {
        public void ReplacePatternText()
        {
            string pattern = "(FIRSTNAME\\.? |LASTNAME\\.?)";

            string[] names = { "FIRSTNAME. MOHAN", "LASTNAME. KARTHIK" };
            foreach(string str in names)
            {
                Console.WriteLine(Regex.Replace(str, pattern, String.Empty));
            }
            
        }

        public void MatchPatternText()
        {
            string pattern = "(Madhav\\.?)";

            string names = "Srinivas Madhav. and Madhav. Gorthi are same";
            MatchCollection matColl = Regex.Matches(names, pattern);
            foreach (Match m in matColl)
            {
                Console.WriteLine(m);
            }
        }

        public void IsMatchPattern()
        {
            string pattern = @"^c\w+";

            string str = "this sample is done as part of chapter 11";
            string[] items = str.Split(' ');
            foreach (string s in items)
            {
                if (Regex.IsMatch(s, pattern))
                {
                    Console.WriteLine("chapter exists in string str");
                }
            }
        }

    }
}
