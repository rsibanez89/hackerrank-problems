using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackerrank_Solutions.solutions
{
    public class BalancedBrackets
    {
        private static string[] inputs = new string[] { "4", "{[()]}", "{[(])}", "{{[[(())]]}}", "{{()()[]}}" };
        private static string[] output = new string[] { "YES NO YES YES" };

        private char getClossingBracket(char a)
        {
            if (a == ')')
                return '(';
            if (a == ']')
                return '[';
            return '{';
        }

        public void Test()
        {
            int nLine = 0;
            List<char> queque = new List<char>();
            int n = int.Parse(inputs[nLine++]);
            for (; n > 0; n--)
            {
                string sequence = inputs[nLine++];
                if (sequence.Length % 2 != 0)
                    Console.WriteLine("NO");
                else
                {
                    bool noProblem = true;
                    for (int i = 0; i < sequence.Length && noProblem; i++)
                        if (sequence[i].Equals('(') || sequence[i].Equals('[') || sequence[i].Equals('{'))
                            queque.Add(sequence[i]);
                        else if (queque.Count > 0)
                        {
                            char clossingBracket = getClossingBracket(sequence[i]);
                            if (queque[queque.Count - 1].Equals(clossingBracket))
                                queque.RemoveAt(queque.Count - 1);
                            else
                                noProblem = false;
                        }
                        else // Im trayin to remove from an empty queque
                            noProblem = false;

                    if (queque.Count == 0 && noProblem)
                        Console.WriteLine("YES");
                    else
                        Console.WriteLine("NO");
                    queque.Clear();
                }
            }
        }

        public bool oposite(char a, char b)
        {
            if (a == '(' && b == ')')
                return true;
            if (a == '[' && b == ']')
                return true;
            if (a == '{' && b == '}')
                return true;
            return false;
        }


        // It doesnt consider the case {{()()[]}}
        public void Solution1()
        {
            int nLine = 0;
            int n = int.Parse(inputs[nLine++]);
            for (; n > 0; n--)
            {
                string sequence = inputs[nLine++];
                bool noProblem = true;
                if (sequence.Length % 2 != 0)
                    Console.WriteLine("NO");
                else
                {
                    for (int i = 0; i < sequence.Length / 2 && noProblem; i++)
                        if (!oposite(sequence[i], sequence[sequence.Length - 1 - i]))
                            noProblem = false;

                    if (noProblem)
                        Console.WriteLine("YES");
                    else
                        Console.WriteLine("NO");
                }
            }
        }
    }
}
