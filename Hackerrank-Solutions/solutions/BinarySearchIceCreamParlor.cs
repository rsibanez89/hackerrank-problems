using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackerrank_Solutions.solutions
{
    public class BinarySearchIceCreamParlor
    {
        private static string[] inputs = new string[] { "2", "4", "5", "1 4 5 3 2", "4", "4", "2 2 4 3", Math.Pow(10, 7).ToString() };
        private static string[] output = new string[] { "1 4", "1 2" };

        public void Test()
        {
            int nLine = 0;
            int trips = int.Parse(inputs[nLine++]);
            string[] line;
            for (; trips > 0; trips--)
            {
                int money = int.Parse(inputs[nLine++]);
                int n = int.Parse(inputs[nLine++]);
                line = inputs[nLine++].Split();
                int[] flavors = Array.ConvertAll(line, int.Parse);
                bool found = false;
                for (int i = 0; i < n - 1 && !found; i++)
                    for (int j = i + 1; j < n && !found; j++)
                        if (flavors[i] + flavors[j] == money)
                            Console.WriteLine((i+1) + " " + (j+1));
            }
            Console.ReadKey();
        }

    }
}
