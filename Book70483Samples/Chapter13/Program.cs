using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter13
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Press any key to start execution.");
            System.Console.ReadKey();
            new DebugHelperClass().Method1();
            new DebugHelperClass().Method2();
            new DebugHelperClass().Method4();
            new DebugHelperClass().Method5();
            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
}
