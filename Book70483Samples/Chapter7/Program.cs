using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter7
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Press any key to start execution.");
            System.Console.ReadKey();
            try
            {
                ExceptionSamples.ExceptionTest1();
            }
            catch (Exception ex)
            {
                //catching exception in main program as to avoid intrruption in execution
            }
            ExceptionSamples.ExceptionTest2();
            ExceptionSamples.ExceptionTest3();
            ExceptionSamples.ExceptionTest4();
            try
            {
                ExceptionSamples.ExceptionTest5();
            }
            catch (Exception ex)
            {
                //catching exception in main program as to avoid intrruption in execution 
            }

            ExceptionSamples.ExceptionTest6();

            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
}
