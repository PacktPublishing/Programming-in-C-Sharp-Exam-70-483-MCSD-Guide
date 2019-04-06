using System;

namespace Chapter10
{
    [System.AttributeUsage(System.AttributeTargets.Class, Inherited =false,AllowMultiple = false)]
    public class ChapterInfoAttribute : Attribute
    {
        public string ChapterName{ get; set; }
        public string ChapterAuthor { get; set; }

        public ChapterInfoAttribute(string Name, string Author)
        {
            ChapterName = Name;
            ChapterAuthor = Author;
        }

    }

    public enum CustomerType
    {
        Customer,
        Supplier,
        Vendor
    }

    [System.AttributeUsage(System.AttributeTargets.Field | System.AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class CustomerAttribute : Attribute
    {
        public CustomerType Type { get; set; }

        public CustomerAttribute()
        {
            Type = CustomerType.Customer;
        }
    }

    public class Customerclass
    {
        public void DisplayMessage(string Name)
        {
            Console.WriteLine($"Hello {Name}!");
        }
    }


}
