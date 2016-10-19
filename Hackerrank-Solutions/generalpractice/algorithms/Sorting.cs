using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackerrank_Solutions.generalpractice.algorithms
{
    public class Sorting
    {
        public void Test()
        {
            int[] array = new int[] { 24, 8, 2, 7, 6, 9, 19, 3, 1, 17, 22, 18, 29, 8 };

            foreach (int i in array)
                Console.Write("{0}, ", i);
            Console.WriteLine();

            mergeSort(array);

            foreach (int i in array)
                Console.Write("{0}, ", i);
            Console.WriteLine();

        }

        // Top Down Merge Sort Algorithm O(n log n).
        public void mergeSort(int[] a)
        {
            mergeSortSplit(a, 0, a.Length, new int[a.Length]);
        }

        private void mergeSortSplit(int[] a, int start, int end, int[] b)
        {
            if (end - start > 1)
            {
                int middle = (end + start) / 2;
                mergeSortSplit(a, start, middle, b);
                mergeSortSplit(a, middle, end, b);
                mergeSortMerge(a, start, middle, end, b);
            }
        }

        private void mergeSortMerge(int[] a, int start, int middle, int end, int[] b)
        {
            int i = start; // iterates over the left part of the array
            int j = middle; // iterates over the right part of the array

            for (int k = start; k < end; k++)
            {
                if ((i < middle) && (j < end))
                {
                    if (a[i] < a[j])
                    {
                        b[k] = a[i];
                        i++;
                    }
                    else
                    {
                        b[k] = a[j];
                        j++;
                    }
                }
                else if (i < middle)
                {
                    b[k] = a[i];
                    i++;
                }
                else if (j < end)
                {
                    b[k] = a[j];
                    j++;
                }
            }
            copyArray(a, start, end, b);
        }

        public void copyArray(int[] a, int start, int end, int[] b)
        {
            for (int k = start; k < end; k++)
                a[k] = b[k];
        }
    }
}
