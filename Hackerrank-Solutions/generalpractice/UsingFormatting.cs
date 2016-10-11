using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackerrank_Solutions.generalpractice
{
    public class UsingFormatting
    {
        public void Test()
        {
            simpleFormatting();
            specifyingWidthAndAligning();
            formattingNumbers();
            simpleTable();
        }

        private void simpleFormatting()
        {
            // {} indicates that there is a special replacement
            // \n for new line

            // {0} for the first parameter, {1} for the second parameter
           Console.Write("I'm {0} years old, and {0} = {1}\n", 'n', 27);

            // {:X} for exadecimal
            // {:E} for scientific
            // {:N} for number
            Console.Write("This is the same number in different formats: {0:X} | {0:E} | {0:N} \n", 27);

            // for int, float, string, and bool you dont have to specify the format. 
            Console.Write("Am I {0} | {1} | {2} years old? {3} \n", 27, 27.0f, "27", true);

            // {:D} for dates
            // {:d} for dates in the format MM/DD/YYY
            // {:O} for dates in the format yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffffffzz
            Console.Write("Today is {0:D} | {0:d} | {0:O} \n", DateTime.Now);
            Console.Write("Today is {0:dd-MM-yyyy} \n", DateTime.Now);

            // {:t} for time
            Console.Write("The time is {0:t} \n", DateTime.Now);
            Console.WriteLine("The time is {0:hh-mm-ss tt} | {0:HH:mm:ss} \n", DateTime.Now);

        }

        private void specifyingWidthAndAligning()
        {
            // {,10} specify a minimum width of 10 characters
            Console.WriteLine("***{0,10}***", "Hi");
            Console.WriteLine("***{0,10}***\n", 5);

            // {,-10} specify a minimum width of 10 characters aligning left
            Console.WriteLine("***{0,-10}***\n***{1,-10}***\n", "Hi", 5);

            // {0:00000} specify to fill the space with 0, its just for numbers
            Console.WriteLine("***{0:00000}***", 5);
            Console.WriteLine("***{0:00000000.000}***\n", 5.2345f);

            // {:C3} for currency with 3 decimals. This insert the symbol $
            Console.WriteLine("{0:C} | {0:C3} \n", 5673123.251d);

            // {:0,000.00} for currency without inserting the symbol $. 
            Console.WriteLine("{0:0,000.00} \n", 5673123.251d);
        }

        private void formattingNumbers()
        {
            // {:0.00} for just two decimal places
            Console.WriteLine("{0,15:0.00}", 5);  
            Console.WriteLine("{0,15:0.00}", 5.2345f);     
            Console.WriteLine("{0,15:0.00}\n", 5673123.251d);

            // {:0.00} for maximum two decimal places
            Console.WriteLine("{0:0.##}", 5);
            Console.WriteLine("{0:0.##}", 5.2345f);
            Console.WriteLine("{0:0.##}\n", 5673123.251d);

            // {:0000000000} for at least ten digits before decimal point
            Console.WriteLine("{0:0000000000.0}", 5);    
            Console.WriteLine("{0:0000000000.0}", 5.2345f);     
            Console.WriteLine("{0:0000000000.0}\n", 5673123.251d);

            // {:0,0.0} for using thousands separator
            Console.WriteLine("{0:,0}", 5);
            Console.WriteLine("{0:,0}", 5.2345f);
            Console.WriteLine("{0:0,0.0}\n", 5673123.251d);

            // for adding custom formatting to negative numbers and zero
            Console.WriteLine("{0:0.00;minus 0.00;zero}", 5673123.251d);
            Console.WriteLine("{0:0.00;minus 0.00;zero}", -5673123.251d);
            Console.WriteLine("{0:0.00;minus 0.00;zero}\n", 0.0);
        }

        private void simpleTable()
        {
            string[] names = { "Rodrigo", "Federico", "Juana" };
            int[] ages = new int[] { 27, 25, 12 };

            Console.WriteLine("=====================");
            Console.WriteLine(" {0,-15} {1,3}\n", "Name", "Age");
            for (int i = 0; i < names.Length; i++)
            {
                string name = names[i];
                int age = ages[i];
                Console.WriteLine(" {0,-15} {1:000}", name, age);
            }
            Console.WriteLine("=====================");
        }
    }
}
