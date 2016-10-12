using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackerrank_Solutions.generalpractice
{
    public class UsingCollections
    {
        public void Test()
        {
            workingWithList();
            workingWithSet();
            workingWithHashtable();
            workingWithDictionary();
        }

        private void workingWithList()
        {
            Console.WriteLine("--- Working with List ---");
            List<int> values = new List<int>();

            values.Add(1);
            values.Add(2);
            values.Add(3);
            values.Add(4);
            values.Add(5);
            values.Add(5);
            values.Add(3);
            values.Add(4);
            values.Add(2);
            values.Add(2);

            // Getting all the elements in the List
            foreach (int i in values)
                Console.Write(i + " ");
            Console.WriteLine();

            // Printing the List by using Linq
            Console.WriteLine("--- Printing the List by using Linq ---");
            values.ForEach(v => Console.Write(v + " "));
            Console.WriteLine();

            // Sorting all the elements in the List, as the list is int it doesn't need a comparator
            values.Sort();
            values.ForEach(v => Console.Write(v + " "));
            Console.WriteLine();

            // Sorting descending by usinf Linq
            values.Sort((a, b) => -1 * a.CompareTo(b));
            values.ForEach(v => Console.Write(v + " "));
            Console.WriteLine();

            // Getting the elementAt
            Console.WriteLine("values[0]: " + values.ElementAt(0));
            Console.WriteLine("values[5]: " + values[5]);

            // Removing an element
            values.Remove(3);
            Console.Write("Remove 3: ");
            values.ForEach(v => Console.Write(v + " "));
            Console.WriteLine();

            // Removing the elementAt
            values.RemoveAt(3);
            Console.Write("RemoveAt 3: ");
            values.ForEach(v => Console.Write(v + " "));
            Console.WriteLine();
        }

        private void workingWithSet()
        {
            // A Set is collection that contains no duplicate elements
            // A SortedSet is sorted according to the natural ordering of its elements, it has an access cost of O(log n)
            // A HashSet is not sorted, it has an access cost of O(1)
            Console.WriteLine("--- Working with Set ---");
            HashSet<int> values = new HashSet<int>();

            values.Add(1);
            values.Add(2);
            values.Add(3);
            values.Add(4);
            values.Add(5);
            values.Add(5);
            values.Add(3);
            values.Add(4);
            values.Add(2);
            values.Add(2);

            // Getting all the elements in the Set. A Set is no really for iterating over all the elements 
            foreach (int i in values)
                Console.Write(i + " ");
            Console.WriteLine();

            // Printing the Set by using Linq
            Console.WriteLine("--- Printing the Set by using Linq ---");
            Parallel.ForEach(values, i => Console.Write(i + " "));
            Console.WriteLine();

            // Getting the elementAt (a Set is not made for getting the elementAt)
            Console.WriteLine("values[3]: " + values.ToArray()[3]);

            // Removing an element
            values.Remove(3);
            Console.Write("Remove 3: ");
            Parallel.ForEach(values, i => Console.Write(i + " "));
            Console.WriteLine();

            // Removing the elementAt (a Set is not made for removing the elementAt)
            int elementAt = values.ToArray()[3];
            values.Remove(elementAt);
            Console.Write("RemoveAt 3: ");
            Parallel.ForEach(values, i => Console.Write(i + " "));
            Console.WriteLine();
        }

        private void workingWithHashtable()
        {
            // A Hashtable maps keys to values
            Console.WriteLine("--- Working with Hashtable ---");
            Hashtable values = new Hashtable();

            values.Add("One", 1);
            values.Add("Two", 2);
            values.Add("Three", 3);
            values.Add("Four", 5);
            values.Add("Five", 5);
            values["Six"] = 6;
            values["Seven"] = 7;

            // If the key is repeated it will throw an exception.
            try
            {
                values.Add("Four", 4);
            }
            catch
            {
                Console.WriteLine("An element with Key = \"Four\" already exists.");
            }
            Console.WriteLine();

            String aKey = "Specific Key";
            values.Add(aKey, new Random().Next(100));

            // Getting the Specific Key value
            Console.WriteLine("{0} -> {1}", aKey, values[aKey]);
            Console.WriteLine();

            // I need to cast to work with the values
            int value = (int)values[aKey];

            // Getting all values stored in the Hashtable by using the keys
            foreach (string key in values.Keys)
                Console.WriteLine("{0} -> {1}", key, values[key]);
            Console.WriteLine();

            // Getting all the elements in the Hashtable
            foreach (DictionaryEntry dE in values)
                Console.WriteLine("{0} -> {1}", dE.Key, dE.Value);
            Console.WriteLine();

            // Removing an element
            values.Remove(aKey);
            values.Remove("NotInHash"); // If the element to remove is not in the hash nothing happen. :D
            foreach (DictionaryEntry dE in values)
                Console.WriteLine("{0} -> {1}", dE.Key, dE.Value);
            Console.WriteLine();
        }

        private void workingWithDictionary()
        {
            // A Dictionary maps keys to values, similar to Hashtable but its Generic. It means that you don't need to cast when working with the values.
            Console.WriteLine("--- Working with Dictionary ---");
            Dictionary<String, int> values = new Dictionary<String, int>();

            values.Add("One", 1);
            values.Add("Two", 2);
            values.Add("Three", 3);
            values.Add("Four", 5);
            values.Add("Five", 5);
            values["Six"] = 6;
            values["Seven"] = 7;

            // If the key is repeated it will throw an exception.
            try
            {
                values.Add("Four", 4);
            }
            catch
            {
                Console.WriteLine("An element with Key = \"Four\" already exists.");
            }
            Console.WriteLine();

            String aKey = "Specific Key";
            values.Add(aKey, new Random().Next(100));

            // Getting the Specific Key value
            Console.WriteLine("{0} -> {1}", aKey, values[aKey]);
            Console.WriteLine();

            // I DON'T need to cast to work with the values
            int value = values[aKey];

            // Getting all values stored in the Dictionary by using the keys
            foreach (string key in values.Keys)
                Console.WriteLine("{0} -> {1}", key, values[key]);
            Console.WriteLine();

            // Getting all the elements in the Hashtable
            foreach (KeyValuePair<string, int> kValue in values)
                Console.WriteLine("{0} -> {1}", kValue.Key, kValue.Value);
            Console.WriteLine();

            // Removing an element
            values.Remove(aKey);
            values.Remove("NotInHash"); // If the element to remove is not in the hash nothing happen. :D

            // Printing the Dictionary by using Linq
            Parallel.ForEach(values, kValue => Console.WriteLine(kValue.Key + " -> " + kValue.Value));
        }
    }
}
