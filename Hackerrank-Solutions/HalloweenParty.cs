using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackerrank_Solutions
{
    public class HalloweenParty
    {
        private static string[] inputs = new string[] { "5", "5", "6", "7", "8", Math.Pow(10, 7).ToString() };
        private static string[] output = new string[] { "6", "9", "12", "16" };

        public void Test()
        {
            int testcases = int.Parse(inputs[0]);
            for (int i = 1; i <= testcases; i++)
            {
                long k = int.Parse(inputs[i]);
                // to get the maximun number of chocolates the cuts needs to be half horizontal and half vertical
                long vertical = k / 2;
                long horizontal = k - vertical; // this is for when the number of cuts is odd
                Console.WriteLine(vertical * horizontal);
            }
            Console.ReadKey();
        }
    }
}
