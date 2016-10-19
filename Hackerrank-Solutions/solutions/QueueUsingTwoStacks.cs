using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackerrank_Solutions.solutions
{
    public class QueueUsingTwoStacks
    {
        private static string[] inputs = new string[] { "10", "1 42", "2", "1 14", "3", "1 28", "3", "1 60", "1 78", "2", "2" };
        private static string[] output = new string[] { "14", "14" };

        public void Test()
        {
            int nLine = 0;
            int queries = int.Parse(inputs[nLine++]);
            List<string> queque = new List<string>();
            for (; queries > 0; queries--)
            {
                string[] query = inputs[nLine++].Split();
                if (query[0] == "1")
                {
                    queque.Add(query[1]);
                }
                else if (query[0] == "2")
                {
                    queque.RemoveAt(0);
                }
                else if (query[0] == "3")
                {
                    Console.WriteLine(queque[0]);
                }
            }
        }
    }
}
