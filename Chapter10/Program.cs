using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Chapter10
{
    [ChapterInfo("Chapter10", "Madhav")]
    class Program
    {
        static void Main(string[] args)
        {
            //ChapterInfoAttribute _attribute = (ChapterInfoAttribute)Attribute.GetCustomAttribute(typeof(Program), typeof(ChapterInfoAttribute));
            //Console.WriteLine($"Chapter Name is: {_attribute.ChapterName} and Chapter Author is: {_attribute.ChapterAuthor}");

            //CallCustomerClass();

            GetResults();
            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }

        private static void CallCustomerClass()
        {
            Type _customerType = typeof(Customerclass);
            object _obj = Assembly.GetExecutingAssembly().CreateInstance(_customerType.FullName);
            MethodInfo methods = _customerType.GetMethod("DisplayMethod",BindingFlags.Public);
            methods.Invoke(_obj, new object []{ "Madhav" });
        }

        public static void GetResults()
        {
            Type objType = typeof(CustomClass1);
            object obj = Activator.CreateInstance(objType);
            foreach (PropertyInfo prop in objType.GetProperties())
            {
                if(prop.Name =="Number1")
                    prop.SetValue(obj, 100);
                if (prop.Name == "Number2")
                    prop.SetValue(obj, 50);
            }

            MethodInfo mInfo = objType.GetMethod("Getresult");
            mInfo.Invoke(obj, new string[] { "Add" });
            mInfo.Invoke(obj, new string[] { "Subtract" });
        }

    }
}
