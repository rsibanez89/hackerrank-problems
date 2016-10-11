using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackerrank_Solutions.generalpractice
{
    public class UsingInputOuput
    {
        public void Run()
        {
            simpleReadingWriting();
            loopReading();
        }

        private void simpleReadingWriting()
        {
            // Printing a text in standard output
            Console.WriteLine("This is a simple text");

            // Reading a string
            Console.WriteLine("Insert a string");
            String myString = Console.ReadLine();

            // Reading an integer
            Console.WriteLine("Insert an integer");
            int myInt = Convert.ToInt32(Console.ReadLine());

            // Reading a float
            Console.WriteLine("Insert a float");
            float myFloat = Convert.ToSingle(Console.ReadLine());

            // Printing in standard output
            Console.WriteLine("myString is: " + myString);
            Console.WriteLine("myInt is: " + myInt);
            Console.WriteLine("myFloat is: " + myFloat);
        }

        private void loopReading()
        {
            string myText = "";
            string myString = "";

            Console.WriteLine("Insert a text, to finish inset -1 or CTRL-C");
            while (((myString = Console.ReadLine()) != null) && (myString != "-1"))
            {
                if (myText == "")
                    myText = myString;
                else
                    myText = myText + " ** " + myString;
            }

            // You will never see the followin line if you execute from visual studio, but its printed.
            Console.WriteLine(myText);
        }
    }
}
