using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Http;

namespace Chapter_14
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo directoryInfoExists = new DirectoryInfo("C:\\UCN Code Base\\Programming-in-C-Exam-70-483-MCSD-Guide\\Book70483Samples\\Chapter 2199");
            if (directoryInfoExists.Exists)
            {
                Console.WriteLine("It exists");
            }
            else
            {
                Console.WriteLine("Does not exists");
            }

            Console.ReadLine();


            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo d in allDrives)
            {
                Console.WriteLine("Drive Name" + d.Name);
                Console.WriteLine("  Drive type " + d.DriveType);
                if (d.IsReady == true)
                {
                    Console.WriteLine("Available space ", d.AvailableFreeSpace);
                    Console.WriteLine("Total size in bytes ", d.TotalSize);
                }
            }

            DirectoryInfo directoryInfo = new DirectoryInfo("C:\\UCN Code Base\\Programming-in-C-Exam-70-483-MCSD-Guide\\Book70483Samples");
            foreach (DirectoryInfo f in directoryInfo.GetDirectories())
            {
                Console.WriteLine("Directory Name is " + f.Name);
                Console.WriteLine("Directory created time is " + f.CreationTime);
                Console.WriteLine("Directory last modified time is " + f.LastAccessTime);
            }

            DirectoryInfo directoryInfoExistsNew = new DirectoryInfo("C:\\UCN Code Base\\Programming-in-C-Exam-70-483-MCSD-Guide\\Book70483Samples\\Chapter 20");
            if(directoryInfoExistsNew.Exists)
            {
                Console.WriteLine("It exists");
            }
            else
            {
                Directory.CreateDirectory("C:\\UCN Code Base\\Programming-in-C-Exam-70-483-MCSD-Guide\\Book70483Samples\\Chapter 20");                
            }

            DirectoryInfo chapter20 = new DirectoryInfo("C:\\UCN Code Base\\Programming-in-C-Exam-70-483-MCSD-Guide\\Book70483Samples\\Chapter 20");


            foreach (FileInfo f in chapter20.GetFiles())
            {
                Console.WriteLine("File Name is " + f.FullName);
                Console.WriteLine("File created time is " + f.CreationTime);
                Console.WriteLine("File last modified time is " + f.LastAccessTime);
            }

            string file = "C:\\UCN Code Base\\Programming-in-C-Exam-70-483-MCSD-Guide\\Book70483Samples\\Chapter 20\\IO Operations.txt";
            if(File.Exists(file))
            {
                Console.WriteLine("File Existis in the mentioned path");
            }
            else
            {
                Console.WriteLine("File does not exists in the mentioned path");
            }

            string sourceFileLocation = @"C:\UCN Code Base\Programming-in-C-Exam-70-483-MCSD-Guide\Book70483Samples\Chapter 20";
            string fileName = @"IO Operations.txt";
            string properFilePath = Path.Combine(sourceFileLocation, fileName);
            Console.WriteLine(Path.GetDirectoryName(properFilePath));
            Console.WriteLine(Path.GetExtension(properFilePath));
            Console.WriteLine(Path.GetFileName(properFilePath));
            Console.WriteLine(Path.GetPathRoot(properFilePath));
            Console.ReadLine();

            string sourceFileLocationNew = "C:\\UCN Code Base\\Programming-in-C-Exam-70-483-MCSD-Guide\\Book70483Samples\\Chapter 20\\IO Operations.txt";
            string targetFileLocation = "C:\\UCN Code Base\\Programming-in-C-Exam-70-483-MCSD-Guide\\Book70483Samples\\Chapter 21\\New File.txt";

            if (File.Exists(sourceFileLocationNew))
            {
                File.Move(sourceFileLocationNew, targetFileLocation);                
            }
            else
            {
                Console.WriteLine("File does not exists in the mentioned path");
            }

            Console.ReadLine();

            
            if (File.Exists(targetFileLocation))
            {
                File.Copy(targetFileLocation, sourceFileLocation);
            }
            else
            {
                Console.WriteLine("File does not exists in the mentioned path");
            }

            File.Delete(sourceFileLocation);
            

        }

        public void WriteToFileUsingFileStream()
        {
            string sourceFileLocation = @"C:\UCN Code Base\Programming-in-C-Exam-70-483-MCSD-Guide\Book70483Samples\Chapter 20\Sample.txt";
            using (FileStream fileStream = File.Create(sourceFileLocation))
            {
                string myValue = "MyValue";
                byte[] data = Encoding.UTF8.GetBytes(myValue);
                fileStream.Write(data, 0, data.Length);
            }
        }

        public void WriteToFileUsingStreamWriter()
        {
            string sourceFileLocation = @"C:\UCN Code Base\Programming-in-C-Exam-70-483-MCSD-Guide\Book70483Samples\Chapter 20\Sample.txt";
            using (StreamWriter streamWriter = File.CreateText(sourceFileLocation))
            {
                string myValue = "MyValue";
                streamWriter.Write(myValue);
            }
        }

        private static string ReadFileText()
        {
            string path = @"C:\UCN Code Base\Programming-in-C-Exam-70-483-MCSD-Guide\Book70483Samples\Chapter 20\Sample.txt";
            if (File.Exists(path))
            {
                try
                {
                    return File.ReadAllText(path);
                }
                catch (DirectoryNotFoundException)
                {
                    return string.Empty;
                }
                catch (FileNotFoundException)
                {
                    return string.Empty;
                }
            }
            return string.Empty;
        }

        private static void ReadWebRequest()
        {
            WebRequest request = null;
            HttpWebResponse response = null;
            Stream dataStream = null;
            StreamReader reader = null;
            try
            {
                request = WebRequest.Create("http://www.google.com/search?q=c#");
                request.Method = "GET";
                response = (HttpWebResponse)request.GetResponse();
                dataStream = response.GetResponseStream();
                reader = new StreamReader(dataStream);
                Console.WriteLine(reader.ReadToEnd());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                reader.Close();
                dataStream.Close();
                response.Close();
            }
        }

        async Task<int> ExecuteOperationAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                Task<string> getStringTask = client.GetStringAsync("http://google.com");

                ExecuteParallelWork();

                string urlContents = await getStringTask;

                return urlContents.Length;
            }                      
        }

        private static void ExecuteParallelWork()
        {
            // Execute parallel work
        }

        public async Task CreateFile()
        {
            string path = @"C:\UCN Code Base\Programming-in-C-Exam-70-483-MCSD-Guide\Book70483Samples\Chapter 20\New.txt";
            using (FileStream stream = new FileStream(path, FileMode.Create,
            FileAccess.Write, FileShare.None, 4096, true))
            {
                byte[] data = new byte[100000];
                new Random().NextBytes(data);
                await stream.WriteAsync(data, 0, data.Length);
            }
        }

        public async Task ExecuteMultipleRequestsInParallel()
        {
            HttpClient client = new HttpClient();
            Task google = client.GetStringAsync("http://www.google.com");
            Task bing = client.GetStringAsync("http://www.bing.com");
            Task yahoo = client.GetStringAsync("http://yahoo.com/");
            await Task.WhenAll(google, bing, yahoo);
        }
    }
}
