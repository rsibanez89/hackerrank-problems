using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackerrank_Solutions.solutions
{
    public class MissingNumbers
    {
        private static string[] inputs = new string[] { "10", "203 204 205 206 207 208 203 204 205 206", "13", "203 204 204 205 206 207 205 208 203 206 205 206 204" };
        private static string[] output = new string[] { "204 205 206" };

        public void Test()
        {
            int nLine = 0;

            int n = int.Parse(inputs[nLine++]);
            string[] listA = inputs[nLine++].Split();

            int m = int.Parse(inputs[nLine++]);
            string[] listB = inputs[nLine++].Split();

            int max = 1000011;
            int[] allNumber = new int[max];

            for (int i = 0; i < listB.Length; i++)
            {
                int index = int.Parse(listB[i]);
                allNumber[index] += 1;
            }
                
            for (int i = 0; i < listA.Length; i++)
            {
                int index = int.Parse(listA[i]);
                allNumber[index] -= 1;
            }

            for (int i = 0; i < allNumber.Length; i++)
                if (allNumber[i] > 0)
                    Console.Write(i + " ");
        }

        // Terminated due to timeout
        public void Solution1()
        {
            int nLine = 0;
            int n = int.Parse(inputs[nLine++]);
            List<string> listA = new List<string>(inputs[nLine++].Split());
            
            int m = int.Parse(inputs[nLine++]);
            List<string> listB = new List<string>(inputs[nLine++].Split());

            for (int i = 0; i < listA.Count; i++)
                listB.Remove(listA[i]);

            listB.Sort();
            string lastPrinted = "";
            for (int i = 0; i < listB.Count; i++)
                if (listB[i] != lastPrinted)
                {
                    lastPrinted = listB[i];
                    Console.Write(listB[i] + " ");
                }
        }

        // Terminated due to timeout
        public void Solution2()
        {
            int nLine = 0;
            int n = int.Parse(inputs[nLine++]);
            string[] listA = inputs[nLine++].Split();
            Array.Sort(listA);
            int m = int.Parse(inputs[nLine++]);
            string[] listB = inputs[nLine++].Split();
            Array.Sort(listB);

            string lastPrinted = "";
            for (int i = 0, j = 0; i < listA.Length;)
            {
                int res = listA[i].CompareTo(listB[j]);
                if (res == 0) // equals
                {
                    i++;
                    j++;
                }
                else if (res == 1) // a < b
                {
                    if (listB[j] != lastPrinted)
                    {
                        lastPrinted = listB[j];
                        Console.Write(lastPrinted + " ");
                    }
                    j++;
                }
                else if (res == -1) // a > b
                {
                    Console.WriteLine("This should never happen. :D");
                    i++;
                }
            }
        }

    }

}

