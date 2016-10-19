using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackerrank_Solutions.solutions
{
    public class MaximumDifference
    {

        private static string[] inputs = new string[] { "6", "2 3 10 6 4 8 1", "1 2 90 10 100", "5 3 8 1 2 9", "9 7 0 1 5 8", "9", "5 3 2 1" };

        public int getMaxDiff(int[] a)
        {
            if (a.Length < 2)
                return -1;

            int minValue = a[0];
            int maxDiff = int.MinValue;
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] - minValue > maxDiff)
                    maxDiff = a[i] - minValue;
                if (a[i] < minValue) // once I find a new min value, I have to find a bigger difference to the right. 
                    minValue = a[i]; // if I don't find a bigger difference in the following iterations I don't update the maxDiff.
            }

            if (maxDiff > 0)
                return maxDiff;
            return -1; // Descending order
        }

        public void Test()
        {
            int nLine = 0;
            int n = int.Parse(inputs[nLine++]);
            for (; n > 0; n--)
            {
                string[] line = inputs[nLine++].Split();
                int[] seqence = Array.ConvertAll(line, int.Parse);

                Console.WriteLine(getMaxDiff(seqence));
            }
        }

        // Terminated due to timeout
        public int Solution1(int[] a)
        {
            if (a.Length < 2)
                return -1;

            int maxDiff = int.MinValue;
            for (int i = 1; i < a.Length; i++)
                for (int j = 0; j < i; j++)
                    if (a[i] - a[j] > maxDiff)
                        maxDiff = a[i] - a[j];
            if (maxDiff > 0)
                return maxDiff;
            return -1; // Descending order
        }
    }
}
