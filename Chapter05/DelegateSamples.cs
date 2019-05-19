using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter5
{
    // Declare a delegate
    delegate void MathDelegate(int i, double j);
    delegate void SampleDelegate();
    delegate void StringDelegate( string strVariable);
    public class First { }
    public class Second : First { }
    public delegate First SampleVarianceDelegate(Second a);
    public delegate R SampleGenericDelegate<A, R>(A a);
    delegate ParentReturnClass covrianceDelegate();
    delegate void contravrianceDelegate(Child1ReturnClass variable1);

    public class DelegateSamples
    {
        // Declare a delegate

        public void NamedMethod()
        {
            DelegateSamples m = new DelegateSamples();

            // Delegate instantiation using "Multiply"
            MathDelegate d = m.Multiply;

            // Invoke the delegate object.
            Console.WriteLine("Invoking the delegate using 'Multiply':");
            for (int i = 1; i <= 5; i++)
            {
                d(i, 5);
            }
            Console.WriteLine("");
            
        }

        // Declare the associated method.
        void Multiply(int m, double n)
        {
            System.Console.Write(m * n + " ");
        }

        public void InvokeDelegate()
        {
            HelperClass helper = new HelperClass();

            // Map the delegate to the instance method:
            SampleDelegate d = helper.InstanceMethod;
            d();

            // Map to the static method:
            d = HelperClass.StaticMethod;
            d();
        }

        public void InvokeDelegatebyAnonymousFunction()
        {
            //Named Method
            StringDelegate StringDel = HelperClass.StringMethod;
            StringDel("Chapter 5 - Named Method");

            //Anonymous method
            StringDelegate StringDelB = delegate (string s) { Console.WriteLine(s); };
            StringDelB("Chapter 5- Anonymous method invocation");

            //LambdaExpression
            StringDelegate StringDelC = (X)=> { Console.WriteLine(X); };
            StringDelB("Chapter 5- Lambda Expression invocation");

        }

        public void LambdaOperatorExample()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            // Use method syntax to apply a lambda expression to each element  
            // of the words array.   
            string searchedWord = words.Where(w => w.Equals("apple")).FirstOrDefault();
            Console.WriteLine(searchedWord);

            // Compare the following code that uses query syntax.  
            // Get the lengths of each word in the words array.  
            var query = from w in words
                        where w.Equals("apple")
                        select w;
                        
            // Apply the Min method to execute the query and get the shortest length.  
            string search2 = query.FirstOrDefault();
            Console.WriteLine(search2);

        }

        public void CoVarianceSample()
        {
            covrianceDelegate cdel;
            cdel = new HelperClass().ChildMehod1;
            Child1ReturnClass CR1 =  (Child1ReturnClass)cdel();
            Console.WriteLine(CR1.ChildMessage1);
            cdel = new HelperClass().ChildMehod2;
            Child2ReturnClass CR2 = (Child2ReturnClass)cdel();
            Console.WriteLine(CR2.ChildMessage2);
        }
        
        public void ContraVarianceSample()
        {
            Child1ReturnClass CR1 = new Child1ReturnClass() { ChildMessage1 = "ChildMessage1" };
            contravrianceDelegate cdel = new HelperClass().Method1;
            cdel(CR1);
            
        }

        public void MulticastDelegate()
        {
            StringDelegate StringDel = HelperClass.StringMethod;
            StringDel += HelperClass.StringMethod2;
            StringDel("Chapter 5 - Multicast delegate Method1");
        }

    }

    

    internal class HelperClass
    {
        public void InstanceMethod()
        {
            System.Console.WriteLine("Invoked function Instance Method.");
        }

        public static void StaticMethod()
        {
            System.Console.WriteLine("Invoked function Static Method.");
        }

        public static void StringMethod(string s)
        {
            Console.WriteLine(s);
        }

        public static void StringMethod2(string s)
        {
            Console.WriteLine("Method2 :" + s);
        }



        public Child1ReturnClass ChildMehod1() { return new Child1ReturnClass { ChildMessage1 = "ChildMessage1" }; }
        public Child2ReturnClass ChildMehod2() { return new Child2ReturnClass { ChildMessage2 = "ChildMessage2" }; }

        public void Method1(ParentReturnClass parentVariable1) { Console.WriteLine(((Child1ReturnClass)parentVariable1).ChildMessage1); }

    }

    internal class ParentReturnClass
    {
        public string Message { get; set; }
    }

    internal class Child1ReturnClass : ParentReturnClass
    {
        public string ChildMessage1 { get; set; }
    }
    internal class Child2ReturnClass : ParentReturnClass
    {
        public string ChildMessage2 { get; set; }
    }





}
