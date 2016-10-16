using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackerrank_Solutions
{
    public class P002
    {
        public static void Test()
        {
            string[] input = new string[] { "2", 
                                            "4 3",
                                            "-1 -3 4 2",
                                            "4 2",
                                            "0 -1 2 1"};

            int nLine = 0;
            int testcases = int.Parse(input[nLine++]);
            string[] line;
            for (; testcases > 0; testcases--)
            {
                line = input[nLine++].Split();
                int N = int.Parse(line[0]); // I don't need this variable
                int K = int.Parse(line[1]);

                line = input[nLine++].Split();
                int[] arrivalTimes = Array.ConvertAll(line, int.Parse);

                int onTimeStudents = 0;
                foreach (int arrivalTime in arrivalTimes)
                    if (arrivalTime <= 0)
                        onTimeStudents++;
                if (onTimeStudents < K)
                    Console.WriteLine("YES");
                else
                    Console.WriteLine("NO");
            }
        }
    }
}
