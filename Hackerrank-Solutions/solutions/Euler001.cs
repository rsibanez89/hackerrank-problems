using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Hackerrank_Solutions
{
    public class Euler001
    {
        public static void Test()
        {
            string[] input = new string[] { "3", 
                                            "10",
                                            "100",
                                            Math.Pow(10,9).ToString()};

            string[] output = new string[] { "23", 
                                             "2318",
                                             "233333333166666668"};

            int nLine = 0;
            int T = int.Parse(input[nLine++]);
            for (int i = 0; i < T; i++)
            {
                int N = int.Parse(input[nLine++]);
                //Console.WriteLine(solution1(N));
                //Console.WriteLine(solution2(N));
                Console.WriteLine(solution3(N));
            }
            Console.WriteLine();
        }

        // This is a O(n) solution that gets timeout result
        private static long solution1(int N)
        {
            long result = 0;
            for (long j = 3; j < N; j += 1)
                if ((j % 3 == 0) || (j % 5 == 0))
                    result += j;
            return result;
        }

        // This solution is better than solution1 but still gets timeout result
        private static long solution2(int N)
        {
            long result = 0;
            long three = 3;
            long five = 5;
            for (long j = three; j < N; j += three)
            {
                result += j;
            }
            for (long j = five; j < N; j += five)
            {
                if (j % 3 != 0)
                    result += j;
            }
            return result;
        }

        // This is a O(1) solution
        private static long solution3(int N)
        {
            long sumDivisibleBy3 = GetSumOfNumbersDivisibleByN(N-1, 3);
            long sumDivisibleBy5 = GetSumOfNumbersDivisibleByN(N-1, 5);
            long sumDivisibleBy15 = GetSumOfNumbersDivisibleByN(N-1, 15);

            return sumDivisibleBy3 + sumDivisibleBy5 - sumDivisibleBy15;
        }

        /// <summary>
        /// This solution use some simple maths, lets supose you have a sequence of all the numbers divisibles by N lower than max => {n1, n2, n3, ... np-2, np-1, np}
        /// Then (n1 + np) = (n2 + np-1) = (n3 + np-2) ...
        /// So you can simplify the problem in finding np and finding how many pairs you get, note that if the number of element in the sequence is odd you have to add the element in the middle of the sequence
        /// </summary>
        /// <param name="max"></param>
        /// <param name="N"></param>
        /// <returns>The addition of all the number divisibles by N lower than max</returns>
        private static long GetSumOfNumbersDivisibleByN(long max, long N)
        {
            long floorElementsCount = max / N;
            long bigestNumberDivisibleByN = floorElementsCount * N;
            long pairGroups = floorElementsCount / 2;
            long pairSize = N + bigestNumberDivisibleByN;

            if (floorElementsCount % 2 == 0)
                return pairGroups * pairSize;
            else
            {
                long numberInTheMiddle = N * (floorElementsCount / 2 + 1);
                return pairGroups * pairSize + numberInTheMiddle;
            }
        }
    }
}
