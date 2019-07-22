using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter6
{
    internal class ParallelSamples
    {
        public static void PrintEvenNumbers()
        {
            var numbers = Enumerable.Range(1, 20);
            var pResult = numbers.AsParallel().Where(i => i % 2 == 0).ToArray();

            foreach (int e in pResult)
            {
                Console.WriteLine(e);
            }

        }

        public static void PrintEvenNumbersOrdered()
        {
            var numbers = Enumerable.Range(1, 20);
            var pResult = numbers.AsParallel().AsOrdered()
                .Where(i => i % 2 == 0).ToArray();

            foreach (int e in pResult)
            {
                Console.WriteLine(e);
            }

        }

        public static void PrintEvenNumbersExecutionMode()
        {
            var numbers = Enumerable.Range(1, 20);
            var pResult = numbers.AsParallel().WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                .Where(i => i % 2 == 0).ToArray();

            foreach (int e in pResult)
            {
                Console.WriteLine(e);
            }

        }

        public static void PrintEvenNumbersDegreeOfParallel()
        {
            var numbers = Enumerable.Range(1, 20);
            var pResult = numbers.AsParallel().WithDegreeOfParallelism(3)
                .Where(i => i % 2 == 0).ToArray();

            foreach (int e in pResult)
            {
                Console.WriteLine(e);
            }

        }

        public static void PrintEvenNumbersForAll()
        {
            var numbers = Enumerable.Range(1, 20);
            var pResult = numbers.AsParallel().Where(i => i % 2 == 0);

            pResult.ForAll(e => Console.WriteLine(e));
        }

        public static void PrintEvenNumbersExceptions()
        {
            var numbers = Enumerable.Range(1, 20);
            try
            {
                var pResult = numbers.AsParallel().Where(i => IsDivisibleBy2(i));

                pResult.ForAll(e => Console.WriteLine(e));
            }
            catch (AggregateException ex)
            {
                Console.WriteLine("There were {0} exeptions", ex.InnerExceptions.Count);
                foreach (Exception e in ex.InnerExceptions)
                {
                    Console.WriteLine("Exception Type: {0} and Exception Message: {1}", e.GetType().Name,e.Message);
                }
            }
        }

        private static bool IsDivisibleBy2(int num)
        {
            if (num % 3 == 0) throw new ArgumentException(string.Format("The number {0} is divisible by 3", num));
           return num % 2 == 0;
        }
    }
}
