using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackerrank_Solutions
{
    public class P001
    {
        public static void Test()
        {
            int M = 5;
            int N = 4;
            int R = 14;

            int[][] matrix = new int[M][];
            matrix[0] = new int[] { 1, 2, 3, 4 };
            matrix[1] = new int[] { 7, 8, 9, 10 };
            matrix[2] = new int[] { 13, 14, 15, 16 };
            matrix[3] = new int[] { 19, 20, 21, 22 };
            matrix[4] = new int[] { 25, 26, 27, 28 };

            int min = Math.Min(N, M);

            for (int i = 0; i < min / 2; i++)
            {
                int n = N - 2 * i;
                int m = M - 2 * i;
                int r = R % (2 * m + 2 * n - 4);
                for (; r > 0; r--)
                    rotate(matrix, i, i, M, N);
            }

            Common.print(matrix);
        }

        /// <summary>
        /// Perform the rotation of the row numberM and the column numberN of the matrix in anti-clockwise direction.
        /// </summary>
        /// <param name="matrix">Matrix to be rotated</param>
        /// <param name="numberM">The number of the row to be rotated</param>
        /// <param name="numberN">The number of the column to be rotated</param>
        /// <param name="M">Rows of the matrix</param>
        /// <param name="N">Columns of the matrix</param>
        private static void rotate(int[][] matrix, int numberM, int numberN, int M, int N)
        {
            int m00 = matrix[numberM][numberN];

            // Up
            for (int i = numberN; i < N - numberN - 1; i++)
                matrix[numberM][i] = matrix[numberM][i + 1];

            // Right
            for (int i = numberM; i < M - numberM - 1; i++)
                matrix[i][N - numberN - 1] = matrix[i + 1][N - numberN - 1];

            // Down
            for (int i = N - numberN - 1; i > numberN; i--)
                matrix[M - numberM - 1][i] = matrix[M - numberM - 1][i - 1];

            // Left
            for (int i = M - numberM - 1; i > numberM; i--)
                matrix[i][numberN] = matrix[i - 1][numberN];

            matrix[numberM + 1][numberN] = m00;
        }
    }
}
