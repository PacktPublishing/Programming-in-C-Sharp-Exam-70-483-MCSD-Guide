using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSamples
{
    internal class Chapter4
    {
        public void OperatorsExamples()
        {
            int firstvalue = 5; 
            int secondvalue = 6;
            int? nullvalue = null;
            string firststring = "Hello ";
            string secondstring = "World";
            uint bitvalue = 2;
            uint resultvalue = ~bitvalue;
            
            //'+' operator
            Console.WriteLine("'+' operator"); 
            Console.WriteLine(+firstvalue); // output: 5
            Console.WriteLine(firstvalue + secondvalue); // output: 11
            Console.WriteLine(firststring + secondstring); // output: Hello World
            
            //'-' operator
            Console.WriteLine("'-' operator");
            Console.WriteLine(-firstvalue); // output: -5
            Console.WriteLine(firstvalue - secondvalue); // output = -1
            

            //'!' operator
            Console.WriteLine("'!' operator");
            Console.WriteLine(!true); //output : false

            
            //'~' operator
            Console.WriteLine("'~' operator");
            int digit = 60;
            Console.WriteLine("Number is : {0} and binary form is {1}:", digit, IntToBinaryString(digit));
            int digit1 = ~digit;
            Console.WriteLine("Number is : {0} and binary form is {1}:", digit1, Convert.ToString(digit1, 2));

            // '++' Operator
            Console.WriteLine("'++' operator");
            Console.WriteLine(++firstvalue); // output = 6

            // '--' Operator
            Console.WriteLine("'--' operator");
            Console.WriteLine(--firstvalue); // output = 5

            // '<' Operator
            Console.WriteLine("'<' operator");
            Console.WriteLine(firstvalue < secondvalue); // output = true

            // '>' Operator
            Console.WriteLine("'>' operator");
            Console.WriteLine(firstvalue > secondvalue); // output = false

            // '>=' Operator
            Console.WriteLine("'>=' operator");
            Console.WriteLine(secondvalue >= firstvalue); // output = true

            // '<=' Operator
            Console.WriteLine("'<=' operator");
            Console.WriteLine(firstvalue <= secondvalue); // output = true
            
            // '==' Operator
            Console.WriteLine("'==' operator");
            Console.WriteLine(secondvalue == firstvalue); // output = false

            
            // '!=' Operator
            Console.WriteLine("'!=' operator");
            Console.WriteLine(firstvalue != secondvalue); // output = true

            // '>>' Operator
            Console.WriteLine("'>>' operator");
            int number = 9;
            Console.WriteLine("Number is : {0} and binary form is {1}:", number, IntToBinaryString(number));
            number = number >> 1;
            Console.WriteLine("Number is : {0} and binary form is {1}:", number, IntToBinaryString(number));

            // '<<' Operator
            Console.WriteLine("'<<' operator");
            Console.WriteLine("Number is : {0} and binary form is {1}:", number, IntToBinaryString(number));
            number = number << 1;
            Console.WriteLine("Number is : {0} and binary form is {1}:", number, IntToBinaryString(number));

            //LOGICAL OR (|)
            Console.WriteLine("LOGICAL OR (|)");
            Console.WriteLine((firstvalue > secondvalue) | (firstvalue < secondvalue)); // output = true
            Console.WriteLine((firstvalue < secondvalue) | (firstvalue < secondvalue)); // output = true
            Console.WriteLine((firstvalue < secondvalue) | (firstvalue > secondvalue)); // output = true
            Console.WriteLine((firstvalue > secondvalue) | (firstvalue > secondvalue)); // output = false

            //LOGICAL AND (&)
            Console.WriteLine("LOGICAL AND (&)");
            Console.WriteLine(FirstOperand(true) & SecondOperand(true)); // output = FirstOperand computed, SecondOperand computed, true
            Console.WriteLine(FirstOperand(false) & SecondOperand(true)); // output = FirstOperand computed, SecondOperand computed, false
            Console.WriteLine(FirstOperand(true) & SecondOperand(false)); // output = FirstOperand computed, SecondOperand computed, false
            Console.WriteLine(FirstOperand(false) & SecondOperand(false)); // output = FirstOperand computed, SecondOperand computed, false

            //CONDITIONAL OR (||)
            Console.WriteLine("CONDITIONAL OR (||)");
            Console.WriteLine(FirstOperand(true) || SecondOperand(true)); // output = FirstOperand computed, true
            Console.WriteLine(FirstOperand(false) || SecondOperand(true)); // output = FirstOperand computed, SecondOperand computed, true
            Console.WriteLine(FirstOperand(true) || SecondOperand(false)); // output = FirstOperand computed, true
            Console.WriteLine(FirstOperand(false) || SecondOperand(false)); // output = FirstOperand computed, SecondOperand computed, false

            //CONDITIONAL AND (&&)
            Console.WriteLine("CONDITIONAL AND (&&)");
            Console.WriteLine(FirstOperand(true) && SecondOperand(true)); // output = FirstOperand computed, SecondOperand computed, true
            Console.WriteLine(FirstOperand(false) && SecondOperand(true)); // output = FirstOperand computed, false
            Console.WriteLine(FirstOperand(true) && SecondOperand(false)); // output = FirstOperand computed, false
            Console.WriteLine(FirstOperand(false) && SecondOperand(false)); // output = FirstOperand computed, false

            //LOGICAL XOR (^)
            Console.WriteLine("LOGICAL XOR (^)");
            Console.WriteLine(FirstOperand(true) ^ SecondOperand(true)); // output = FirstOperand computed, SecondOperand computed, false
            Console.WriteLine(FirstOperand(false) ^ SecondOperand(true)); // output = FirstOperand computed, SecondOperand computed,true
            Console.WriteLine(FirstOperand(true) ^ SecondOperand(false)); // output = FirstOperand computed, SecondOperand computed,true
            Console.WriteLine(FirstOperand(false) ^ SecondOperand(false)); // output = FirstOperand computed, SecondOperand computed,false

            //Null Coalescing (??)
            Console.WriteLine("Null Coalescing (??)");
            Console.WriteLine(nullvalue ?? firstvalue);// output : 5
 
            //Ternary Operator (? :)
            Console.WriteLine("Ternary Operator (? :)");
            Console.WriteLine((firstvalue > secondvalue) ? firstvalue : secondvalue);// output : 6
            Console.WriteLine((firstvalue < secondvalue) ? firstvalue : secondvalue);// output : 5

        }

        public static string IntToBinaryString(int number)
        {
            const int mask = 1;
            var binary = string.Empty;
            while (number > 0)
            {
                // Logical AND the number and prepend it to the result string
                binary = (number & mask) + binary;
                number = number >> 1;
            }
            return binary;
        }
        private bool SecondOperand(bool result)
        {
            Console.WriteLine("SecondOperand computed");
            return result;
        }
        private bool FirstOperand(bool result)
        {
            Console.WriteLine("FirstOperand computed");
            return result;
        }

        public void ConditionalStatementExamples()
        {
            bool condition = true;

            if (condition) //output : Then-Statement executed
            {
                Console.WriteLine("Then-Statement executed");
            }
            else
            {
                Console.WriteLine("Else-Statement executed");
            }

            if (condition) //output: Then-Statement without an Else executed
            {
                Console.WriteLine("Then-Statement without an Else executed");
            }

            int variable1 = 15;
            int variable2 = 10;
            if (variable1 > 10)//Condition 1 Output: Then-Statement of condition 1 executed, Then-Statement of condition 2 executed
            {
                Console.WriteLine("Then-Statement of condition 1 executed");
                if (variable2 < 15) //Condition 2
                {
                    Console.WriteLine("Then-Statement of condition 2 executed");
                }
                else
                {
                    Console.WriteLine("Else-Statement of condition 2 executed");
                }
            }
            else
            {
                Console.WriteLine("Else-Statement condition 1 executed");
            }

            Console.Write("Enter a character: ");
            char ch = (char)Console.Read();

            if (ch.Equals('a'))
            {
                Console.WriteLine("The character entered is a vowel and it is 'a'.");
            }
            else if (ch.Equals('e'))
            {
                Console.WriteLine("The character entered is a vowel and it is 'e'.");
            }
            else if (ch.Equals('i'))
            {
                Console.WriteLine("The character entered is a vowel and it is 'i'.");
            }
            else if (ch.Equals('o'))
            {
                Console.WriteLine("The character entered is a vowel and it is 'o'.");
            }
            else if (ch.Equals('u'))
            {
                Console.WriteLine("The character entered is a vowel and it is 'u'.");
            }
            else
            {
                Console.WriteLine("The character entered is not vowel and it is :" + ch );
            }
            Console.ReadLine();

            Console.Write("Enter a character: ");
            char ch1 = (char)Console.Read();
            switch (ch1)
            {
                case 'a' :
                case 'e':
                case 'i' :
                case 'o' :
                case 'u':
                    Console.WriteLine("The character entered is a vowel and it is: " + ch1);
                    break;
                default:
                    Console.WriteLine("The character entered is not vowel and it is: " + ch1);
                    break;
            }

            for (int i = 1; i <= 10; i++)
            {
                if (i == 5)
                {
                    break;
                }
                Console.WriteLine(i);
            }

            // Keep the console open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

            for (int i = 1; i <= 10; i++)
            {
                if (i == 5)
                {
                    goto  number5;
                }
                Console.WriteLine(i);
            }

        number5:
            Console.WriteLine("You are here because of Goto Label");

        for (int i = 1; i <= 10; i++)
        {
            if (i == 5)
            {
                continue;
            }
            Console.WriteLine(i);
        }


        }

        public void IterationStatementExmples()
        {
            int intvariable = 0;
            do
            {
                Console.WriteLine("Number is :" + intvariable);
                intvariable++;

            } while (intvariable < 5);


            for (int i = 0; i <= 5; i++)
            {
                Console.WriteLine("Number is :" + i);
            }

            //int k;
            //int j = 10;
            //for (k = 0, Console.WriteLine("Start: i={i}, j={j}"); k < j; k++, j--, Console.WriteLine("Step: k={i}, j={j}"))
            //{
            //    // Body of the loop.
            //}

            //for (; ; )
            //{
            //    // Body of the loop.
            //}

            List<string> stringlist = new List<string>() { "One", "Two", "Three" };
            foreach (string str in stringlist)
            {
                Console.WriteLine("Element #"+ str);
            }

            int n = 0;
            while (n < 5)
            {
                Console.WriteLine(n);
                n++;
            }
        }
    }
}
