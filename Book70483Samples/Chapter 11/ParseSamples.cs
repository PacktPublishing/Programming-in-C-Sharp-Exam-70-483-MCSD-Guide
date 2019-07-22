using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter11
{
    internal class ParseSamples
    {
        internal void ProcessBool(string boolValue)
        {
            if (bool.Parse(boolValue))
            {
                Console.WriteLine($"Parsed bool value is : {bool.Parse(boolValue)}");
            }
        }

        internal void ProcessInteger(string intValue)
        {
            
            int processedValue =int.MinValue;
            if (int.TryParse(intValue, out processedValue))
            {
                Console.WriteLine($"Parsed int value is : {processedValue}");
            }
            else
            {
                Console.WriteLine("Parsed value is not an integer");
            }
            Console.WriteLine($"Parsed int value is : {int.Parse(intValue)}");
        }

        internal void ConvertSample()
        {
            
            try
            {
                string svalue =string.Empty; 
                Console.WriteLine(Convert.ToInt32(svalue));
            }
            catch (FormatException fx)
            {
                Console.WriteLine("Format Exception : "+fx.Message);
            }
            try
            {
                double dvalue = 1212121212121212.12;
                Console.WriteLine(Convert.ToInt32(dvalue));
            }
            catch (OverflowException ox)
            {
                Console.WriteLine("OverFlow Exception : " + ox.Message);
            }

            try
            {
                DateTime date= DateTime.Now;
                Console.WriteLine(Convert.ToDouble(date));
            }
            catch (InvalidCastException ix)
            {
                Console.WriteLine("Invalid cast Exception : " + ix.Message);
            }

            double dvalue1 = 12.22;
            Console.WriteLine("Converted Value : " + Convert.ToInt32(dvalue1));
                       

        }
    }
}
