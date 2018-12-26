using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter5
{
    public class Program
    {
        static void Main(string[] args)
        {
            DelegateSamples c5s = new DelegateSamples();
            c5s.NamedMethod();
            c5s.InvokeDelegate();
            c5s.InvokeDelegatebyAnonymousFunction();
            c5s.LambdaOperatorExample();
            c5s.CoVarianceSample();
            c5s.ContraVarianceSample();
            c5s.MulticastDelegate();


            EventSamples e5s = new EventSamples();
            e5s.Run();
            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
}
