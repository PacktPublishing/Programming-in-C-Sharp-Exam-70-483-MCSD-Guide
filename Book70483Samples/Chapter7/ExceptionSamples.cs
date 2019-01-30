using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Chapter7
{
    internal class ExceptionSamples
    {
        public static void ExceptionTest1()
        {
            string str = string.Empty;
            int parseInt = int.Parse(str);
        }

        public static void ExceptionTest2()
        {
            string str = string.Empty;
            try
            {
                int parseInt = int.Parse(str);
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Exception Data: {e.Data}");
                Console.WriteLine($"Exception HelpLink: {e.HelpLink}");
                Console.WriteLine($"Exception HResult: {e.HResult}");
                Console.WriteLine($"Exception InnerException: {e.InnerException}");
                Console.WriteLine($"Exception Message: {e.Message}");
                Console.WriteLine($"Exception Source: {e.Source}");
                Console.WriteLine($"Exception TargetSite: {e.TargetSite}");
                Console.WriteLine($"Exception StackTrace: {e.StackTrace}");
            }
        }

        public static void ExceptionTest3()
        {
            string str = string.Empty;
            try
            {
                int parseInt = int.Parse(str);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Argument Exception caught");
            }
            catch (FormatException e)
            {
                Console.WriteLine("Format Exception caught");

            }
            catch (Exception ex1)
            {
                Console.WriteLine("Generic Exception caught");
            }
        }

        public static void ExceptionTest4()
        {
            string str = string.Empty;
            try
            {
                int parseInt = int.Parse(str);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Argument Exception caught");
            }
            catch (FormatException e)
            {
                Console.WriteLine("Format Exception caught");

            }
            catch (Exception ex1)
            {
                Console.WriteLine("Generic Exception caught");
            }
            finally
            {
                Console.WriteLine("Finally block executed");
            }
        }

        public static void ExceptionTest5()
        {
            string[] strNumbers = new string[] {"One","Two","Three","Four" };
            try
            {
                for (int i = 0; i <= strNumbers.Length; i++)
                {
                    Console.WriteLine(strNumbers[i]);
                }
            }
            catch (System.IndexOutOfRangeException e)
            {
                Console.WriteLine("Index is out of range.");
                throw new System.ArgumentOutOfRangeException(
                    "Index is out of range.", e);
            }

        }

        public static void ExceptionTest6()
        {
            System.IO.FileStream file = null;
            System.IO.FileInfo fileinfo = new System.IO.FileInfo("C:\\Windows\\Temp\\file.txt");
            try
            {
                file = fileinfo.OpenWrite();
                file.WriteByte(0xF);
            }
            finally
            {
                // Check for null because OpenWrite might have failed.
                if (file != null)
                {
                    file.Close();
                }
            }
        }
    }

    public class MyCustomException : Exception
    {
        public MyCustomException():base("This is my custom exception")
        {

        }

        public MyCustomException(string message) : base($"This is from the method : {message}")
        {

        }

        public MyCustomException(string message, Exception innerException) : base($"Message: {message}, InnerException: {innerException}")
        {
        }

        protected MyCustomException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }


}
