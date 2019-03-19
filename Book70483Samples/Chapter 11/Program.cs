using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace Chapter11
{
    class Program
    {
        static void Main(string[] args)
        {
            ParseSamples ps = new ParseSamples();
            switch (args.Length)
            {
                case 1:
                    ps.ProcessBools(args[0]);
                    break;
                case 2:
                    ps.ProcessBools(args[0]);
                    ps.ProcessIntegers(args[1]);
                    break;
                default:
                    Console.WriteLine("Please provide one or two command line arguments");
                    break;
            }

            ps.ConvertSample();
            RegularExpressionSamples res = new RegularExpressionSamples();
            res.ReplacePatternText();
            res.MatchPatternText();
            res.IsMatchPattern();

            Student st = new Student();
            st.FullName = "st1";
            st.EmailAddress = "st@st";
            st.DOB = DateTime.Now;

            ValidationContext context = new ValidationContext(st, null, null);
            List<ValidationResult> results = new List<ValidationResult>();
            bool valid = Validator.TryValidateObject(st, context, results, true);
            if (!valid)
            {
                foreach (ValidationResult vr in results)
                {
                    Console.Write("Student class Property Name :{0}", vr.MemberNames.First());
                    Console.Write("   ::  {0}{1}", vr.ErrorMessage, Environment.NewLine);
                }
            }

            LoadXML();



            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }

        static void LoadXML()
        {
            var path = new Uri(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)).LocalPath;
            XmlSchemaSet schema = new XmlSchemaSet();
            schema.Add("", path + "\\sample.xsd");
            XmlReader rd = XmlReader.Create(path + "\\sample.xml");
            XDocument doc = XDocument.Load(rd);
            Console.WriteLine("Validating XML");
            doc.Validate(schema, ValidationEventHandler);
            Console.WriteLine("Validating XML Completed");
        }
        static void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            XmlSeverityType type = XmlSeverityType.Warning;
            if (Enum.TryParse<XmlSeverityType>("Error", out type))
            {
                if (type == XmlSeverityType.Error) throw new Exception(e.Message);
            }
        }
    }
}
