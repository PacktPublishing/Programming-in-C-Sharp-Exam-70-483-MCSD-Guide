using System;

namespace Chapter10
{
    
    internal class Account
    {
        public string CustomerName { get; set; }

        [Customer]
        public RatingType Rating { get; set; }
    }

    public enum RatingType
    {
        Gold =1,
        Silver =2,
        Bronze=3
    }


    internal class CustomClass1
    {
        public int Number1 { get; set; }
        public int Number2 { get; set; }

        public int Getresult(string action)
        {
            int result = 0;
            switch (action)
            {
                case "Add":
                    result = Number1 + Number2;
                    Console.WriteLine($"Sum of numbers {Number1} and {Number2} is : {result}");
                    break;

                case "Subtract":
                    result = Number1 - Number2;
                    Console.WriteLine($"Difference of numbers {Number1} and {Number2} is : {result}");
                    break;
            }
            return result;
        }
    }
}
