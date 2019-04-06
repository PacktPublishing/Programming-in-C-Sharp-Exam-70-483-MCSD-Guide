using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter6
{
    internal class ThreadingSamples
    {
        public static void ThreadSample()
        {
            Console.WriteLine("Primary thread: Starting a new worker thread.");
            Thread t = new Thread(new ThreadStart(ThreadOne));
            t.Start();
            Thread.Sleep(5);
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Primary thread: Do something().");
                Thread.Sleep(5);

            }
            Console.WriteLine("Primary thread: Call Join(), to wait until ThreadOne ends.");
            t.Join();
            Console.WriteLine("Primary thread: ThreadOne.Join has returned.");
        }

        public static void ThreadProperties()
        {
            var th = new Thread(ThreadTwo);
            th.Start();
            Thread.Sleep(1000);
            Console.WriteLine("Primary thread ({0}) exiting...", Thread.CurrentThread.ManagedThreadId);

        }

        public static void ParameterizedThread()
        {
            var th = new Thread(ThreadThree);
            th.Start(3000);
            Thread.Sleep(1000);
            Console.WriteLine("Primary thread ({0}) exiting...", Thread.CurrentThread.ManagedThreadId);

        }

        public static void BackgroundThread()
        {
            Console.WriteLine("Thread Id: {0}" + Environment.NewLine + "Thread State: {1}" + Environment.NewLine + "Priority {2}" + Environment.NewLine + "IsBackground: {3}",
                              Thread.CurrentThread.ManagedThreadId,
                              Thread.CurrentThread.ThreadState,
                              Thread.CurrentThread.Priority,
                              Thread.CurrentThread.IsBackground);
            var th = new Thread(ExecuteBackgroundThread);
            th.IsBackground = true;
            th.Start();
            Thread.Sleep(500);
            Console.WriteLine("Main thread ({0}) exiting...",
                              Thread.CurrentThread.ManagedThreadId);

        }

        public static void PoolOfThreads()
        {
            Console.WriteLine("Primary Thread Id: {0}" + Environment.NewLine + "Thread State: {1}" + Environment.NewLine + "Priority {2}",
                              Thread.CurrentThread.ManagedThreadId,
                              Thread.CurrentThread.ThreadState,
                              Thread.CurrentThread.Priority);
            PoolProcessmethod();
            //Thread.CurrentThread.Join();
        }

        public static void TestLockStatements()
        {
            var account = new Account(1000);
            var tasks = new Task[2];
            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = Task.Run(() => UpdateAccount(account));
            }
            Task.WaitAll(tasks);
        }

        [ThreadStatic]
        public static int _intvariable;
        public static void ThreadStaticSample()
        {
            //Start three threads
            new Thread(() =>
            {
                for (int i = 0; i <= 5; i++)
                {
                    _intvariable++;
                    Console.WriteLine($"Thread Id:{Thread.CurrentThread.ManagedThreadId}, Int field Value:{_intvariable}");
                }
            }).Start();

            new Thread(() =>
            {
                for (int i = 0; i <= 5; i++)
                {
                    _intvariable++;
                    Console.WriteLine($"Thread Id:{Thread.CurrentThread.ManagedThreadId}, Int field Value:{_intvariable}");
                }
            }).Start();

            new Thread(() =>
            {
                for (int i = 0; i <= 5; i++)
                {
                    _intvariable++;
                    Console.WriteLine($"Thread Id:{Thread.CurrentThread.ManagedThreadId}, Int field Value:{_intvariable}");
                }
            }).Start();
          
        }

        public static ThreadLocal<string> _threadstring = new ThreadLocal<string>(() => {
            return "Thread " + Thread.CurrentThread.ManagedThreadId; });
        public static void ThreadLocalSample()
        {
            
            //Start three threads
            new Thread(() =>
            {
                for (int i = 0; i <= 5; i++)
                {
                    Console.WriteLine($"First Thread string :{_threadstring}");
                }
            }).Start();

            new Thread(() =>
            {
                for (int i = 0; i <= 5; i++)
                {
                    Console.WriteLine($"Second Thread string :{_threadstring}");
                }
            }).Start();

            new Thread(() =>
            {
                for (int i = 0; i <= 5; i++)
                {
                    Console.WriteLine($"Third Thread string :{_threadstring}");
                }
            }).Start();

        }


        private static void UpdateAccount(Account account)
        {
            var rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                var amount = rnd.Next(1, 1000);
                bool doCredit = rnd.NextDouble() < 0.5;
                if (doCredit)
                {
                    account.Credit(amount);
                }
                else
                {
                    account.Debit(amount);
                }
            }
        }

        private static void ThreadOne()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadOne running: {0}", i);
                Thread.Sleep(5);
            }
        }

        private static void ThreadTwo()
        {
            var sw = Stopwatch.StartNew();
            Console.WriteLine("ThreadTwo Id: {0} Threadtwo state: {1}, Threadtwo Priority: {2}",
                              Thread.CurrentThread.ManagedThreadId,
                              Thread.CurrentThread.ThreadState,
                              Thread.CurrentThread.Priority);
            do
            {
                Console.WriteLine("Threadtwo Id: {0}, Threadtwo elapsed time {1:N2} seconds",
                                  Thread.CurrentThread.ManagedThreadId,
                                  sw.ElapsedMilliseconds / 1000.0);
                Thread.Sleep(500);
            } while (sw.ElapsedMilliseconds <= 3000);
            sw.Stop();
        }

        private static void ThreadThree(object obj)
        {
            int interval = Convert.ToInt32(obj);
            var sw = Stopwatch.StartNew();
            Console.WriteLine("ThreadTwo Id: {0} ThreadThree state: {1}, ThreadThree Priority: {2}",
                              Thread.CurrentThread.ManagedThreadId,
                              Thread.CurrentThread.ThreadState,
                              Thread.CurrentThread.Priority);
            do
            {
                Console.WriteLine("ThreadThree Id: {0}, ThreadThree elapsed time {1:N2} seconds",
                                  Thread.CurrentThread.ManagedThreadId,
                                  sw.ElapsedMilliseconds / 1000.0);
                Thread.Sleep(500);
            } while (sw.ElapsedMilliseconds <= interval);
            sw.Stop();
        }

        private static void ExecuteBackgroundThread()
        {
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Thread Id: {0}" + Environment.NewLine + "Thread State: {1}" + Environment.NewLine + "Priority {2}" + Environment.NewLine + "IsBackground {3}",
                              Thread.CurrentThread.ManagedThreadId,
                              Thread.CurrentThread.ThreadState,
                              Thread.CurrentThread.Priority,
                              Thread.CurrentThread.IsBackground);
            do
            {
                Console.WriteLine("Thread {0}: Elapsed {1:N2} seconds",
                                  Thread.CurrentThread.ManagedThreadId,
                                  sw.ElapsedMilliseconds / 1000.0);
                Thread.Sleep(2000);
            } while (sw.ElapsedMilliseconds <= 5000);
            sw.Stop();
        }

        private static void PoolProcessmethod()
        {
            for (int i = 0; i < 5; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(PoolMethod));
            }
        }

        private static void PoolMethod(object callback)
        {
            Thread.Sleep(1000);
            Console.WriteLine("ThreadPool Thread Id: {0}" + Environment.NewLine + "Thread State: {1}" + Environment.NewLine + "Priority {2}" + Environment.NewLine + "IsBackground: {3}" + Environment.NewLine + "IsThreadPoolThread: {4}",
                              Thread.CurrentThread.ManagedThreadId,
                              Thread.CurrentThread.ThreadState,
                              Thread.CurrentThread.Priority,
                              Thread.CurrentThread.IsBackground,
                              Thread.CurrentThread.IsThreadPoolThread);

        }
            
    }
}
