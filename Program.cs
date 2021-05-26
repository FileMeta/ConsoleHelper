/*
Unit test for ConsoleHelper class.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBit;

namespace UnitTest
{
    class Program
    {
        static void Main(string[] args)
        {

            // First set console to unicode.
            Console.WriteLine("Setting console to unicode mode...");
            Console.OutputEncoding = Encoding.UTF8;

            // Write some unicode text
            Console.WriteLine("The following includes unicode characters.");
            Console.WriteLine("Times: \u00D7");
            Console.WriteLine("Omega: \u03A9");
            Console.WriteLine("Pi: \u03C0");
            Console.WriteLine("Pound, Euro, Yen: \u00A3 \u20AC \u00A5");
            Console.WriteLine();

            // Test bring console to front
            Console.WriteLine("Sleeping for 5 seconds. Bring another window in front to test\r\nwhether application can bring itself to the front.");
            System.Threading.Thread.Sleep(5000);
            ConsoleHelper.BringConsoleToFront();
            Console.WriteLine("Console in front.");
            Console.WriteLine();

            // See if sole console owner
            if (ConsoleHelper.IsSoleConsoleOwner)
            {
                Console.WriteLine("Application is the sole console owner.\r\nIt should prompt before closing.");
            }
            else
            {
                Console.WriteLine("Application is not the sole console owner.\r\nIt will exit immediately.");
            }

            ConsoleHelper.PromptAndWaitIfSoleConsole();
        }
    }
}
