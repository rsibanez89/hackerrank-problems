using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackerrank_Solutions
{
    public static class Common
    {
        public static void print(int [][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                    Console.Write(matrix[i][j] + " ");
                Console.WriteLine();
            }
        }
    }
}
