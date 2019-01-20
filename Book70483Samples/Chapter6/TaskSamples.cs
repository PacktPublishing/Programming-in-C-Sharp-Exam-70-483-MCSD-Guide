using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter6
{
    internal class TaskSamples
    {

        public static void Run()
        {
            Action<object> action = (object obj) =>
            {
                Console.WriteLine("Task={0}, Milliseconds to sleep={1}, Thread={2}",Task.CurrentId, obj,
                Thread.CurrentThread.ManagedThreadId);
                int value = Convert.ToInt32(obj);
                Thread.Sleep(value);
            };

            Task t1 = new Task(action, 1000);
            Task t2 = Task.Factory.StartNew(action, 5000);
            t2.Wait();
            t1.Start();
            Console.WriteLine("t1 has been started. (Main Thread={0})",
                              Thread.CurrentThread.ManagedThreadId);
            t1.Wait();

            int taskData = 4000;
            Task t3 = Task.Run(() => {
                Console.WriteLine("Task={0}, Milliseconds to sleep={1}, Thread={2}",
                                  Task.CurrentId, taskData,
                                   Thread.CurrentThread.ManagedThreadId);
            });
            t3.Wait();

            Task t4 = new Task(action, 3000);
            t4.RunSynchronously();
            t4.Wait();
        }

        public static void TaskReturnSample()
        {
            Task<int> t = Task.Run(() => { return 30 + 40; });
            Console.WriteLine($"Result of 30+40: {t.Result}");
        }

        public static void TaskContinueWithSample()
        {
            Task<int> t = Task.Run(() => 
                {
                    return 30 + 40;
                }
            ).ContinueWith((t1) => 
            {
                return t1.Result * 10;
            });
            Console.WriteLine($"Result of two tasks: {t.Result}");
        }

        static int[] _values = Enumerable.Range(0, 1000).ToArray();

        private static void SumAndProduct(int x)
        {
            int sum = 0;
            int product = 1;
            foreach (var element in _values)
            {
                sum += element;
                product *= element;
            }
        }

        public static void CallSumAndProduct()
        {
            const int max = 10;
            const int inner = 100000;
            var s1 = Stopwatch.StartNew();
            for (int i = 0; i < max; i++)
            {
                Parallel.For(0, inner, SumAndProduct);
            }
            s1.Stop();

            Console.WriteLine("Elapsed time in seconds for ParallelLoop: " + s1.Elapsed.Seconds);

            var s2 = Stopwatch.StartNew();
            for (int i = 0; i < max; i++)
            {
                for (int z = 0; z < inner; z++)
                {
                    SumAndProduct(z);
                }
            }
            s2.Stop();
            
            Console.WriteLine("Elapsed time in seconds for Sequential Loop: " + s2.Elapsed.Seconds );
        }



    }
}
