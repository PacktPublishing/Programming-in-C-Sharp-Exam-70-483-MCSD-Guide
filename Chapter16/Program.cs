using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Chapter_16
{
    [Serializable]
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID;
        [XmlIgnore]
        public string Feedback { get; set; }
        [XmlArray("CourseScores")]
        [XmlArrayItem("Course")]
        public List<CourseScore> CoursePerformance { get; set; }
        public Student()
        {
        }
        public Student(string firstName, string lastName, int Id, string feedback)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ID = Id;
            this.Feedback = feedback;
        }
        public void CreateCoursePerformance()
        {
            Course phy = new Course { Name = "Physics", Description = "Physics Subject" };
            Course che = new Course { Name = "Chemistry", Description = "Chemistry Subject" };
            Course math = new Course { Name = "Maths", Description = "Mathsmetics Subject" };
            Course computers = new Course { Name = "Computers", Description = "Computers Subject" };
            Course eng = new Course { Name = "English", Description = "English Subject" };
            CourseScore phyScore = new CourseScore { Course = phy, Score = 80 };
            CourseScore cheScore = new CourseScore { Course = che, Score = 80 };
            CourseScore mathScore = new CourseScore { Course = math, Score = 80 };
            CourseScore compScore = new CourseScore { Course = computers, Score = 80 };
            CourseScore engScore = new CourseScore { Course = eng, Score = 80 };
            List<CourseScore> scores = new List<CourseScore>();
            scores.Add(phyScore);
            scores.Add(cheScore);
            scores.Add(mathScore);
            scores.Add(compScore);
            scores.Add(engScore);
            this.CoursePerformance = scores;
        }
    }
    [Serializable]
    public class CourseScore
    {
        [XmlElement("Course")]
        public Course Course;
        [XmlAttribute]
        public int Score;
    }
    [Serializable]
    public class Course
    {
        [XmlAttribute]
        public string Name;
        public string Description;
    }

    [Serializable]
    public class StudentBinary
    {
        public string FirstName;
        public string LastName;
        public int ID;
        [NonSerialized]
        public string Feedback;

        public StudentBinary(string firstName, string lastName, int Id, string feedback)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ID = Id;
            this.Feedback = feedback;
        }
    }

    [Serializable]
    public class StudentBinaryInterface : ISerializable
    {
        public string FirstName;
        private string LastName;
        public int ID;
        public string Feedback;
        protected StudentBinaryInterface(SerializationInfo info, StreamingContext context)
        {
            FirstName = info.GetString("Value1");
            Feedback = info.GetString("Value2");
            ID = info.GetInt32("Value3");
        }
        public StudentBinaryInterface(string firstName, string lastName, int Id, string feedback)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ID = Id;
            this.Feedback = feedback;
        }
        [System.Security.Permissions.SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Value1", FirstName);
            info.AddValue("Value2", Feedback);
            info.AddValue("Value3", ID);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Student));
            string fileName = "StudentDataWithScores";
            using (TextWriter writer = new StreamWriter(fileName))
            {
                Student stuxml = new Student("Jacob", "Almeida", 78, "Passed");
                stuxml.CreateCoursePerformance();
                serializer.Serialize(writer, stuxml);
                writer.Close();
            }

            StudentBinary stunbin = new StudentBinary("Jacob", "Almeida", 78, "Passed");
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream("StudentBinaryData.bin", FileMode.Create))
            {
                formatter.Serialize(stream, stunbin);
            }

            using (Stream stream = new FileStream("StudentBinaryData.bin", FileMode.Open))
            {
                StudentBinary studeseria = (StudentBinary)formatter.Deserialize(stream);
            }

            StudentBinaryInterface stu = new StudentBinaryInterface("Jacob", "Almeida", 78, "Passed");
            IFormatter formatterInterface = new BinaryFormatter();
            using (Stream stream = new FileStream("StudentBinaryData.bin", FileMode.Create))
            {
                formatterInterface.Serialize(stream, stu);
            }
            using (Stream stream = new FileStream("StudentBinaryData.bin", FileMode.Open))
            {
                StudentBinaryInterface studeseria = (StudentBinaryInterface)formatterInterface.Deserialize(stream);
            }

            CollectionOperations();
            ListCollectionOperations();
            DictionaryCollectionOperations();
            QueueOperations();
            StackOperations();
            Console.ReadLine();
        }

        public static void CollectionOperations()
        {
            int[] arrayOfInt = new int[10];
            for (int x = 0; x < arrayOfInt.Length; x++)
            {
                arrayOfInt[x] = x;
            }
            foreach (int i in arrayOfInt)
            {
                Console.Write(i); 
            }
            Console.WriteLine();

            int[,] arrayInt = new int[3,2] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            for (int i=0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.WriteLine(arrayInt[i, j]);
                }                
            }
        }

        public static void ListCollectionOperations()
        {
            List<int> vs = new List<int> { 1, 2, 3, 4, 5, 6 };
            for (int x = 0; x < vs.Count; x++)
                Console.Write(vs[x]); 
            vs.Remove(1);
            Console.WriteLine(vs[0]); 
            vs.Add(7);
            Console.WriteLine(vs.Count); 
            bool hasC = vs.Contains(4);
            Console.WriteLine(hasC); 
        }

        public static void DictionaryCollectionOperations()
        {
            Dictionary<int, int> vs = new Dictionary<int, int>();
            for (int x = 0; x < 5; x++)
            {
                vs.Add(x, x * 100);
            }

            foreach(KeyValuePair<int, int> keyValue in vs)
            {
                Console.WriteLine(keyValue.Key + " " + keyValue.Value);
            }
            // vs.Add(1, 1000); This will result in an exception as the key is already existing in Dictionary object
            vs.Remove(1);
            vs.Add(5, 500);
            Console.WriteLine(vs.Count);
            bool hasKey = vs.ContainsKey(4);
            bool hasValue = vs.ContainsValue(900);
            Console.WriteLine(hasKey);
            Console.WriteLine(hasValue);
        }

        public static void QueueOperations()
        {
            Queue<string> que = new Queue<string>();
            que.Enqueue("E");
            que.Enqueue("D");
            que.Enqueue("C");
            que.Enqueue("B");
            que.Enqueue("A");
            int index = 0;
            foreach(string s in que)
            {
                Console.WriteLine("Queue Element at index " + index + " is " + s);
                index++;
            }
            Console.WriteLine("Queue Element at top of the queue is " + que.Peek());
            que.Dequeue();
            index = 0;
            foreach (string s in que)
            {
                Console.WriteLine("Queue Element at index " + index + " is " + s);
                index++;
            }
        }

        public static void StackOperations()
        {
            Stack<string> sta = new Stack<string>();
            sta.Push("E");
            sta.Push("D");
            sta.Push("C");
            sta.Push("B");
            sta.Push("A");
            int index = 0;
            foreach (string s in sta)
            {
                Console.WriteLine("Stack Element at index " + index + " is " + s);
                index++;
            }
            Console.WriteLine("Stack Element at top of the stack is " + sta.Peek());
            sta.Pop();
            index = 0;
            foreach (string s in sta)
            {
                Console.WriteLine("Stack Element at index " + index + " is " + s);
                index++;
            }

            Student[] arrays = new Student[] { };
        }
    }
}
