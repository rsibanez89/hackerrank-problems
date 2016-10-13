using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackerrank_Solutions.generalpractice.algorithms
{
    public class BinarySearch
    {
        public void Test()
        {
            int[] array = new int[] { 1, 2, 3, 6, 8, 9, 10, 17, 18, 19, 20, 22, 24 };
            int[] elementsToAdd = new int[] { -5, 4, 5, 7, 11, 21, 25 };

            foreach (int i in array)
                Console.WriteLine("Seraching {0}: {1}", i, binarySearch(array, i));
            Console.WriteLine();

            foreach (int i in elementsToAdd)
            {
                int index = binarySearch(array, i);
                if (index < 0)
                {
                    index = ~index;
                    if (index == array.Length)
                        Console.WriteLine("{0} should be inserted after {1}", i, array[array.Length - 1]);
                    else if (index == 0)
                        Console.WriteLine("{0} should be inserted before {1}", i, array[0]);
                    else
                        Console.WriteLine("{0} should be inserted in between {1} and {2}", i, array[index - 1], array[index]);
                }
            }
            Console.WriteLine();

            foreach (int i in elementsToAdd)
                Console.Write(i + " ");
            Console.WriteLine();

            Console.WriteLine("Index of 21: " + Array.BinarySearch(elementsToAdd, 21));
            Console.WriteLine("Index of 20: " + Array.BinarySearch(elementsToAdd, 20));
            Console.WriteLine("Index of 30: " + Array.BinarySearch(elementsToAdd, 30));
            Console.WriteLine();

            List<int> list = array.ToList();
            list.ForEach(i => Console.Write(i + " "));
            Console.WriteLine();

            foreach (int i in elementsToAdd)
            {
                int index = list.BinarySearch(i);
                if (index < 0)
                {
                    index = ~index;

                    if (index == array.Length)
                        list.Insert(index - 1, i);
                    else
                        list.Insert(index, i);
                }
            }

            list.ForEach(i => Console.Write(i + " "));
            Console.WriteLine();
        }

        // The following code should be simmilar to the Array.BinarySearch() implementation.
        // https://msdn.microsoft.com/en-us/library/2cy9f6wb(v=vs.110).aspx
        // If array does not contain the specified value, the method returns a negative integer. 
        // You can apply the bitwise complement operator (~) to the negative result to produce an index. 
        // If this index is equal to the size of the array, there are no elements larger than value in the array. 
        // Otherwise, it is the index of the first element that is larger than value.
        public int binarySearch(int[] array, int lookingFor)
        {
            return binarySearch(array, lookingFor, 0, array.Length - 1);
        }

        private int binarySearch(int[] array, int lookingFor, int start, int end)
        {
            while (start <= end)
            {
                int middle = (start + end) / 2;
                if (array[middle] < lookingFor)
                    start = middle + 1;
                else if (array[middle] > lookingFor)
                    end = middle - 1;
                else
                    return middle; // found
            }
            return -(start + 1);  // not found
        }

        public int recursiveBinarySearch(int[] array, int lookingFor)
        {
            return recursiveBinarySearch(array, lookingFor, 0, array.Length - 1);
        }

        private int recursiveBinarySearch(int[] array, int lookingFor, int start, int end)
        {
            if (start > end)
                return -(start + 1);
            else
            {
                int middle = (start + end) / 2;
                if (lookingFor == array[middle])
                    return middle;
                if (lookingFor < array[middle])
                    return recursiveBinarySearch(array, lookingFor, start, middle - 1);
                //if (lookingFor > array[middle])
                return recursiveBinarySearch(array, lookingFor, middle + 1, end);
            }
        }
    }
}
