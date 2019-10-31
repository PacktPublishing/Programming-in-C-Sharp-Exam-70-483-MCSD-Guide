using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Chapter_15
{
    public static class IntExtensions
    {
        public static int Multiply(this int x, int y)
        {
            return x * y;
        }
    }

    public static class LinqExtensions
    {
        public static IEnumerable<TSource> Where<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            foreach (TSource item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }
    }

    class Program
    {
        public class Student
        {
            public int rollNum { get; set; }
            public string Name { get; set; }
            public string classID { get; set; }
            public int age { get; set; }
        }

        public class Class
        {
            public string classID { get; set; }
            public string className { get; set; }
        }

        static void Main(string[] args)
        {
            var anonymousType = new
            {
                PropertyNum1 = "One",
                PropertyNum2 = 2,
                PropertyNum3 = true
            };

            Console.WriteLine(anonymousType.GetType().ToString());
            
            
            int[] numbers = new int[3] { 0, 1, 2};

            var numQuery =
                from num in numbers
                where (num % 2) == 0
                select num;

            foreach (int num in numQuery)
            {
                Console.Write("{0,1} ", num);
            }             

            Dictionary<string, IEnumerable<Tuple<Type, int>>> data =
new Dictionary<string, IEnumerable<Tuple<Type, int>>>();
            var implicitData = new Dictionary<string, IEnumerable<Tuple<Type, int>>>();

            Student p = new Student();
            p.rollNum = 1;
            p.Name = "John";

            Student p2 = new Student();
            p2.rollNum = 2;
            p2.Name = "Donohoe";

            var students = new List<Student>
            {
                new Student
                {
                    rollNum = 1,
                    Name = "John"
                },
                new Student
                {
                    rollNum = 2,
                    Name = "Donohoe"
                }
            };

            Func<int, int> anonymousFunc = delegate (int x)
            {
                return x * 5;
            };
            Console.WriteLine(anonymousFunc(1));

            Func<int, int> anonymousFuncLambda = y => y * 5;            
            Console.WriteLine(anonymousFuncLambda(1));
            int z = 2;
            Console.WriteLine(z.Multiply(3));

            var s = new
            {
                rollNum = 1,
                Name = "James"
            };
            Console.WriteLine(s.GetType().Name);
            LINQXmlFunctions();
            LinqQueriesOperations();
            Console.ReadLine();
        }
        
        public static void LinqQueriesOperations()
        {
            int[] numbers = new int[3] { 0, 1, 2 };
            var numQuery =
                from num in numbers
                select num;
            
            foreach(var n in numQuery)
            {
                Console.Write(n);
            }
            Console.WriteLine();
            string[] array =
            {
                "Introduction",
                "In",
                "C#"
            };

            var result = array.SelectMany(element => element.ToCharArray());

            foreach (char letter in result)
            {
                Console.Write(letter);
            }

            Console.WriteLine();

            List<Class> classNames = new List<Class>();
            classNames.Add(new Class { classID = "1", className = "First Standard" });
            classNames.Add(new Class { classID = "2", className = "Second Standard" });
            classNames.Add(new Class { classID = "3", className = "Third Standard" });

            List<Student> students = new List<Student>();
            students.Add(new Student { rollNum = 1, classID = "1", Name = "Sia Bhalla", age = 1 });
            students.Add(new Student { rollNum = 2, classID = "2", Name = "James Donohoe", age = 35  });
            students.Add(new Student { rollNum = 3, classID = "1", Name = "Myra  Thareja", age = 8 });
            students.Add(new Student { rollNum = 4, classID = "3", Name = "Simaranjit Bhalla", age = 33 });
            students.Add(new Student { rollNum = 5, classID = "3", Name = "Jimmy Bhalla", age = 33 });
            students.Add(new Student { rollNum = 6, classID = "2", Name = "Misha Thareja", age = 35 });

            var groupedResult = from s in students
                                group s by s.classID;

            //iterate each group        
            foreach (var classGroup in groupedResult)
            {
                Console.WriteLine("Class Group: {0}", classGroup.Key); //Each group has a key 

                foreach (Student s in classGroup) // Each group has inner collection
                    Console.WriteLine("Student Name: {0}", s.Name);
            }
            Console.WriteLine("Student Groups");

            var avg = students.Average(s => s.age);
            Console.WriteLine(avg);
            Console.WriteLine();
            var list = (from s in students
                        join d in classNames on s.classID equals d.classID
                        select new
                        {
                            StudentName = s.Name,
                            ClassName = d.className
                        });

            foreach (var e in list)
            {
                Console.WriteLine("Student Name = {0} , Class Name = {1}", e.StudentName, e.ClassName);
            }
            Console.WriteLine();
            int[] data = { 8, 11, 6, 3, 9 };
            var resultOrder = from d in data
                         where d > 5
                         orderby d descending
                         select d;
            Console.WriteLine(string.Join(", ", resultOrder));
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();

        }

        public static void LINQXmlFunctions()
        {
            String xml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
                            <Students>
                                <Student Name=""Simaranjit"" rollNum=""1"">
                                    <contactdetails>
                                        <emailaddress>sbhalla@gmail.com</emailaddress>
                                        <phoneNumber>0416274824</phoneNumber>
                                    </contactdetails>
                                </Student>
                                <Student Name=""James"" rollNum=""2"">
                                    <contactdetails>
                                        <emailaddress>jamesdonohoe@gmail.com</emailaddress>
                                    </contactdetails>
                                </Student>
                            </Students>";

            XDocument doc = XDocument.Parse(xml);
            IEnumerable<string> studentNames = from p in doc.Descendants("Student")
                                              select (string)p.Attribute("Name")
                                              + " " + (string)p.Attribute("rollNum");
            foreach (string s in studentNames)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine();
            XDocument docFil = XDocument.Parse(xml);
            IEnumerable<string> studentNamesFilter = from p in docFil.Descendants("Student")
                                                     where p.Descendants("phoneNumber").Any()
                                                     select (string)p.Attribute("Name")
                                                     + " " + (string)p.Attribute("rollNum");
            foreach (string s in studentNamesFilter)
            {
                Console.WriteLine(s);
            }

            XElement root = new XElement("Student",
            new List<XElement>
            {
                new XElement("Marks"),
                new XElement("Attendance")
            },
            new XAttribute("RollNumber", 1));
            root.Save("test.xml");

            XElement rootUpd = XElement.Parse(xml);
            foreach (XElement p in rootUpd.Descendants("Student"))
            {
                XElement contactDetails = p.Element("contactdetails");
                contactDetails.Add(new XElement("MobileNumber", "12345678"));
                
            }
            rootUpd.Save("testupd.xml");
            
            Console.ReadLine();
        }
    }
}
