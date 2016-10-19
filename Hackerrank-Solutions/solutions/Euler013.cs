using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Hackerrank_Solutions.solutions
{
    public class Euler013
    {
        public static void Test()
        {
            string[] input = new string[] { "5", 
                                            "37107287533902102798797998220837590246510135740250",
                                            "46376937677490009712648124896970078050417018260538",
                                            "74324986199524741059474233309513058123726617309629",
                                            "91942213363574161572522430563301811072406154908250",
                                            "23067588207539346171171980310421047513778063246676"};

            int nLine = 0;
            int N = int.Parse(input[nLine++]);
            BigInteger b = new BigInteger();
            for (int i = 0; i < N; i++)
                b += BigInteger.Parse(input[nLine++]);
            String result = b.ToString();
            for (int i = 0; i < 10; i++)
                Console.Write(result[i]);
            Console.WriteLine(); 
        }
    }
}
