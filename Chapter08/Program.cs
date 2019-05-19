using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Chapter_8
{
    class SampleProperty
    {
        private string name;
        public string Name
        {
            set { if(value != null)
                    {
                        this.name = value;
                    }
                  else
                    {
                        throw new ArgumentException();
                    }
                }
            get { return this.name; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ReadAssembly();
            StringSearchFunction();
            string xmlFile = CreateXMLFile();
            Console.WriteLine(xmlFile);
            ReadXMLFile(xmlFile);

            int i = 100;
            float f = i;

            float k = 100.99F;
            int j = (int)k;
            int a = Convert.ToInt32(k);
            /*Console.WriteLine(j);
            Console.WriteLine(a);*/
            string number = "100wer";
            int num;
            bool parse = int.TryParse(number, out num);
            if(parse)
            {
                Console.WriteLine(num);
            }
            else
            {
                Console.WriteLine("Some error in doing conversion");
            }
            Console.ReadLine();
            UnSafeExample();
            IsEqual("string", "string");
            IsEqual(10, 10);

            StringBuilder sb = new StringBuilder(string.Empty);
            for (int z = 0; z < 100; z++)
            {
                sb.Append("a");               
            }
        }

        static private string CreateXMLFile()
        {
            string xmlOutput = string.Empty;
            var stringWriter = new StringWriter();
            using (XmlWriter writer = XmlWriter.Create(stringWriter))
            {
                writer.WriteStartElement("Student");
                writer.WriteElementString("Name", "Rob");
                writer.WriteEndElement();
                writer.Flush();
            }

            xmlOutput = stringWriter.ToString();
            return xmlOutput;
        }

        static private void ReadXMLFile(string xml)
        {
            var stringReader = new StringReader(xml);
            using (XmlReader reader = XmlReader.Create(stringReader))
            {
                reader.ReadToFollowing("Name");
                string studentName = reader.ReadInnerXml();
                Console.WriteLine(studentName);
            }
        }

        static private void StringSearchFunction()
        {
            string s = "hello australia";
            var contains = s.Contains("z");
            if(contains)
            {
                Console.WriteLine(contains + " z is present in it.");
            }
            else
            {
                Console.WriteLine(contains + " z is not present");
            }

            var firstIndexOfA = s.IndexOf("a");
            Console.WriteLine(firstIndexOfA);
            var lastIndexOfA = s.LastIndexOf("a");
            Console.WriteLine(lastIndexOfA);

            if(s.StartsWith("h"))
            {
                Console.WriteLine("It Starts with h.");
            }
            else
            {
                Console.WriteLine("It does not starts with h.");
            }

            if (s.EndsWith("h"))
            {
                Console.WriteLine("It ends with h.");
            }
            else
            {
                Console.WriteLine("It does not ends with h.");
            }

            string subString = s.Substring(3, 6);
            string subString2 = s.Substring(3);
            Console.WriteLine(subString);
            Console.WriteLine(subString2);
        }

        static private void ReadAssembly()
        {
            string path = @"C:\UCN Code Base\Programming-in-C-Exam-70-483-MCSD-Guide\Book70483Samples\Chapter 8\bin\Debug\LinkGroup.Dev.Common.dll";
            Assembly assembly = Assembly.LoadFile(path);
            Type[] types = assembly.GetTypes();
            foreach(var type in types)
            {
                Console.WriteLine("Class : " + type.Name);
                MethodInfo[] methods = type.GetMethods();
                foreach(var method in methods)
                {
                    Console.WriteLine("--Method: " + method.Name);
                    ParameterInfo[] parameters = method.GetParameters();
                    foreach (var param in parameters)
                    {
                        Console.WriteLine("--- Parameter: " + param.Name + " : " + param.ParameterType); 
                    }
                }
            }

            Console.ReadLine();
        }

        static private bool IsEqual<T>(T A, T B)
        {
            if (A.Equals(B))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static private void BoxAndUnBox()
        {
            int i = 3;
            // Boxing conversion from value to reference type
            object obj = i;
            // Unboxing conversion from reference type to value type
            i = (int)obj;
        }

        unsafe static private void UnSafeExample()
        {
            int i = 23;
            int* pi = &i;
            Console.WriteLine(i);
            Console.WriteLine(*pi);
            Console.ReadLine();
        }

        
    }
}
