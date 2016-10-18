using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hackerrank_Solutions.generalpractice
{
    public class UsingRegularExpressions
    {
        public void Test()
        {
            definingARegex();
        }

        public void definingARegex()
        {
            // using "@" before the string is for using "verbatim string literals", it is useful to avoid using escape characters
            // @"C:\GIT\hackerrank-problems" is equals to "C:\\GIT\\hackerrank-problems"

            Regex regex = new Regex(@"x*y"); // x*y
        
            Match match = regex.Match("xxxy");
            if (match.Success)
                Console.WriteLine("regex: {0} --> match sequence: {1}",regex, match.Value);

            match = regex.Match("cccxxxxxxyyyyy");
            if (match.Success)
                Console.WriteLine("regex: {0} --> match sequence: {1}", regex, match.Value); // there is a match with the last part of the sequence

            // \b is the boundary of the expression, if you don't define the boundary there will match when the sequence contais the regex
            regex = new Regex(@"\bx*y\b");

            match = regex.Match("xxxy");
            if (match.Success)
                Console.WriteLine("regex: {0} --> match sequence: {1}", regex, match.Value);

            match = regex.Match("cccxxxxxxyyyyy");
            if (match.Success)
                Console.WriteLine("regex: {0} --> match sequence: {1}", regex, match.Value);
            else
                Console.WriteLine("regex: {0} --> NOT match sequence: {1}", regex, "cccxxxxxxyyyyy");

        }
    }
}
