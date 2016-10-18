using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackerrank_Solutions
{
    public class BiggerIsGreater
    {
        private static string[] inputs = new string[] { "6", "ab", "bb", "hefg", "dhck", "dkhc", "zzzayybbaa" };
        private static string[] output = new string[] { "ba", "no answer", "hegf", "dhkc", "hcdk", "zzzbaaabyy" };

        public int descendigBinarySeach(char[] word, char toInsert, int start, int end)
        {
            while (start <= end)
            {
                int middle = (start + end) / 2;
                if (word[middle] > toInsert)
                    start = middle + 1;
                else if (word[middle] < toInsert)
                    end = middle - 1;
                else
                    return middle; // found
            }
            return -(start + 1);  // not found
        }

        public bool nextLexicographicalPermutationBinarySeach(char[] word)
        {
            int index = word.Length - 1;
            bool found = false;
            char swap;

            // 1. find the pivot to swap
            while (index > 0 && !found)
            {
                if (word[index - 1] < word[index]) // I have a swap 
                    found = true;
                else
                    index--;
            }

            if (!found) // there is no permutation
                return false;

            int indexToSwap = descendigBinarySeach(word, word[index - 1], index, word.Length-1);
            if (indexToSwap < 0)
                indexToSwap = ~indexToSwap - 1; // inverse order
            else
                if (indexToSwap > 0)
                    indexToSwap--;


            // 2. swap
            swap = word[indexToSwap];
            word[indexToSwap] = word[index - 1];
            word[index - 1] = swap;

            // 4. reverse the sufix
            int j = word.Length - 1;
            while (index < j)
            {
                swap = word[index];
                word[index] = word[j];
                word[j] = swap;
                index++;
                j--;
            }

            return true;
        }

        static public bool nextPermutation(char[] word)
        {

            int n = word.Length;
            int k = -1;

            for (int i = 1; i < n; i++)
                if (word[i - 1] < word[i])
                    k = i - 1;

            if (k == -1)
                return false;

            int l = k + 1;
            for (int i = l; i < n; i++)
                if (word[k] < word[i])
                    l = i;

            char t = word[k];
            word[k] = word[l];
            word[l] = t;

            Array.Reverse(word, k + 1, word.Length - (k + 1));

            return true;
        }

        public void Test()
        {
            int nLine = 0;
            int n = int.Parse(inputs[nLine++]);
            for (; n > 0; n--)
            {
                char[] word = inputs[nLine++].ToArray();

                if (word.Length > 1 && nextLexicographicalPermutationBinarySeach(word))
                    for (int i = 0; i < word.Length; i++)
                        Console.Write(word[i]);
                else
                    Console.Write("no answer");
                Console.WriteLine();
            }
        }

        // This algorithm follows that logic
        // https://www.nayuki.io/page/next-lexicographical-permutation-algorithm
        public bool nextLexicographicalPermutation(char[] word)
        {
            int index = word.Length - 1;
            bool found = false;
            // 1. find the character to swap
            while (index > 0 && !found)
            {
                if (word[index - 1] < word[index]) // I have a swap 
                    found = true;
                else
                    index--;
            }

            if (!found) // there is no permutation
                return false;

            // 2. find the smallest character bigger than index-1
            int indexSmallest = word.Length - 1;
            while (word[index - 1] >= word[indexSmallest])
                indexSmallest--;

            // 3. swap
            char swap = word[indexSmallest];
            word[indexSmallest] = word[index - 1];
            word[index - 1] = swap;

            // 4. reverse the sufix
            int j = word.Length - 1;
            while (index < j)
            {
                swap = word[index];
                word[index] = word[j];
                word[j] = swap;
                index++;
                j--;
            }
            return true;
        }

        public void Solution2()
        {
            int nLine = 0;
            int n = int.Parse(inputs[nLine++]);
            for (; n > 0; n--)
            {
                char[] word = inputs[nLine++].ToArray();

                if (word.Length > 1 && nextLexicographicalPermutation(word))
                    for (int i = 0; i < word.Length; i++)
                        Console.Write(word[i]);
                else
                    Console.Write("no answer");
                Console.WriteLine();
            }
        }

        private void back(string word, string newWord, bool[] usedCharacter, int length, SortedSet<string> dictionary)
        {
            if (newWord.Length == length)
                dictionary.Add(newWord);
            else
            {
                for (int i = 0; i < word.Length; i++)

                    if (!usedCharacter[i])
                    {
                        char letter = word[i];
                        string nextWord = newWord + letter;
                        string wordCrop = word.Substring(0, nextWord.Length - 1);
                        int compResult = wordCrop.CompareTo(nextWord);

                        // with this I avoid start generating a sequence smaller than the original
                        if ((compResult == 0) || (compResult == -1)) // = -1 means a < b
                        {
                            usedCharacter[i] = true;
                            back(word, nextWord, usedCharacter, length, dictionary);
                            usedCharacter[i] = false;
                        }
                    }
            }
        }

        //Terminated due to timeout
        public void Solution1()
        {
            int nLine = 0;
            int n = int.Parse(inputs[nLine++]);
            SortedSet<string> dictionary = new SortedSet<string>();
            for (; n > 0; n--)
            {
                string word = inputs[nLine++];
                bool[] usedCharacter = new bool[word.Length];
                for (int i = 0; i < usedCharacter.Length; i++)
                    usedCharacter[i] = false;

                back(word, "", usedCharacter, word.Length, dictionary);

                if (dictionary.Count > 1)
                    Console.WriteLine(dictionary.ElementAt(1));
                else
                    Console.WriteLine("no answer");
                dictionary.Clear();
            }
        }

    }
}
