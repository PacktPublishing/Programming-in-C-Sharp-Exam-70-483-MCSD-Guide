using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_9
{
    class Program
    {
        static void Main(string[] args)
        {
            object a = ReturnResult();
            ReturnResultFinal(a);
            SampleFinalizerClass b = new SampleFinalizerClass();
            SampleNoFinalizeClass c = new SampleNoFinalizeClass();
            SampleNoFinalizeClass d = new SampleNoFinalizeClass();
            GarbageCollectorFinalize(c);
            Finalizer f = new Finalizer();
            f = null;
            GC.Collect();
            Console.ReadLine();

            using (DisposeImplementation d1 = new DisposeImplementation())
            {
                //throw new Exception("in here");
            }
            DisposeImplementation d2 = new DisposeImplementation();
            Console.ReadLine();
            GC.Collect();
            Console.ReadLine();
            GC.WaitForPendingFinalizers();
        }

        static private object ReturnResult()
        {
            object a = new object();
            object b = new object();
            object c = new object();
            object d = new object();
            object e = new object();
            return a;
        }

        static private void ReturnResultFinal(object a)
        {
            
        }

        static private void GarbageCollectorFinalize(SampleNoFinalizeClass a)
        {

        }
    }

    public class SampleFinalizerClass
    {
        ~SampleFinalizerClass()
        {

        }
    }

    public class SampleNoFinalizeClass
    {
        
    }

    public class Finalizer
    {
        public Finalizer()
        {
            Console.WriteLine("Creating object of Finalizer");
        }
        ~Finalizer()
        {
            Console.WriteLine("Inside the finalizer of class Finalizer");
        }
    }

    public class DisposeImplementation : IDisposable
    {
        private bool isDisposed = false;
        public DisposeImplementation()
        {
            Console.WriteLine("Creating object of DisposeImplementation");
        }
        ~DisposeImplementation()
        {
            if(!isDisposed)
            {
                Console.WriteLine("Inside the finalizer of class DisposeImplementation");
                this.Dispose();
                /// Reclaim memory of unmamaged resources
            }
        }
        public void Dispose()
        {
            isDisposed = true;
            GC.SuppressFinalize(this);
            Console.WriteLine("Inside the dispose of class DisposeImplementation");
            /// Reclaim memory of unmamaged resources
        }
    }
}
