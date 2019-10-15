using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSamples
{
    public class Program
    {
        public static void Main(string[] args)
        {
            System.Console.WriteLine("Press any key to start execution.");
            System.Console.ReadKey();
            new Chapter4Samples().OperatorsExamples();
            new Chapter4Samples().ConditionalStatementExamples();
            new Chapter4Samples().IterationStatementExmples();
            Console.ReadLine();
        }
    }
}


