using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackerrank_Solutions.generalpractice
{
    public class UsingConversions
    {
        public void Test()
        {
            simpleConversions();
        }

        private void simpleConversions()
        {
            // String to int
            int numberI = int.Parse("1234");
            Console.WriteLine("int: " + numberI);

            // String to float
            float numberF = float.Parse("1234.123");
            Console.WriteLine("float: " + numberF);

            // String to double
            double numberD = double.Parse("1234567.1234567");
            Console.WriteLine("double: " + numberD);

            // String to char array
            char[] charArray = "this is a text".ToArray();
            Console.WriteLine("charArray[0]: " + charArray[0]);

            // String to String[]
            String[] stringArray = "this,is,a,comma,separated,text".Split(',');
            Console.WriteLine("stringArray[0]: " + stringArray[0]);

            // String to int[]
            String[] stringArrayOfNumber = "1 5 3 123 564".Split();
            int[] intArray = Array.ConvertAll(stringArrayOfNumber, int.Parse);
            Console.WriteLine("intArray[4]: " + intArray[4]);
        }
    }
}
