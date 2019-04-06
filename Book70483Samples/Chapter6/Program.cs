using System;
using System.Text;
using System.Threading;

namespace Chapter6
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadingSamples.ThreadSample();
            ThreadingSamples.ThreadProperties();
            ThreadingSamples.ParameterizedThread();
            ThreadingSamples.BackgroundThread();
            ThreadingSamples.PoolOfThreads();
            ThreadingSamples.TestLockStatements();
            ThreadingSamples.ThreadStaticSample();
            ThreadingSamples.ThreadLocalSample();
            TaskSamples.Run();
            TaskSamples.TaskReturnSample();
            TaskSamples.TaskContinueWithSample();
            TaskSamples.CallSumAndProduct();
            ParallelSamples.PrintEvenNumbers();
            ParallelSamples.PrintEvenNumbersOrdered();
            ParallelSamples.PrintEvenNumbersExecutionMode();
            ParallelSamples.PrintEvenNumbersDegreeOfParallel();
            ParallelSamples.PrintEvenNumbersForAll();
            ParallelSamples.PrintEvenNumbersExceptions();
            new AsynchronouseProgramming().TestAsyncMethods();
            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }

       
    }
}
