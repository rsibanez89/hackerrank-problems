using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackerrank_Solutions
{
    public class Euler005
    {
        public static void Test()
        {
            string[] input = new string[] { "3", 
                                            "3",
                                            "10",
                                            "40"};

            int nLine = 0;
            int T = int.Parse(input[nLine++]);
            for (int i = 0; i < T; i++)
            {
                int N = int.Parse(input[nLine++]);
                //Console.WriteLine(solution1(N));
                Console.WriteLine(solution2(N+1));
            }
        }

        // This solution works in hackerrank but it shouldnt. If you call this function with N = 40 it never ends.
        private static long solution1(int N)
        {
            long candidate = N;
            while (!candidateAcepted(candidate, N))
                candidate = candidate + N;
            return candidate;
        }

        private static bool candidateAcepted(long candidate, int N)
        {
            for (int i = N; i > 0; i--)
                if (candidate % i != 0)
                    return false;
            return true;
        }

        // This solution doesnt work in hackerrank but it should, this is a more efficient solution. If you call this function with N = 40 it works.
        private static long solution2(int N)
        {
            int[] prime = new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37 };
            List<int> primeList = prime.OfType<int>().ToList();
            int[][] primeFactorizationPerValue = new int[N][];
            //primeFactorizationPerValue[0] = new int[prime.Length]; // Factorization of 0 is not needed
            //primeFactorizationPerValue[1] = new int[prime.Length]; // Factorization of 1 is not needed
            for (int i = 2; i < N; i++)
                primeFactorizationPerValue[i] = getPrimeFactorization(i, primeList);

            long result = 1;
            for (int j = 0; j < prime.Length; j++)
            {
                long maxOfTheColumn = primeFactorizationPerValue[2][j];
                for (int i = 2; i < N; i++)
                    if (maxOfTheColumn < primeFactorizationPerValue[i][j])
                        maxOfTheColumn = primeFactorizationPerValue[i][j];
                result *= (long)Math.Pow(prime[j], maxOfTheColumn);
            }
            return result;
        }

        private static int[] getPrimeFactorization(int value, List<int> prime)
        {
            int[] result = new int[prime.Count];
            bool finished = false;
            int primIndex = 0;
            while (!finished)
            {
                if (prime.Contains(value))
                {
                    result[prime.IndexOf(value)]++;
                    finished = true;
                }
                else if (value % prime[primIndex] == 0)
                {
                    value = value / prime[primIndex];
                    result[primIndex]++;
                }
                else
                    primIndex++;
            }
            return result;
        }
    }
}
