using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hackerrank_Solutions.solutions
{
    public class TriesContacts
    {
        private static string[] inputs = new string[] { "4",
                                                        "add hack",
                                                        "add hackerrank",
                                                        "find hac",
                                                        "find hak" };
        private static string[] output = new string[] { "2", "0"};

        public void Test()
        {
            int nLine = 0;
            int n = int.Parse(inputs[nLine++]);
            Dictionary<String, int> dictionary = new Dictionary<String, int>();
            for(;n>0;n--)
            {
                string[] operation = inputs[nLine++].Split();
                if (operation[0] == "add")
                {
                    string contact = operation[1];
                    string partial;
                    for (int i = 1; i<=contact.Length;i++)
                    {
                        partial = contact.Substring(0,i);
                        if (dictionary.ContainsKey(partial))
                            dictionary[partial]++;
                        else
                            dictionary[partial] = 1;
                    }               
                }   
                else
                {
                    int res = 0;
                    if (dictionary.ContainsKey(operation[1]))
                        res = dictionary[operation[1]];
                    Console.WriteLine(res);
                }
            }
            //Parallel.ForEach(dictionary, kValue => Console.WriteLine(kValue.Key + " -> " + kValue.Value));
        }

        // Terminated due to timeout
        public void Solution2()
        {
            int nLine = 0;
            int n = int.Parse(inputs[nLine++]);
            int sizeGuide = 'z' - 'a' + 1;
            List<string>[] contacts = new List<string>[sizeGuide];
            for (; n > 0; n--)
            {
                string[] operation = inputs[nLine++].Split();
                int index = operation[1][0] - 'a';
                if (operation[0] == "add")
                {
                    if (contacts[index] == null)
                        contacts[index] = new List<string>();
                    contacts[index].Add(operation[1]);
                }
                else
                {
                    int res = 0;
                    if (contacts[index] != null)
                    {
                        List<string> toSearch = contacts[index];
                        Regex regex = new Regex(@"\b" + operation[1]); // start with
                        foreach (string contact in toSearch)
                            if (regex.Match(contact).Success)
                                res++;
                    }

                    Console.WriteLine(res);
                }
            }
        }

        // Terminated due to timeout
        public void Solution1()
        {
            int nLine = 0;
            int n = int.Parse(inputs[nLine++]);
            List<string> contacts = new List<string>();
            for (; n > 0; n--)
            {
                string[] operation = inputs[nLine++].Split();
                if (operation[0] == "add")
                    contacts.Add(operation[1]);
                else
                {
                    int res = 0;
                    foreach (string contact in contacts)
                        if (contact.StartsWith(operation[1]))
                            res++;
                    Console.WriteLine(res);
                }
            }
        }
    }
}
