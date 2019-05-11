using System;
using System.Diagnostics;
using System.IO;

namespace Chapter13
{
    internal class DebugHelperClass
    {
        internal void Method1()
        { 
            Console.WriteLine("Place debug point here");
        }

        internal void Method2()
        {
            Console.WriteLine("Enter a numeric value");
            int number1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter another numeric value");
            int number2 = Convert.ToInt32(Console.ReadLine());

            int number3 = number1 + number2;
            int number4 = number1 - number2;
            int number5 = Method3(number4);

        }

        internal int Method3(int number4)
        {
            return number4+10;
        }

        internal void Method4()
        {
            Console.WriteLine("Enter a numeric value");
            int number1 = Convert.ToInt32(Console.ReadLine());
            Debug.WriteLine($"Entered number 1 is: {number1}");

            Console.WriteLine("Enter another numeric value");
            int number2 = Convert.ToInt32(Console.ReadLine());
            Debug.WriteLine($"Entered number 2 is: {number2}");

            int number3 = number1 + number2;
            Debug.WriteLineIf(number3>10, $"Sum of number1 & number 2 is : {number3}");
            int number4 = number1 - number2;
            Debug.WriteLineIf(number4 < 10, $"Difference of number1 & number 2 is : {number4}");
        }

        internal void Method5()
        {
            TextWriterTraceListener listener1 = new TextWriterTraceListener(Console.Out);
            Debug.Listeners.Add(listener1);

            TextWriterTraceListener listener2 = new TextWriterTraceListener(File.CreateText("logfile.txt"));
            Debug.Listeners.Add(listener2);

            Console.WriteLine("Enter a numeric value");
            int number1 = Convert.ToInt32(Console.ReadLine());
            Debug.WriteLine($"Entered number 1 is: {number1}");

            Console.WriteLine("Enter another numeric value");
            int number2 = Convert.ToInt32(Console.ReadLine());
            Debug.WriteLine($"Entered number 2 is: {number2}");

            int number3 = number1 + number2;
            Debug.WriteLineIf(number3 > 10, $"Sum of number1 & number 2 is : {number3}");
            int number4 = number1 - number2;
            Debug.WriteLineIf(number4 < 10, $"Difference of number1 & number 2 is : {number4}");
            Debug.Flush();
        }
    }
}
