using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Chapter6
{
    internal class AsynchronouseProgramming
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<int> GetDotNetCountAsync()
        {
            var html = await _httpClient.GetStringAsync("https://dotnetfoundation.org");
            
            return Regex.Matches(html, @"\.NET").Count;
        }

        public void TestAsyncMethods()
        {
            Console.WriteLine("Invoking GetDotNetCountAsync method");
            int count = GetDotNetCountAsync().Result;
            
            Console.WriteLine($"Number of times .Net keyword displayed is {count}");
        }
    }
}
