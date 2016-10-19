using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackerrank_Solutions.solutions
{
    public class P004
    {
        public static void Test()
        {
            string[] input = new string[] { "1", 
                                            "4 2",
                                            "1 2",
                                            "1 3",
                                            "1"};

            int nLine = 0;
            int testcases = int.Parse(input[nLine++]);
            string[] line;
            for (; testcases > 0; testcases--)
            {
                line = input[nLine++].Split();
                int N = int.Parse(line[0]);
                int M = int.Parse(line[1]);

                int[][] graph = Common.getIntMatrix(N);

                for (; M > 0; M--)
                {
                    line = input[nLine++].Split();
                    int x = int.Parse(line[0]) - 1; // The index starts in 0
                    int y = int.Parse(line[1]) - 1; // The index starts in 0
                    graph[x][y] = graph[y][x] = 6; // 6 is the distance between any two nodes
                }

                int S = int.Parse(input[nLine++]) - 1; // The index starts in 0
                int[] restult = BFS(graph, S);

                for (int i = 0; i < restult.Length; i++)
                    if(i != S)
                        Console.Write(restult[i] + " ");
                Console.WriteLine(); // This line is unnecessary, but the exercise its not accepted without this line in the HackerRank submission system
            }
        }

        public static int[] BFS(int[][] graph, int S)
        {
            bool[] visited = new bool[graph[0].Length];
            int[] distance = new int[graph[0].Length];
            int[] parent = new int[graph[0].Length];
            for (int i = 0; i < graph[0].Length; i++)
            {
                visited[i] = false;
                distance[i] = -1;
                parent[i] = 0;
            }

            List<int> toVisit = new List<int>(); 
            toVisit.Add(S);
            visited[S] = true;
            distance[S] = 0;

            while (toVisit.Count != 0)
            {
                int nodeBegin = toVisit[0];
                toVisit.RemoveAt(0);
                for(int nodeEnd = 0; nodeEnd < graph[0].Length; nodeEnd++)
                {
                    if( (graph[nodeBegin][nodeEnd] != 0) && (!visited[nodeEnd]) )
                    {
                        distance[nodeEnd] = distance[nodeBegin] + 6;
                        parent[nodeEnd] = nodeBegin;
                        toVisit.Add(nodeEnd);
                        visited[nodeEnd] = true;
                    }
                }
            }
            return distance;
        }

    }
}
