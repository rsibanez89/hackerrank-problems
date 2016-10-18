using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackerrank_Solutions
{
    public class HashtableRansomNote
    {
        private static string[] inputs = new string[] { "6 4", "give me one grand today night", "give one grand today" };
        private static string[] output = new string[] { "Yes" };

        public void Test()
        {
            int nLine = 0;
            string[] line = inputs[nLine++].Split();
            int m = int.Parse(line[0]);
            int n = int.Parse(line[1]);
            List<string> magazine = inputs[nLine++].Split().ToList();
            List<string> note = inputs[nLine++].Split().ToList();
            magazine.Sort();

            bool canCreate = true;

            for (int i = 0; i < n && canCreate; i++)
            {
                int index = magazine.BinarySearch(note[i]);
                if (index >= 0)
                    magazine.RemoveAt(index);
                else
                    canCreate = false;
            }

            if (canCreate)
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");
        }

        // Terminated due to timeout
        public void Solution1()
        {
            int nLine = 0;
            string[] line = inputs[nLine++].Split();
            int m = int.Parse(line[0]);
            int n = int.Parse(line[1]);
            List<string> magazine = inputs[nLine++].Split().ToList();
            List<string> note = inputs[nLine++].Split().ToList();
            bool canCreate = true;
            for (int i = 0; i < n && canCreate; i++)
                if (!magazine.Remove(note[i]))
                    canCreate = false;

            if (canCreate)
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");
        }
    }
}
