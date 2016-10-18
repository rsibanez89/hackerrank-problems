using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Hackerrank_Solutions.generalpractice
{
    public class UsingNumberLimits
    {
        public void Test()
        {
            // int is 32 bits 2^(32)/2 half for positives and half for negatives
            int intLowerLimit = int.MinValue; // -2,147,483,648
            int intUpperLimit = int.MaxValue; //  2,147,483,647

            Console.WriteLine("int go from {0:0,0} to {1:0,0} | 2^32/2: {2:0,0} ", intLowerLimit, intUpperLimit, Math.Pow(2, 32) / 2);
            Console.WriteLine("breaking the limits: {0:0,0} | {1:0,0}", intLowerLimit - 1, intUpperLimit + 1);

            // long is 64 bits 2^(64)/2 half for positives and half for negatives
            long longLowerLimit = long.MinValue; // -9,223,372,036,854,775,808
            long longUpperLimit = long.MaxValue; //  9,223,372,036,854,775,807
            Console.WriteLine("int go from {0:0,0} to {1:0,0} | 2^64/2: {2:0,0} ", longLowerLimit, longUpperLimit, Math.Pow(2, 64) / 2);

            // BigInteger in theory has no upper or lower limits
            BigInteger bigIntegerLimit = BigInteger.Pow(2, 300);

            Console.WriteLine("{0:0,0}", bigIntegerLimit);
            // ToString used to have some problems to parse more than 50 digits, seems that has been fixed
            Console.WriteLine(bigIntegerLimit.ToString("0,0"));


            float floatLowerLimit = float.MinValue; // -340,282,300,000,000,000,000,000,000,000,000,000,000 = -(2^128)
            float floatUpperLimit = float.MaxValue; //  340,282,300,000,000,000,000,000,000,000,000,000,000 = 2^128
            Console.WriteLine("int go from {0:0,0} to {1:0,0}", floatLowerLimit, floatUpperLimit);
            Console.WriteLine("int go from {0:0,0}", Math.Log10((double)floatUpperLimit) / Math.Log10(2));

            float smallFloat = 1.5E-10f;
            Console.WriteLine(String.Format("{0:f15}", smallFloat));
            smallFloat = 1.5E-20f;
            Console.WriteLine(String.Format("{0:f25}", smallFloat));
            smallFloat = 1.5E-30f;
            Console.WriteLine(String.Format("{0:f35}", smallFloat));
            smallFloat = 1.5E-40f;
            Console.WriteLine(String.Format("{0:f45}", smallFloat));

            // According https://msdn.microsoft.com/en-us/library/9ahet949.aspx
            // The limit is ±1.5e−45, but when I print the number it is not the same.
            // Seems that format have some problems to parse more than 40 decimal digits.
            float floatSmallerLimit = 1.5E-45f; // ±1.5e−45
            Console.WriteLine(String.Format("{0:f50}", floatSmallerLimit));

            double doubleToCheck = 1.5E-45f;
            Console.WriteLine(String.Format("{0:f50}", doubleToCheck));

            if (floatSmallerLimit == doubleToCheck)
                Console.WriteLine("They are equals...");


            float number = 1.5E-5f;
            Console.WriteLine(number);
            Console.WriteLine(String.Format("{0:f50}", floatSmallerLimit));


        }
    }
}
